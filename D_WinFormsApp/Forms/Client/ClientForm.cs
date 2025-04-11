using D_WinFormsApp.Helpers;
using D_WinFormsApp.Models;
using System.Net.Http.Json;

namespace D_WinFormsApp
{
    public partial class ClientForm : MyForm
    {
        // testing git
        public FormMode Mode { get; set; }
        private readonly int? _clientID;

        public ClientForm(FormMode mode = FormMode.AddNew, int? clientID = null)
        {
            InitializeComponent();
            Mode = mode;
            _clientID = clientID;
            if (clientID.HasValue)
            {
                LoadClientDataAsync(clientID.Value);
            }
        }

        private async void LoadClientDataAsync(int clientID)
        {
            try
            {
                var response = await ApiClient.Client.GetAsync($"Client/{clientID}");
                if (response.IsSuccessStatusCode)
                {
                    var client = await response.Content.ReadFromJsonAsync<Client>();
                    if (client != null)
                    {
                        InvokeIfNeeded(() =>
                        {
                            txtFullName.Text = client.FullName;
                            txtEmail.Text = client.Email;
                            txtPhone.Text = client.Phone;
                            txtAddress.Text = client.Address;
                        });
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    ShowMessage("Client not found.");
                    Close();
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
                Close();
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await SaveClientAsync();
        }

        private async Task SaveClientAsync()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtPhone.Text) ||
                    string.IsNullOrWhiteSpace(txtAddress.Text))
                {
                    ShowMessage("Please fill all required fields.");
                    return;
                }

                var client = new Client
                {
                    ClientID = _clientID ?? 0,
                    FullName = txtFullName.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text,
                    Address = txtAddress.Text
                };

                HttpResponseMessage response = Mode == FormMode.AddNew
                    ? await ApiClient.Client.PostAsJsonAsync("Client", client)
                    : await ApiClient.Client.PutAsJsonAsync($"Client/{client.ClientID}", client);

                if (response.IsSuccessStatusCode)
                {
                    ShowMessage("Client saved successfully.");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    ShowMessage("Failed to save client.");
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            Text = Mode == FormMode.AddNew ? "Bank System - Add New Client" : "Bank System - Update Client";
        }
    }
}