using D_WinFormsApp.Helpers;
using D_WinFormsApp.Models;
using System.Net.Http.Json;

namespace D_WinFormsApp
{
    public partial class TransactionListForm : MyForm
    {
        private readonly int _accountId;

        public TransactionListForm(int accountId)
        {
            _accountId = accountId;
            InitializeComponent();

            SetupFilterToolTips(cbFilterBy, txtFilterValue, btnClearFilter);
            PopulateFilterDropdown<Transaction>(cbFilterBy);
            ConfigureFilterDebounce<Transaction>(txtFilterValue, cbFilterBy, dgvTransactions, LoadTransactionsAsync, dtpFilter);
            EnableSorting<Transaction>(dgvTransactions);
        }

        private void TransactionListForm_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0; // Default to "None"
            txtFilterValue.Text = ""; // Clear filter
        }

        private async Task<List<Transaction>> LoadTransactionsAsync(string field, string value)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string url = $"Transaction/ByAccount/{_accountId}";
                if (!string.IsNullOrEmpty(field) && !string.IsNullOrEmpty(value))
                {
                    url += $"?field={Uri.EscapeDataString(field)}&value={Uri.EscapeDataString(value)}";
                }

                var response = await ApiClient.Client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var transactions = await response.Content.ReadFromJsonAsync<List<Transaction>>();
                    dgvTransactions.DataSource = transactions ?? new List<Transaction>();
                    lblRecordsCount.Text = $"Records: {dgvTransactions.RowCount}";
                    AutoResizeFormToDataGridView(dgvTransactions);
                    return transactions ?? [];
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    dgvTransactions.DataSource = new List<Transaction>();
                    lblRecordsCount.Text = $"Records: {dgvTransactions.RowCount}";
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
                Cursor = Cursors.Default;
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None") && (cbFilterBy.Text != "Transaction Date");
            btnClearFilter.Visible = txtFilterValue.Visible;
            dtpFilter.Visible = cbFilterBy.Text == "Transaction Date";
            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
            else
            {
                _ = LoadTransactionsAsync("", "");
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Transaction ID" || cbFilterBy.Text == "From Account ID" || cbFilterBy.Text == "To Account ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void AddTransaction()
        {
            using var form = new TransactionForm(_accountId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _ = LoadTransactionsAsync("", "");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddTransaction();
        }

        private void addTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTransaction();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToCsv<Transaction>(dgvTransactions, "transactions.csv");
        }

        private void exportToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToCsv<Transaction>(dgvTransactions, "transactions.csv");
        }
    }
}