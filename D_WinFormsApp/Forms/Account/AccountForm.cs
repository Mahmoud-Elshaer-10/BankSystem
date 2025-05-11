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

            // Add button tooltips to notify user of keyboard shortcuts
            toolTip.SetToolTip(btnSave, "Save (Alt+S)");
            toolTip.SetToolTip(btnCancel, "Cancel (Alt+C)");
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
                        txtBalance.Text = account.Balance.ToString("0.00") ?? "";
                        txtClientID.Text = account.ClientID.ToString() ?? "";
                    }
                    else
                    {
                        ShowMessage("Account data not found.");
                        Close();
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

        private bool ValidateInputs()
        {
            bool isValid = true;
            isValid &= ValidateField(txtBalance, txtBalance.Text, "Balance is required");
            isValid &= ValidateField(txtClientID, txtClientID.Text, "Client ID is required");

            // Balance format and range
            if (!string.IsNullOrWhiteSpace(txtBalance.Text) &&
                (!decimal.TryParse(txtBalance.Text, out decimal balance) || balance < 0))
            {
                errorProvider.SetError(txtBalance, "Balance must be a number >= 0");
                isValid = false;
            }

            // ClientID format
            if (!string.IsNullOrWhiteSpace(txtClientID.Text) &&
                !int.TryParse(txtClientID.Text, out _))
            {
                errorProvider.SetError(txtClientID, "Client ID must be a number");
                isValid = false;
            }

            return isValid;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await SaveAccountAsync();
        }

        private async Task SaveAccountAsync()
        {
            try
            {
                if (!ValidateInputs())
                {
                    return;
                }

                int clientID = int.Parse(txtClientID.Text);
                var clientCheck = await ApiClient.Client.GetAsync($"Client/{clientID}");
                if (!clientCheck.IsSuccessStatusCode)
                {
                    errorProvider.SetError(txtClientID, "Client does not exist");
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

        private void txtBalance_Leave(object sender, EventArgs e)
        {
            ValidateField(txtBalance, txtBalance.Text, "Balance is required");
            if (!string.IsNullOrWhiteSpace(txtBalance.Text) &&
                (!decimal.TryParse(txtBalance.Text, out decimal balance) || balance < 0))
            {
                errorProvider.SetError(txtBalance, "Balance must be a number >= 0");
            }
            else if (!string.IsNullOrWhiteSpace(txtBalance.Text))
            {
                errorProvider.SetError(txtBalance, "");
            }
        }

        private async void txtClientID_Leave(object sender, EventArgs e)
        {
            ValidateField(txtClientID, txtClientID.Text, "Client ID is required");
            if (!string.IsNullOrWhiteSpace(txtClientID.Text))
            {
                if (!int.TryParse(txtClientID.Text, out int clientID))
                {
                    errorProvider.SetError(txtClientID, "Client ID must be a number");
                }
                else
                {
                    try
                    {
                        var clientCheck = await ApiClient.Client.GetAsync($"Client/{clientID}");
                        errorProvider.SetError(txtClientID, clientCheck.IsSuccessStatusCode ? "" : "Client does not exist");
                    }
                    catch
                    {
                        errorProvider.SetError(txtClientID, "Error checking Client ID");
                    }
                }
            }
        }

        private void txtBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits and "."
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar);

        }

        private void txtClientID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}