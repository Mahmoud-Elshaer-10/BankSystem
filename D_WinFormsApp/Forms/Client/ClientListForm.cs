using D_WinFormsApp.Helpers;
using D_WinFormsApp.Models;
using System.Net.Http.Json;
using D_WinFormsApp.Controls;

namespace D_WinFormsApp
{
    public partial class ClientListForm : MyForm
    {
        public ClientListForm()
        {
            InitializeComponent();

            SetupFilterToolTips(cbFilterBy, txtFilterValue, btnClearFilter);
            PopulateFilterDropdown<Client>(cbFilterBy);
            ConfigureFilterDebounce(txtFilterValue, cbFilterBy, lblRecordsCount, dgvClients, LoadClientsAsync);
        }

        private async void ClientListForm_Load(object sender, EventArgs e)
        {
            await LoadClientsAsync(null, null); // Load all clients initially
            cbFilterBy.SelectedIndex = 0; // Default to "None"
        }

        private async Task<List<Client>> LoadClientsAsync(string field, string value)
        {
            try
            {
                HttpResponseMessage response;
                if (string.IsNullOrEmpty(field) || string.IsNullOrEmpty(value))
                {
                    response = await ApiClient.Client.GetAsync("Client/All");
                }
                else
                {
                    string url = $"Client/Filter?field={Uri.EscapeDataString(field)}&value={Uri.EscapeDataString(value)}";
                    response = await ApiClient.Client.GetAsync(url);
                }

                if (response.IsSuccessStatusCode)
                {
                    var clients = await response.Content.ReadFromJsonAsync<List<Client>>();
                    if (clients != null && clients.Count > 0)
                    {
                        // Invoke ensures the code runs on the UI thread, since UI updates (like changing the DataGridView content) need to be done on the main thread.
                        InvokeIfNeeded(() =>
                        {
                            dgvClients.DataSource = clients;
                            lblRecordsCount.Text = $"Records: {dgvClients.RowCount}";
                        });
                        return clients;
                    }
                    else
                    {
                        ShowMessage("No clients found.");
                        return new List<Client>();
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    ShowMessage("No clients found.");
                    return new List<Client>();
                }
                else
                {
                    throw new HttpRequestException($"API call failed with status: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
                return new List<Client>();
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");
            btnClearFilter.Visible = txtFilterValue.Visible;
            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
            else
            {
                _ = LoadClientsAsync(null, null); // Reset to full list when "None" is selected
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // we allow number only incase Client ID is selected.
            if (cbFilterBy.Text == "Client ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
            // No need to manually reset grid here, TextChanged will handle it
        }

        private void ShowClientAccounts()
        {
            if (ValidateSelection(dgvClients, out object selected) && selected is Client selectedClient)
            {
                using (var form = new ClientAccountsForm(selectedClient.ClientID))
                {
                    form.ShowDialog();
                }
            }
        }

        private void dgvClients_DoubleClick(object sender, EventArgs e)
        {
            ShowClientAccounts();
        }

        private void btnShowAccounts_Click(object sender, EventArgs e)
        {
            ShowClientAccounts();
        }

        private void showAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowClientAccounts();
        }

        private void AddClient()
        {
            using (var form = new ClientForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _ = LoadClientsAsync(null, null); // Fire and forget, Refresh full list
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddClient();
        }

        private void addClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddClient();
        }

        private void EditClient()
        {
            if (ValidateSelection(dgvClients, out object selected) && selected is Client selectedClient)
            {
                using (var form = new ClientForm(FormMode.Update, selectedClient.ClientID))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        _ = LoadClientsAsync(null, null); // Refresh full list
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditClient();
        }

        private void editClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditClient();
        }

        private async void DeleteClient()
        {
            if (ValidateSelection(dgvClients, out object selected) && selected is Client selectedClient)
            {
                var result = ShowMessage($"Delete client '{selectedClient.FullName}'?", "Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var response = await ApiClient.Client.DeleteAsync($"Client/{selectedClient.ClientID}");
                    if (response.IsSuccessStatusCode)
                    {
                        await LoadClientsAsync(null, null); // Refresh full list
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteClient();
        }

        private void deleteClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteClient();
        }
    }
}