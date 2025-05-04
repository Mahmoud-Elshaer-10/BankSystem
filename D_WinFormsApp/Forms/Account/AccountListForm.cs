using D_WinFormsApp.Helpers;
using D_WinFormsApp.Models;
using System.Net.Http.Json;

namespace D_WinFormsApp
{
    public partial class AccountListForm : MyForm
    {
        public AccountListForm()
        {
            InitializeComponent();

            SetupFilterToolTips(cbFilterBy, txtFilterValue, btnClearFilter);
            PopulateFilterDropdown<Account>(cbFilterBy);
            ConfigureFilterDebounce(txtFilterValue, cbFilterBy, dgvAccounts, LoadAccountsAsync, dtpFilter);
            EnableSorting<Account>(dgvAccounts);
        }

        private async void AccountListForm_Load(object sender, EventArgs e)
        {
            await LoadAccountsAsync("", "");
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Text = "";
        }

        /// <summary>
        /// Loads accounts from the API and updates the grid.
        /// </summary>
        private async Task<List<Account>> LoadAccountsAsync(string field, string value)
        {
            try
            {
                Cursor = Cursors.WaitCursor; // Add loading indicator
                HttpResponseMessage response;
                if (string.IsNullOrEmpty(field) || string.IsNullOrEmpty(value))
                {
                    response = await ApiClient.Client.GetAsync("Account/All");
                }
                else
                {
                    string url = $"Account/Filter?field={Uri.EscapeDataString(field)}&value={Uri.EscapeDataString(value)}";
                    response = await ApiClient.Client.GetAsync(url);
                }

                if (response.IsSuccessStatusCode)
                {
                    var accounts = await response.Content.ReadFromJsonAsync<List<Account>>();
                    dgvAccounts.DataSource = accounts ?? [];
                    lblRecordsCount.Text = $"Records: {dgvAccounts.RowCount}";
                    AutoResizeFormToDataGridView(dgvAccounts);
                    return accounts ?? [];
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    dgvAccounts.DataSource = new List<Account>();
                    lblRecordsCount.Text = $"Records: {dgvAccounts.RowCount}";
                    return [];
                }
                else
                {
                    throw new HttpRequestException($"API call failed with status: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
                return [];
            }
            finally
            {
                Cursor = Cursors.Default; // Reset cursor
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None") && (cbFilterBy.Text != "Created At");
            dtpFilter.Visible = cbFilterBy.Text == "Created At";
            btnClearFilter.Visible = txtFilterValue.Visible;
            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
            else
            {
                _ = LoadAccountsAsync("", "");
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Account ID" || cbFilterBy.Text == "Client ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            else if (cbFilterBy.Text == "Balance")
                e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar);
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
            dgvAccounts.DataSource = null;
        }

        private void AddAccount()
        {
            using var form = new AccountForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _ = LoadAccountsAsync("", "");
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
                    _ = LoadAccountsAsync("", "");
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
                        await LoadAccountsAsync("", "");
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

        private void dgvAccounts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.Value == null)
                return;
            var column = dgvAccounts.Columns[e.ColumnIndex];
            if (column.DataPropertyName == "Balance")
            {
                if (e.Value is decimal balance)
                {
                    //e.Value = balance < 0 ? $"-{balance:C2}" : balance.ToString("C2"); // e.g., -($100.50) or $100.50
                    e.Value = balance.ToString("$#,##0.00"); // e.g., -$100.50 or $100.50
                                                             // Safe: Color.Red and Color.DarkGreen are non-null
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    e.CellStyle.ForeColor = balance < 0 ? Color.Red : Color.DarkGreen;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    e.FormattingApplied = true;
                }
            }
            //else if (column.DataPropertyName == "CreatedAt")
            //{
            //    if (e.Value is DateTime createdAt)
            //    {
            //        e.Value = createdAt.ToString("MM/dd/yyyy"); // e.g., 04/17/2025
            //        e.FormattingApplied = true;
            //    }
            //}
        }
    }
}