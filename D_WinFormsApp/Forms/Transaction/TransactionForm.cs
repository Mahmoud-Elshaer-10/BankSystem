using D_WinFormsApp.Helpers;
using D_WinFormsApp.Models;
using System.Net.Http.Json;

namespace D_WinFormsApp
{
    public partial class TransactionForm : MyForm
    {
        private readonly int _accountId;
        private readonly FormMode _mode;

        public TransactionForm(int accountId, FormMode mode = FormMode.AddNew)
        {
            InitializeComponent();
            _accountId = accountId;
            _mode = mode;
            txtFromAccountID.Text = _accountId.ToString();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await SaveTransactionAsync();
        }

        private async Task SaveTransactionAsync()
        {
            try
            {
                if (!ValidateInputs()) return;

                var transaction = new Transaction
                {
                    FromAccountID = int.Parse(txtFromAccountID.Text),
                    TransactionType = cbTransactionType.SelectedItem?.ToString(),
                    Amount = decimal.Parse(txtAmount.Text),
                    ToAccountID = string.IsNullOrWhiteSpace(txtToAccountID.Text) ? null : int.Parse(txtToAccountID.Text)
                };

                var response = await ApiClient.Client.PostAsJsonAsync("Transaction", transaction);

                if (response.IsSuccessStatusCode)
                {
                    ShowMessage("Transaction saved successfully.");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    ShowMessage("Failed to save transaction.");
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private bool ValidateInputs()
        {
            bool isValid = true;

            txtAmount.Text = txtAmount.Text.Trim();
            txtToAccountID.Text = txtToAccountID.Text.Trim();

            isValid &= ValidateField(txtFromAccountID, txtFromAccountID.Text, "From Account ID is required");
            if (isValid && (!int.TryParse(txtFromAccountID.Text, out int fromAccountId) || fromAccountId < 1))
            {
                errorProvider.SetError(txtFromAccountID, "Invalid From Account ID");
                isValid = false;
            }

            isValid &= ValidateField(cbTransactionType, cbTransactionType.SelectedItem?.ToString() ?? "", "Transaction Type is required");

            isValid &= ValidateField(txtAmount, txtAmount.Text, "Amount is required");
            if (isValid && (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0))
            {
                errorProvider.SetError(txtAmount, "Amount must be a positive number");
                isValid = false;
            }

            if (cbTransactionType.SelectedItem?.ToString() == "Transfer")
            {
                isValid &= ValidateField(txtToAccountID, txtToAccountID.Text, "To Account ID is required for transfers");
                if (isValid && (!int.TryParse(txtToAccountID.Text, out int toAccountId) || toAccountId < 1))
                {
                    errorProvider.SetError(txtToAccountID, "Invalid To Account ID");
                    isValid = false;
                }
                else if (isValid && int.Parse(txtToAccountID.Text) == _accountId)
                {
                    errorProvider.SetError(txtToAccountID, "To Account ID cannot be the same as From Account ID");
                    isValid = false;
                }
            }
            else
            {
                errorProvider.SetError(txtToAccountID, "");
            }

            return isValid;
        }

        private void TransactionForm_Load(object sender, EventArgs e)
        {
            Text = _mode == FormMode.AddNew ? "Bank System - Add Transaction" : "Bank System - Update Transaction";
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            txtAmount.Text = txtAmount.Text.Trim();
            ValidateField(txtAmount, txtAmount.Text, "Amount is required");
            if (!string.IsNullOrWhiteSpace(txtAmount.Text) &&
                (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0))
            {
                errorProvider.SetError(txtAmount, "Amount must be a positive number");
            }
            else if (!string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                errorProvider.SetError(txtAmount, "");
            }
        }

        private void txtToAccountID_Leave(object sender, EventArgs e)
        {
            txtToAccountID.Text = txtToAccountID.Text.Trim();
            if (cbTransactionType.SelectedItem?.ToString() == "Transfer")
            {
                ValidateField(txtToAccountID, txtToAccountID.Text, "To Account ID is required for transfers");
                if (!string.IsNullOrWhiteSpace(txtToAccountID.Text) &&
                    (!int.TryParse(txtToAccountID.Text, out int toAccountId) || toAccountId < 1))
                {
                    errorProvider.SetError(txtToAccountID, "Invalid To Account ID");
                }
                else if (!string.IsNullOrWhiteSpace(txtToAccountID.Text) && int.Parse(txtToAccountID.Text) == _accountId)
                {
                    errorProvider.SetError(txtToAccountID, "To Account ID cannot be the same as From Account ID");
                }
                else if (!string.IsNullOrWhiteSpace(txtToAccountID.Text))
                {
                    errorProvider.SetError(txtToAccountID, "");
                }
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar)) ||
                        (e.KeyChar == '.' && txtAmount.Text.Contains('.'));
        }

        private void txtToAccountID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtToAccountID.Visible = cbTransactionType.SelectedItem?.ToString() == "Transfer";
            lblToAccountID.Visible = txtToAccountID.Visible;
            if (!txtToAccountID.Visible)
            {
                txtToAccountID.Text = "";
                errorProvider.SetError(txtToAccountID, "");
            }
        }
    }
}