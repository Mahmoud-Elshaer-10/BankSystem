using D_WinFormsApp.Helpers;
using System.Net.Http.Json;
using System.Text.Json;

namespace D_WinFormsApp
{
    public partial class DashboardForm : MyForm
    {
        public DashboardForm()
        {
            InitializeComponent();
            LoadDashboardAsync();
        }

        private async void LoadDashboardAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                // Initialize defaults
                int totalClients = 0;
                int totalAccounts = 0;
                decimal averageBalance = 0;
                decimal totalBalance = 0;

                // Fetch client summary
                var clientResponse = await ApiClient.Client.GetAsync("Client/Summary");
                if (clientResponse.IsSuccessStatusCode)
                {
                    var clientSummary = await clientResponse.Content.ReadFromJsonAsync<JsonElement>();
                    if (clientSummary.TryGetProperty("totalClients", out var totalClientsProp))
                    {
                        totalClients = totalClientsProp.GetInt32();
                    }
                }

                // Fetch account summary
                var accountResponse = await ApiClient.Client.GetAsync("Account/Summary");
                if (accountResponse.IsSuccessStatusCode)
                {
                    var accountSummary = await accountResponse.Content.ReadFromJsonAsync<JsonElement>();
                    if (accountSummary.TryGetProperty("totalAccounts", out var totalAccountsProp))
                    {
                        totalAccounts = totalAccountsProp.GetInt32();
                    }
                    if (accountSummary.TryGetProperty("averageBalance", out var avgBalanceProp))
                    {
                        averageBalance = avgBalanceProp.GetDecimal();
                    }
                    if (accountSummary.TryGetProperty("totalBalance", out var totalBalanceProp))
                    {
                        totalBalance = totalBalanceProp.GetDecimal();
                    }
                }

                // Update UI
                InvokeIfNeeded(() =>
                {
                    lblTotalClients.Text = $"Total Clients: {totalClients}";
                    lblTotalAccounts.Text = $"Total Accounts: {totalAccounts}";
                    lblAverageBalance.Text = $"Average Balance: {averageBalance:C2}";
                    lblTotalBalance.Text = $"Total Balance: {totalBalance:C2}";
                });
            }
            catch (Exception ex)
            {
                ShowError($"Failed to load dashboard: {ex.Message}");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}