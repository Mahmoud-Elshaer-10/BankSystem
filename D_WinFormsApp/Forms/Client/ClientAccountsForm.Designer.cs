namespace D_WinFormsApp
{
    partial class ClientAccountsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            dgvAccounts = new D_WinFormsApp.Controls.MyDataGridView();
            contextMenuStrip = new ContextMenuStrip(components);
            showTransactionsToolStripMenuItem = new ToolStripMenuItem();
            btnShowTransactions = new D_WinFormsApp.Controls.MyButton();
            btnAdd = new D_WinFormsApp.Controls.MyButton();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).BeginInit();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // lblTime
            // 
            lblTime.Location = new Point(440, 12);
            lblTime.Size = new Size(75, 19);
            lblTime.Text = "17:17:40";
            // 
            // dgvAccounts
            // 
            dgvAccounts.AllowUserToAddRows = false;
            dgvAccounts.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(240, 240, 240);
            dgvAccounts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvAccounts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvAccounts.BackgroundColor = Color.White;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.LightGray;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvAccounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccounts.ContextMenuStrip = contextMenuStrip;
            dgvAccounts.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvAccounts.EnableHeadersVisualStyles = false;
            dgvAccounts.Location = new Point(12, 80);
            dgvAccounts.MultiSelect = false;
            dgvAccounts.Name = "dgvAccounts";
            dgvAccounts.ReadOnly = true;
            dgvAccounts.RowHeadersWidth = 51;
            dgvAccounts.RowTemplate.Height = 29;
            dgvAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAccounts.ShowCellToolTips = false;
            dgvAccounts.Size = new Size(515, 170);
            dgvAccounts.TabIndex = 0;
            dgvAccounts.TabStop = false;
            dgvAccounts.DoubleClick += dgvAccounts_DoubleClick;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { showTransactionsToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(210, 26);
            // 
            // showTransactionsToolStripMenuItem
            // 
            showTransactionsToolStripMenuItem.Image = Properties.Resources.ShowIcon;
            showTransactionsToolStripMenuItem.Name = "showTransactionsToolStripMenuItem";
            showTransactionsToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.T;
            showTransactionsToolStripMenuItem.Size = new Size(209, 22);
            showTransactionsToolStripMenuItem.Text = "Show Transactions";
            showTransactionsToolStripMenuItem.Click += showTransactionsToolStripMenuItem_Click;
            // 
            // btnShowTransactions
            // 
            btnShowTransactions.Image = Properties.Resources.ShowIcon;
            btnShowTransactions.ImageAlign = ContentAlignment.MiddleLeft;
            btnShowTransactions.Location = new Point(12, 12);
            btnShowTransactions.Name = "btnShowTransactions";
            btnShowTransactions.Padding = new Padding(4);
            btnShowTransactions.Size = new Size(186, 37);
            btnShowTransactions.TabIndex = 1;
            btnShowTransactions.Text = "Show &Transactions";
            btnShowTransactions.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnShowTransactions, "Show Transactions (Alt+S)");
            btnShowTransactions.UseVisualStyleBackColor = true;
            btnShowTransactions.Click += btnShowTransactions_Click;
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.AddIcon;
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(204, 12);
            btnAdd.Name = "btnAdd";
            btnAdd.Padding = new Padding(4);
            btnAdd.Size = new Size(86, 37);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "&Add";
            btnAdd.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnAdd, "Add (Alt+A)");
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // ClientAccountsForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 265);
            Controls.Add(btnAdd);
            Controls.Add(btnShowTransactions);
            Controls.Add(dgvAccounts);
            MinimumSize = new Size(136, 88);
            Name = "ClientAccountsForm";
            Text = "Client Accounts";
            Load += ClientAccountsForm_Load;
            Controls.SetChildIndex(btnInvisible, 0);
            Controls.SetChildIndex(dgvAccounts, 0);
            Controls.SetChildIndex(btnShowTransactions, 0);
            Controls.SetChildIndex(lblTime, 0);
            Controls.SetChildIndex(btnAdd, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).EndInit();
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private Controls.MyDataGridView dgvAccounts;
        private Controls.MyButton btnShowTransactions;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem showTransactionsToolStripMenuItem;
        private Controls.MyButton btnAdd;
    }
}