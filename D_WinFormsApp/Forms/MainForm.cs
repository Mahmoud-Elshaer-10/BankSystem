namespace D_WinFormsApp
{
    public partial class MainForm : MyForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) // Ignore Escape
            {
                base.OnKeyDown(e);
            }
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            using var form = new ClientListForm();
            form.ShowDialog();
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            using var form = new AccountListForm();
            form.ShowDialog();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            using var form = new DashboardForm();
            form.ShowDialog();
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            using var form = new TransactionListForm();
            form.ShowDialog();
        }
    }
}