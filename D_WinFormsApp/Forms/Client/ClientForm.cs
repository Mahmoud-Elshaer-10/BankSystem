using D_WinFormsApp.Helpers;
using D_WinFormsApp.Models;
using System.Net.Http.Json;
using System.Text.RegularExpressions;

namespace D_WinFormsApp
{
    public partial class ClientForm : MyForm
    {
        public FormMode Mode { get; set; }
        private readonly int? _clientID;

        public ClientForm(FormMode mode = FormMode.AddNew, int? clientID = null)
        {
            InitializeComponent();
            Mode = mode;
            _clientID = clientID;
            if (clientID.HasValue)
                LoadClientDataAsync(clientID.Value);
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
                        txtFullName.Text = client.FullName ?? "";
                        txtEmail.Text = client.Email ?? "";
                        txtPhone.Text = client.Phone ?? "";
                        txtAddress.Text = client.Address ?? "";
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

        private async Task<bool> ValidateInputs()
        {
            bool isValid = true;

            // Trim inputs
            txtFullName.Text = txtFullName.Text.Trim();
            txtEmail.Text = txtEmail.Text.Trim();
            txtAddress.Text = txtAddress.Text.Trim();
            txtPhone.Text = txtPhone.Text.Trim();

            // Normalize Phone
            if (!string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                // Remove non-digits
                string digits = Regex.Replace(txtPhone.Text, @"[^\d]", "");
                if (digits.Length == 10)
                {
                    txtPhone.Text = $"{digits.Substring(0, 3)}-{digits.Substring(3, 3)}-{digits.Substring(6, 4)}";
                }
                else
                {
                    errorProvider.SetError(txtPhone, "Phone must have 10 digits");
                    isValid = false;
                }
            }

            // Validate fields
            isValid &= ValidateField(txtFullName, txtFullName.Text, "Full Name is required");
            isValid &= ValidateField(txtEmail, txtEmail.Text, "Email is required");
            isValid &= ValidateField(txtPhone, txtPhone.Text, "Phone is required");
            isValid &= ValidateField(txtAddress, txtAddress.Text, "Address is required");

            // Email format validation
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) &&
                !Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errorProvider.SetError(txtEmail, "Invalid email format");
                isValid = false;
            }

            // Phone format validation
            if (!string.IsNullOrWhiteSpace(txtPhone.Text) &&
                !Regex.IsMatch(txtPhone.Text, @"^\d{3}-\d{3}-\d{4}$"))
            {
                errorProvider.SetError(txtPhone, "Invalid phone format (e.g., 123-456-7890)");
                isValid = false;
            }

            // Duplicate Email check
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                var response = await ApiClient.Client.GetAsync($"Client/Filter?field=Email&value={Uri.EscapeDataString(txtEmail.Text)}");
                if (response.IsSuccessStatusCode)
                {
                    var clients = await response.Content.ReadFromJsonAsync<List<Client>>();
                    if (clients != null && clients.Any(c => c.ClientID != _clientID))
                    {
                        errorProvider.SetError(txtEmail, "Email already exists");
                        isValid = false;
                    }
                }
            }

            // Duplicate Phone check
            if (!string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                var response = await ApiClient.Client.GetAsync($"Client/Filter?field=Phone&value={Uri.EscapeDataString(txtPhone.Text)}");
                if (response.IsSuccessStatusCode)
                {
                    var clients = await response.Content.ReadFromJsonAsync<List<Client>>();
                    if (clients != null && clients.Any(c => c.ClientID != _clientID))
                    {
                        errorProvider.SetError(txtPhone, "Phone already in use");
                        isValid = false;
                    }
                }
            }

            return isValid;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await SaveClientAsync();
        }

        private async Task SaveClientAsync()
        {
            try
            {
                if (!await ValidateInputs()) return;

                var client = new Client
                {
                    ClientID = _clientID ?? 0,
                    FullName = txtFullName.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text,
                    Address = txtAddress.Text
                };

                var response = Mode == FormMode.AddNew
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

        private void ClientForm_Load(object sender, EventArgs e)
        {
            Text = Mode == FormMode.AddNew ? "Bank System - Add New Client" : "Bank System - Update Client";
        }

        private void txtFullName_Leave(object sender, EventArgs e)
        {
            txtFullName.Text = txtFullName.Text.Trim();
            ValidateField(txtFullName, txtFullName.Text, "Full Name is required");
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            txtEmail.Text = txtEmail.Text.Trim();
            ValidateField(txtEmail, txtEmail.Text, "Email is required");
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) &&
                !Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errorProvider.SetError(txtEmail, "Invalid email format");
            }
            else if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, "");
            }
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            txtPhone.Text = txtPhone.Text.Trim();
            ValidateField(txtPhone, txtPhone.Text, "Phone is required");
            if (!string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                // Normalize Phone
                string digits = Regex.Replace(txtPhone.Text, @"[^\d]", "");
                if (digits.Length == 10)
                {
                    txtPhone.Text = $"{digits.Substring(0, 3)}-{digits.Substring(3, 3)}-{digits.Substring(6, 4)}";
                    errorProvider.SetError(txtPhone, "");
                }
                else
                {
                    errorProvider.SetError(txtPhone, "Phone must have 10 digits");
                }
            }
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            txtAddress.Text = txtAddress.Text.Trim();
            ValidateField(txtAddress, txtAddress.Text, "Address is required");
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits, -, (), space
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != '(' &&
                        e.KeyChar != ')' && e.KeyChar != ' ' && !char.IsControl(e.KeyChar);
        }
    }
}