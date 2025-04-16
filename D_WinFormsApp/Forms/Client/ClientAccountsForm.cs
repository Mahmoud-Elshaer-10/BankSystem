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
                        InvokeIfNeeded(() => dgvAccounts.DataSource = accounts);
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
    }
}