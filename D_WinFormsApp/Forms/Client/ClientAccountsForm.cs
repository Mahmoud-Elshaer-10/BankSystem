using D_WinFormsApp.Helpers;
using D_WinFormsApp.Models;
using System.Net.Http.Json;

namespace D_WinFormsApp
{
    public partial class ClientAccountsForm : MyForm
    {
        private readonly int _clientId;

        public ClientAccountsForm(int clientId)
        {
            InitializeComponent();
            _clientId = clientId;
            EnableSorting<Account>(dgvAccounts);
        }

        private void ClientAccountsForm_Load(object sender, EventArgs e)
        {
            _ = LoadAccountsAsync();
        }

        private async Task LoadAccountsAsync()
        {
            try
            {
                var response = await ApiClient.Client.GetAsync($"Account/ByClient/{_clientId}");
                if (response.IsSuccessStatusCode)
                {
                    var accounts = await response.Content.ReadFromJsonAsync<List<Account>>();
                    if (accounts != null && accounts.Count > 0)
                    {
                        dgvAccounts.DataSource = accounts;
                        AutoResizeFormToDataGridView(dgvAccounts);
                    }
                    else
                    {
                        ShowMessage("No accounts found for this client.");
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    ShowMessage("No accounts found for this client.");
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void ShowTransactions()
        {
            if (ValidateSelection(dgvAccounts, out object selected) && selected is Account selectedAccount)
            {
                using var form = new TransactionListForm(selectedAccount.AccountID);
                form.ShowDialog();
            }
        }

        private void btnShowTransactions_Click(object sender, EventArgs e)
        {
            ShowTransactions();
        }

        private void showTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowTransactions();
        }

        private void dgvAccounts_DoubleClick(object sender, EventArgs e)
        {
            ShowTransactions();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var form = new AccountForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _ = LoadAccountsAsync();
            }
        }
    }
}