using D_WinFormsApp.Helpers;
using D_WinFormsApp.Models;
using System.Net.Http.Json;

namespace D_WinFormsApp
{
    public partial class AccountListForm : MyForm
    {
        private bool isLoading = false;

        public AccountListForm()
        {
            InitializeComponent();
            SetupFilterToolTips(cbFilterBy, txtFilterValue, btnClearFilter);
            PopulateFilterDropdown<Account>(cbFilterBy);
            ConfigureFilterDebounce<Account>(txtFilterValue, cbFilterBy, dgvAccounts, lblRecordsCount, "Account", dtpFilter);
            EnableSorting<Account>(dgvAccounts);
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
            isLoading = true;
            cbCurrentPage.Items.Clear();
            for (int i = 1; i <= TotalPages; i++)
                cbCurrentPage.Items.Add(i);
            if (TotalPages > 0)
                cbCurrentPage.SelectedIndex = CurrentPage - 1;
            else
                cbCurrentPage.Text = "";
            isLoading = false;
        }

        private void AccountListForm_Load(object sender, EventArgs e)
        {
            try
            {
                isLoading = true;
                cbFilterBy.SelectedIndex = 0;
                txtFilterValue.Text = "";
                txtRowsPerPage.Text = RowsPerPage.ToString();
                isLoading = false;
                _ = LoadPagedDataAsync<Account>(dgvAccounts, lblRecordsCount, "Account");
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
            if (cbFilterBy.Text == "Account ID" || cbFilterBy.Text == "Client ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            else if (cbFilterBy.Text == "Balance")
                e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar);
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
                _ = LoadPagedDataAsync<Account>(dgvAccounts, lblRecordsCount, "Account");
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
                _ = LoadPagedDataAsync<Account>(dgvAccounts, lblRecordsCount, "Account");
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
            CurrentPage = 1;
            _ = LoadPagedDataAsync<Account>(dgvAccounts, lblRecordsCount, "Account");
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (CurrentPage < TotalPages)
            {
                CurrentPage++;
                _ = LoadPagedDataAsync<Account>(dgvAccounts, lblRecordsCount, "Account");
            }
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
                _ = LoadPagedDataAsync<Account>(dgvAccounts, lblRecordsCount, "Account");
            }
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            CurrentPage = 1;
            _ = LoadPagedDataAsync<Account>(dgvAccounts, lblRecordsCount, "Account");
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            CurrentPage = TotalPages;
            _ = LoadPagedDataAsync<Account>(dgvAccounts, lblRecordsCount, "Account");
        }

        private void AddAccount()
        {
            using var form = new AccountForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                CurrentPage = 1;
                _ = LoadPagedDataAsync<Account>(dgvAccounts, lblRecordsCount, "Account");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddAccount();
        }

        private void addAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAccount();
        }

        private void EditAccount()
        {
            if (ValidateSelection(dgvAccounts, out object selected) && selected is Account selectedAccount)
            {
                using var form = new AccountForm(FormMode.Update, selectedAccount.AccountID);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _ = LoadPagedDataAsync<Account>(dgvAccounts, lblRecordsCount, "Account");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditAccount();
        }

        private void editAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditAccount();
        }

        private async void DeleteAccount()
        {
            if (ValidateSelection(dgvAccounts, out object selected) && selected is Account selectedAccount)
            {
                var result = ShowMessage($"Delete account '{selectedAccount.AccountID}'?", "Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var response = await ApiClient.Client.DeleteAsync($"Account/{selectedAccount.AccountID}");
                    if (response.IsSuccessStatusCode)
                    {
                        await LoadPagedDataAsync<Account>(dgvAccounts, lblRecordsCount, "Account");
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteAccount();
        }

        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteAccount();
        }

        private void ShowClient()
        {
            if (ValidateSelection(dgvAccounts, out object selected) && selected is Account selectedAccount)
            {
                using (var form = new ClientForm(FormMode.Update, selectedAccount.ClientID))
                {
                    form.ShowDialog();
                }
            }
        }

        private void btnShowClient_Click(object sender, EventArgs e)
        {
            ShowClient();
        }

        private void showClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowClient();
        }

        private void dgvAccounts_DoubleClick(object sender, EventArgs e)
        {
            ShowClient();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToCsv<Account>(dgvAccounts, "accounts.csv");
        }

        private void exportToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToCsv<Account>(dgvAccounts, "accounts.csv");
        }
    }
}