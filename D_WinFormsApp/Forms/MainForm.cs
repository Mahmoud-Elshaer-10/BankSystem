namespace D_WinFormsApp
{
    public partial class MainForm : MyForm
    {
        public MainForm()
        {
            InitializeComponent();

            // Add button tooltips to notify user of keyboard shortcuts
            toolTip.SetToolTip(btnClients, "Show Clients (Alt+C)");
            toolTip.SetToolTip(btnAccounts, "Show Accounts (Alt+A)");
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
            using (var form = new ClientListForm())
            {
                form.ShowDialog();
            }
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            using (var form = new AccountListForm())
            {
                form.ShowDialog();
            }
        }
    }
}