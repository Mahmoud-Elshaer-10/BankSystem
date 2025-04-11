using D_WinFormsApp.Helpers;
using D_WinFormsApp.Models;
using System.Net.Http.Json;

namespace D_WinFormsApp
{
    public partial class AccountForm : MyForm
    {
        public FormMode Mode { get; set; }
        private readonly int? _accountID;

        public AccountForm(FormMode mode = FormMode.AddNew, int? accountID = null)
        {
            InitializeComponent();
            Mode = mode;
            _accountID = accountID;
            if (accountID.HasValue)
            {
                LoadAccountDataAsync(accountID.Value);
            }
        }

        private async void LoadAccountDataAsync(int accountID)
        {
            try
            {
                var response = await ApiClient.Client.GetAsync($"Account/{accountID}");
                if (response.IsSuccessStatusCode)
                {
                    var account = await response.Content.ReadFromJsonAsync<Account>();
                    if (account != null)
                    {
                        InvokeIfNeeded(() =>
                        {
                            txtBalance.Text = account.Balance.ToString("0.00");
                            txtClientID.Text = account.ClientID.ToString();
                        });
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    ShowMessage("Account not found.");
                    Close();
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
                Close();
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await SaveAccountAsync();
        }

        private async Task SaveAccountAsync()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBalance.Text) || string.IsNullOrWhiteSpace(txtClientID.Text))
                {
                    ShowMessage("Please fill all required fields.");
                    return;
                }

                int clientID = Convert.ToInt32(txtClientID.Text);
                var clientCheck = await ApiClient.Client.GetAsync($"Client/{clientID}");
                if (!clientCheck.IsSuccessStatusCode)
                {
                    ShowMessage("Invalid ClientID. Client does not exist.");
                    return;
                }

                var account = new Account
                {
                    AccountID = _accountID ?? 0,
                    ClientID = clientID,
                    Balance = decimal.Parse(txtBalance.Text)
                };

                HttpResponseMessage response = Mode == FormMode.AddNew
                    ? await ApiClient.Client.PostAsJsonAsync("Account", account)
                    : await ApiClient.Client.PutAsJsonAsync($"Account/{account.AccountID}", account);

                if (response.IsSuccessStatusCode)
                {
                    ShowMessage("Account saved successfully.");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    ShowMessage("Failed to save account.");
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            Text = Mode == FormMode.AddNew ? "Bank System - Add New Account" : "Bank System - Update Account";
        }
    }
}