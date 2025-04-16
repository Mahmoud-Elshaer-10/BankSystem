using D_WinFormsApp.Controls;
using D_WinFormsApp.Helpers;
using D_WinFormsApp.Models;
using System.Net.Http.Json;
using System.Text;

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
            await LoadClientsAsync("", ""); // Load all clients initially
            cbFilterBy.SelectedIndex = 0; // Default to "None"
            txtFilterValue.Text = ""; // Clear filter
        }

        private async Task<List<Client>> LoadClientsAsync(string field, string value)
        {
            try
            {
                Cursor = Cursors.WaitCursor; // Add loading indicator
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
                    // Invoke ensures the code runs on the UI thread, since UI updates (like changing the DataGridView content) need to be done on the main thread.
                    InvokeIfNeeded(() =>
                    {
                        dgvClients.DataSource = clients ?? new List<Client>();
                        lblRecordsCount.Text = $"Records: {dgvClients.RowCount}";
                    });
                    return clients ?? new List<Client>();
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    InvokeIfNeeded(() => ShowMessage("No clients found."));
                    return new List<Client>();
                }
                else
                {
                    throw new HttpRequestException($"API call failed with status: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                InvokeIfNeeded(() => ShowError(ex.Message));
                return new List<Client>();
            }
            finally
            {
                Cursor = Cursors.Default; // Reset cursor
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
                _ = LoadClientsAsync("", ""); // Reset to full list when "None" is selected
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
            dgvClients.DataSource = null;
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
                    _ = LoadClientsAsync("", ""); // Fire and forget, Refresh full list
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
                        _ = LoadClientsAsync("", ""); // Refresh full list
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
                        await LoadClientsAsync("", ""); // Refresh full list
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToCsv<Client>(dgvClients, "clients.csv");
        }

        private void exportToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToCsv<Client>(dgvClients, "clients.csv");
        }

    }
}