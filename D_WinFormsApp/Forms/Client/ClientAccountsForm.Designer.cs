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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgvAccounts = new D_WinFormsApp.Controls.MyDataGridView();
            contextMenuStrip = new ContextMenuStrip(components);
            showTransactionsToolStripMenuItem = new ToolStripMenuItem();
            btnShowTransactions = new D_WinFormsApp.Controls.MyButton();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).BeginInit();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // lblTime
            // 
            lblTime.Location = new Point(440, 12);
            lblTime.Text = "18:55:24";
            // 
            // dgvAccounts
            // 
            dgvAccounts.AllowUserToAddRows = false;
            dgvAccounts.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 240, 240);
            dgvAccounts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvAccounts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvAccounts.BackgroundColor = Color.White;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.LightGray;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvAccounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
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
            dgvAccounts.Size = new Size(515, 170);
            dgvAccounts.TabIndex = 0;
            dgvAccounts.TabStop = false;
            dgvAccounts.DoubleClick += dgvAccounts_DoubleClick;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { showTransactionsToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(209, 26);
            // 
            // showTransactionsToolStripMenuItem
            // 
            showTransactionsToolStripMenuItem.Image = Properties.Resources.ShowIcon;
            showTransactionsToolStripMenuItem.Name = "showTransactionsToolStripMenuItem";
            showTransactionsToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.S;
            showTransactionsToolStripMenuItem.Size = new Size(208, 22);
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
            btnShowTransactions.Text = "&Show Transactions";
            btnShowTransactions.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnShowTransactions, "Show Transactions (Alt+S)");
            btnShowTransactions.UseVisualStyleBackColor = true;
            btnShowTransactions.Click += btnShowTransactions_Click;
            // 
            // ClientAccountsForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 265);
            Controls.Add(btnShowTransactions);
            Controls.Add(dgvAccounts);
            Name = "ClientAccountsForm";
            Text = "Client Accounts";
            Load += ClientAccountsForm_Load;
            Controls.SetChildIndex(dgvAccounts, 0);
            Controls.SetChildIndex(btnShowTransactions, 0);
            Controls.SetChildIndex(lblTime, 0);
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
    }
}