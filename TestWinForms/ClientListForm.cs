using D_WinFormsApp.Helpers;
using D_WinFormsApp.Models;
using System.Net.Http.Json;

namespace D_WinFormsApp
{
    public partial class ClientListForm : MyForm
    {
        

        public ClientListForm()
        {
            InitializeComponent();

            SetupFilterToolTips(cbFilterBy, txtFilterValue, btnClearFilter);
            PopulateFilterDropdown<Client>(cbFilterBy);
            ConfigureFilterDebounce<Client>(txtFilterValue, cbFilterBy, dgvClients, lblRecordsCount, "Client", dtpFilter);
            EnableSorting<Client>(dgvClients);
            SetupPaginationControls();
        }

        private void SetupPaginationControls()
        {
            // Assume btnNextPage, btnPrevPage, btnFirstPage, btnLastPage are defined in Designer
            btnFirstPage.Click += btnFirstPage_Click;
            btnLastPage.Click += btnLastPage_Click;

            // Configure rows per page dropdown
            cbRowsPerPage.Items.AddRange(new object[] { 3, 5, 10 });
            cbRowsPerPage.SelectedIndex = 0; // Default to 10
            //cbRowsPerPage.Size = new Size(60, 25);
            //cbRowsPerPage.Location = new Point(310, ClientSize.Height - 60); // Adjust as needed
            cbRowsPerPage.SelectedIndexChanged += cbRowsPerPage_SelectedIndexChanged;
            

            // Configure page info label
            lblPageInfo.Location = new Point(10, ClientSize.Height - 30);
        }

        protected override void UpdatePaginationButtons()
        {
            btnPrevPage.Enabled = CurrentPage > 1;
            btnFirstPage.Enabled = CurrentPage > 1;
            btnNextPage.Enabled = CurrentPage < TotalPages;
            btnLastPage.Enabled = CurrentPage < TotalPages && TotalPages > 0;
        }

        private void ClientListForm_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0; // Default to "None"
            txtFilterValue.Text = ""; // Clear filter
            _ = LoadPagedDataAsync<Client>(dgvClients, lblRecordsCount, "Client");
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None") && (cbFilterBy.Text != "Created At");
            btnClearFilter.Visible = txtFilterValue.Visible;
            dtpFilter.Visible = cbFilterBy.Text == "Created At";
            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
            else
            {
                CurrentPage = 1;
                _ = LoadPagedDataAsync<Client>(dgvClients, lblRecordsCount, "Client");
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // we allow number only incase Client ID or Phone is selected.
            if (cbFilterBy.Text == "Client ID" || cbFilterBy.Text == "Phone")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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

        private void cbRowsPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            RowsPerPage = (int)cbRowsPerPage.SelectedItem;
            CurrentPage = 1;
            _ = LoadPagedDataAsync<Client>(dgvClients, lblRecordsCount, "Client");
        }

        private void ShowClientAccounts()
        {
            //if (ValidateSelection(dgvClients, out object selected) && selected is Client selectedClient)
            //{
            //    using var form = new ClientAccountsForm(selectedClient.ClientID);
            //    form.ShowDialog();
            //}
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
            //using var form = new ClientForm();
            //if (form.ShowDialog() == DialogResult.OK)
            //{
            //    CurrentPage = 1;
            //    _ = LoadPagedDataAsync<Client>(dgvClients, lblRecordsCount, "Client");
            //}
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
            //if (ValidateSelection(dgvClients, out object selected) && selected is Client selectedClient)
            //{
            //    using var form = new ClientForm(FormMode.Update, selectedClient.ClientID);
            //    if (form.ShowDialog() == DialogResult.OK)
            //    {
            //        _ = LoadPagedDataAsync<Client>(dgvClients, lblRecordsCount, "Client");
            //    }
            //}
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