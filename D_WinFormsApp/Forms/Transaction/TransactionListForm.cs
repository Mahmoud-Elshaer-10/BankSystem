using D_WinFormsApp.Controls;
using D_WinFormsApp.Helpers;
using D_WinFormsApp.Models;
using System.Net.Http.Json;

namespace D_WinFormsApp
{
    public partial class TransactionListForm : MyForm
    {
        private readonly int _accountId;
        private bool isLoading = false; // Prevents event loop during initialization

        public TransactionListForm(int accountId)
        {
            _accountId = accountId;
            InitializeComponent();

            SetupFilterToolTips(cbFilterBy, txtFilterValue, btnClearFilter);
            PopulateFilterDropdown<Transaction>(cbFilterBy);
            ConfigureFilterDebounce<Transaction>(txtFilterValue, cbFilterBy, dgvTransactions, lblRecordsCount, $"Transaction/paged/{_accountId}", dtpFilter);
            EnableSorting<Transaction>(dgvTransactions);
        }

        protected override void UpdatePaginationButtons()
        {
            btnFirstPage.Enabled = CurrentPage > 1;
            btnPrevPage.Enabled = CurrentPage > 1;
            btnNextPage.Enabled = CurrentPage < TotalPages;
            btnLastPage.Enabled = CurrentPage < TotalPages;
            UpdatePageDropdown();
        }

        private void UpdatePageDropdown()
        {
            isLoading = true; // Suppress SelectedIndexChanged
            cbCurrentPage.Items.Clear();
            for (int i = 1; i <= TotalPages; i++)
                cbCurrentPage.Items.Add(i);
            if (TotalPages > 0)
                cbCurrentPage.SelectedIndex = CurrentPage - 1;
            else
                cbCurrentPage.Text = "";
            isLoading = false;
        }

        private void TransactionListForm_Load(object sender, EventArgs e)
        {
            try
            {
                isLoading = true;
                cbFilterBy.SelectedIndex = 0; // Default to "None"
                txtFilterValue.Text = "";
                txtRowsPerPage.Text = RowsPerPage.ToString();
                isLoading = false;
                _ = LoadPagedDataAsync<Transaction>(dgvTransactions, lblRecordsCount, $"Transaction/paged/{_accountId}");
            }
            catch (Exception ex)
            {
                ShowError($"Load error: {ex.Message}");
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            txtFilterValue.Visible = (cbFilterBy.Text != "None") && (cbFilterBy.Text != "Transaction Date");
            btnClearFilter.Visible = txtFilterValue.Visible;
            dtpFilter.Visible = cbFilterBy.Text == "Transaction Date";
            txtFilterValue.Text = "";
            if (txtFilterValue.Visible)
            {
                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Transaction ID" || cbFilterBy.Text == "From Account ID" || cbFilterBy.Text == "To Account ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtRowsPerPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtRowsPerPage_TextChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            if (int.TryParse(txtRowsPerPage.Text, out int rows) && rows > 0)
            {
                errorProvider.SetError(txtRowsPerPage, "");
                RowsPerPage = rows;
                CurrentPage = 1;
                _ = LoadPagedDataAsync<Transaction>(dgvTransactions, lblRecordsCount, $"Transaction/paged/{_accountId}");
            }
            else
            {
                errorProvider.SetError(txtRowsPerPage, "Enter a number greater than 0");
            }
        }

        private void cbCurrentPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            if (cbCurrentPage.SelectedIndex >= 0)
            {
                CurrentPage = cbCurrentPage.SelectedIndex + 1;
                _ = LoadPagedDataAsync<Transaction>(dgvTransactions, lblRecordsCount, $"Transaction/paged/{_accountId}");
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
            CurrentPage = 1;
            _ = LoadPagedDataAsync<Transaction>(dgvTransactions, lblRecordsCount, $"Transaction/paged/{_accountId}");
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (CurrentPage < TotalPages)
            {
                CurrentPage++;
                _ = LoadPagedDataAsync<Transaction>(dgvTransactions, lblRecordsCount, $"Transaction/paged/{_accountId}");
            }
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
                _ = LoadPagedDataAsync<Transaction>(dgvTransactions, lblRecordsCount, $"Transaction/paged/{_accountId}");
            }
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            CurrentPage = 1;
            _ = LoadPagedDataAsync<Transaction>(dgvTransactions, lblRecordsCount, $"Transaction/paged/{_accountId}");
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            CurrentPage = TotalPages;
            _ = LoadPagedDataAsync<Transaction>(dgvTransactions, lblRecordsCount, $"Transaction/paged/{_accountId}");
        }

        private void AddTransaction()
        {
            using var form = new TransactionForm(_accountId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                CurrentPage = 1;
                _ = LoadPagedDataAsync<Transaction>(dgvTransactions, lblRecordsCount, $"Transaction/paged/{_accountId}");
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