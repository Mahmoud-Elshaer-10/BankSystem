namespace D_WinFormsApp
{
    public partial class MainForm : MyForm
    {
        public MainForm()
        {
            InitializeComponent();
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