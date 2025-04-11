using D_WinFormsApp.Controls;
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
            ConfigureFilterDebounce(txtFilterValue, cbFilterBy, lblRecordsCount, dgvAccounts, LoadAccountsAsync);
        }

        private async void AccountListForm_Load(object sender, EventArgs e)
        {
            await LoadAccountsAsync(null, null); // Load all accounts initially
            cbFilterBy.SelectedIndex = 0; // Default to "None"
        }

        private async Task<List<Account>> LoadAccountsAsync(string field, string value)
        {
            try
            {
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
                    if (accounts != null && accounts.Count > 0)
                    {
                        InvokeIfNeeded(() =>
                        {
                            dgvAccounts.DataSource = accounts;
                            lblRecordsCount.Text = $"Records: {dgvAccounts.RowCount}";
                        });
                        return accounts;
                    }
                    else
                    {
                        ShowMessage("No accounts found.");
                        return new List<Account>();
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    ShowMessage("No accounts found.");
                    return new List<Account>();
                }
                else
                {
                    throw new HttpRequestException($"API call failed with status: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
                return new List<Account>();
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
                _ = LoadAccountsAsync(null, null); // Reset to full list when "None" is selected
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
            // No need to manually reset grid here; TextChanged will handle it

        }

        private void AddAccount()
        {
            using (var form = new AccountForm(FormMode.AddNew))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _ = LoadAccountsAsync(null, null); // Refresh full list
                }
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
                using (var form = new AccountForm(FormMode.Update, selectedAccount.AccountID))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        _ = LoadAccountsAsync(null, null); // Refresh full list
                    }
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
                var result = ShowMessage($"Delete account for Client ID '{selectedAccount.ClientID}'?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var response = await ApiClient.Client.DeleteAsync($"Account/{selectedAccount.AccountID}");
                    if (response.IsSuccessStatusCode)
                    {
                        await LoadAccountsAsync(null, null); // Refresh full list
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
    }
}