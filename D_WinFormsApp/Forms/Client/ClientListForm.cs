using D_WinFormsApp.Helpers;
using D_WinFormsApp.Models;

namespace D_WinFormsApp
{
    public partial class ClientListForm : MyForm
    {
        private bool isLoading = false; // Prevents event loop during initialization

        public ClientListForm()
        {
            InitializeComponent();

            SetupFilterToolTips(cbFilterBy, txtFilterValue, btnClearFilter);
            PopulateFilterDropdown<Client>(cbFilterBy);
            ConfigureFilterDebounce<Client>(txtFilterValue, cbFilterBy, dgvClients, lblRecordsCount, "Client", dtpFilter);
            EnableSorting<Client>(dgvClients);
        }


        protected override void UpdatePaginationButtons()
        {
            btnFirstPage.Enabled = CurrentPage > 1;
            btnPrevPage.Enabled = CurrentPage > 1;
            btnNextPage.Enabled = CurrentPage < TotalPages;
            btnLastPage.Enabled = CurrentPage < TotalPages;
            UpdatePageDropdown();
        }

        private void UpdatePageDropdown()
        {
            isLoading = true; // Suppress SelectedIndexChanged
            cbCurrentPage.Items.Clear();
            for (int i = 1; i <= TotalPages; i++)
                cbCurrentPage.Items.Add(i);
            if (TotalPages > 0)
                cbCurrentPage.SelectedIndex = CurrentPage - 1;
            else
                cbCurrentPage.Text = "";
            isLoading = false;
        }

        private void ClientListForm_Load(object sender, EventArgs e)
        {
            try
            {
                isLoading = true;
                cbFilterBy.SelectedIndex = 0; // Default to "None"
                txtFilterValue.Text = ""; // Clear filter
                txtRowsPerPage.Text = RowsPerPage.ToString();
                isLoading = false;
                _ = LoadPagedDataAsync<Client>(dgvClients, lblRecordsCount, "Client");
            }
            catch (Exception ex)
            {
                ShowError($"Load error: {ex.Message}");
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            txtFilterValue.Visible = (cbFilterBy.Text != "None") && (cbFilterBy.Text != "Created At");
            btnClearFilter.Visible = txtFilterValue.Visible;
            dtpFilter.Visible = cbFilterBy.Text == "Created At";
            txtFilterValue.Text = "";
            if (txtFilterValue.Visible)
            {
                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // we allow number only incase Client ID or Phone is selected.
            if (cbFilterBy.Text == "Client ID" || cbFilterBy.Text == "Phone")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtRowsPerPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtRowsPerPage_TextChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            if (int.TryParse(txtRowsPerPage.Text, out int rows) && rows > 0)
            {
                errorProvider.SetError(txtRowsPerPage, "");
                RowsPerPage = rows;
                CurrentPage = 1;
                _ = LoadPagedDataAsync<Client>(dgvClients, lblRecordsCount, "Client");
            }
            else
            {
                errorProvider.SetError(txtRowsPerPage, "Enter a number greater than 0");
            }
        }

        private void cbCurrentPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            if (cbCurrentPage.SelectedIndex >= 0)
            {
                CurrentPage = cbCurrentPage.SelectedIndex + 1;
                _ = LoadPagedDataAsync<Client>(dgvClients, lblRecordsCount, "Client");
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
            CurrentPage = 1;
            _ = LoadPagedDataAsync<Client>(dgvClients, lblRecordsCount, "Client");
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (CurrentPage < TotalPages)
            {
                CurrentPage++;
                _ = LoadPagedDataAsync<Client>(dgvClients, lblRecordsCount, "Client");
            }
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
                _ = LoadPagedDataAsync<Client>(dgvClients, lblRecordsCount, "Client");
            }
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            CurrentPage = 1;
            _ = LoadPagedDataAsync<Client>(dgvClients, lblRecordsCount, "Client");
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            CurrentPage = TotalPages;
            _ = LoadPagedDataAsync<Client>(dgvClients, lblRecordsCount, "Client");
        }

        private void ShowClientAccounts()
        {
            if (ValidateSelection(dgvClients, out object selected) && selected is Client selectedClient)
            {
                using var form = new ClientAccountsForm(selectedClient.ClientID);
                form.ShowDialog();
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
            using var form = new ClientForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                CurrentPage = 1;
                _ = LoadPagedDataAsync<Client>(dgvClients, lblRecordsCount, "Client");
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
                using var form = new ClientForm(FormMode.Update, selectedClient.ClientID);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _ = LoadPagedDataAsync<Client>(dgvClients, lblRecordsCount, "Client");
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
                        CurrentPage = Math.Min(CurrentPage, TotalPages);
                        await LoadPagedDataAsync<Client>(dgvClients, lblRecordsCount, "Client");
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