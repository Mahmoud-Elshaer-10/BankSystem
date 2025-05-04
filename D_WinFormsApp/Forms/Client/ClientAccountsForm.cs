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

        private async void ClientAccountsForm_Load(object sender, EventArgs e)
        {
            await LoadAccountsAsync();
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

        private void dgvAccounts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.Value == null)
                return;
            var column = dgvAccounts.Columns[e.ColumnIndex];
            if (column.DataPropertyName == "Balance")
            {
                if (e.Value is decimal balance)
                    e.Value = balance.ToString("C2"); // e.g., $100.50
                e.FormattingApplied = true;
            }
        }
    }
}