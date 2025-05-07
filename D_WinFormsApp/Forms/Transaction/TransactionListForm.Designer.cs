namespace D_WinFormsApp
{
    partial class TransactionListForm
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
            dgvTransactions = new D_WinFormsApp.Controls.MyDataGridView();
            contextMenuStrip = new ContextMenuStrip(components);
            addTransactionToolStripMenuItem = new ToolStripMenuItem();
            exportToCSVToolStripMenuItem = new ToolStripMenuItem();
            btnAdd = new D_WinFormsApp.Controls.MyButton();
            cbFilterBy = new ComboBox();
            txtFilterValue = new TextBox();
            lblRecordsCount = new Label();
            btnClearFilter = new D_WinFormsApp.Controls.MyButton();
            label2 = new Label();
            btnExport = new D_WinFormsApp.Controls.MyButton();
            dtpFilter = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // lblTime
            // 
            lblTime.Location = new Point(599, 12);
            lblTime.Text = "20:58:22";
            // 
            // dgvTransactions
            // 
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 240, 240);
            dgvTransactions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvTransactions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvTransactions.BackgroundColor = Color.White;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.LightGray;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactions.ContextMenuStrip = contextMenuStrip;
            dgvTransactions.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvTransactions.EnableHeadersVisualStyles = false;
            dgvTransactions.Location = new Point(12, 100);
            dgvTransactions.MultiSelect = false;
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.ReadOnly = true;
            dgvTransactions.RowHeadersWidth = 51;
            dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransactions.Size = new Size(673, 356);
            dgvTransactions.TabIndex = 0;
            dgvTransactions.TabStop = false;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { addTransactionToolStripMenuItem, exportToCSVToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(199, 48);
            // 
            // addTransactionToolStripMenuItem
            // 
            addTransactionToolStripMenuItem.Image = Properties.Resources.AddIcon;
            addTransactionToolStripMenuItem.Name = "addTransactionToolStripMenuItem";
            addTransactionToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.A;
            addTransactionToolStripMenuItem.Size = new Size(198, 22);
            addTransactionToolStripMenuItem.Text = "Add Transaction";
            addTransactionToolStripMenuItem.Click += addTransactionToolStripMenuItem_Click;
            // 
            // exportToCSVToolStripMenuItem
            // 
            exportToCSVToolStripMenuItem.Image = Properties.Resources.notes;
            exportToCSVToolStripMenuItem.Name = "exportToCSVToolStripMenuItem";
            exportToCSVToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.X;
            exportToCSVToolStripMenuItem.Size = new Size(198, 22);
            exportToCSVToolStripMenuItem.Text = "Export to CSV";
            exportToCSVToolStripMenuItem.Click += exportToCSVToolStripMenuItem_Click;
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.AddIcon;
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(12, 12);
            btnAdd.Name = "btnAdd";
            btnAdd.Padding = new Padding(4);
            btnAdd.Size = new Size(86, 37);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "&Add";
            btnAdd.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnAdd, "Add (Alt+A)");
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // cbFilterBy
            // 
            cbFilterBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterBy.Items.AddRange(new object[] { "None", "Transaction ID", "From Account ID", "Transaction Type", "Amount", "To Account ID", "Transaction Date" });
            cbFilterBy.Location = new Point(93, 65);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new Size(150, 29);
            cbFilterBy.TabIndex = 6;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            // 
            // txtFilterValue
            // 
            txtFilterValue.Location = new Point(278, 65);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.Size = new Size(170, 29);
            txtFilterValue.TabIndex = 7;
            txtFilterValue.Visible = false;
            txtFilterValue.KeyPress += txtFilterValue_KeyPress;
            // 
            // lblRecordsCount
            // 
            lblRecordsCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblRecordsCount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRecordsCount.Location = new Point(459, 70);
            lblRecordsCount.Name = "lblRecordsCount";
            lblRecordsCount.Size = new Size(215, 23);
            lblRecordsCount.TabIndex = 7;
            lblRecordsCount.Text = "0";
            lblRecordsCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnClearFilter
            // 
            btnClearFilter.Image = Properties.Resources.clear2;
            btnClearFilter.ImageAlign = ContentAlignment.MiddleLeft;
            btnClearFilter.Location = new Point(454, 65);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.Padding = new Padding(4);
            btnClearFilter.Size = new Size(29, 29);
            btnClearFilter.TabIndex = 8;
            btnClearFilter.TextAlign = ContentAlignment.MiddleRight;
            btnClearFilter.UseVisualStyleBackColor = true;
            btnClearFilter.Visible = false;
            btnClearFilter.Click += btnClearFilter_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(12, 68);
            label2.Name = "label2";
            label2.Size = new Size(76, 21);
            label2.TabIndex = 11;
            label2.Text = "Filter By:";
            // 
            // btnExport
            // 
            btnExport.Image = Properties.Resources.notes;
            btnExport.ImageAlign = ContentAlignment.MiddleLeft;
            btnExport.Location = new Point(104, 12);
            btnExport.Name = "btnExport";
            btnExport.Padding = new Padding(4);
            btnExport.Size = new Size(100, 37);
            btnExport.TabIndex = 5;
            btnExport.Text = "E&xport";
            btnExport.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnExport, "Export to CSV (Alt+X)");
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // dtpFilter
            // 
            dtpFilter.Format = DateTimePickerFormat.Short;
            dtpFilter.Location = new Point(278, 65);
            dtpFilter.Name = "dtpFilter";
            dtpFilter.Size = new Size(128, 29);
            dtpFilter.TabIndex = 14;
            dtpFilter.Visible = false;
            // 
            // TransactionListForm
            // 
            ClientSize = new Size(699, 472);
            Controls.Add(dtpFilter);
            Controls.Add(btnExport);
            Controls.Add(label2);
            Controls.Add(btnClearFilter);
            Controls.Add(lblRecordsCount);
            Controls.Add(txtFilterValue);
            Controls.Add(cbFilterBy);
            Controls.Add(btnAdd);
            Controls.Add(dgvTransactions);
            Name = "TransactionListForm";
            Text = "Bank System - Transaction List";
            Load += TransactionListForm_Load;
            Controls.SetChildIndex(dgvTransactions, 0);
            Controls.SetChildIndex(btnAdd, 0);
            Controls.SetChildIndex(cbFilterBy, 0);
            Controls.SetChildIndex(txtFilterValue, 0);
            Controls.SetChildIndex(lblRecordsCount, 0);
            Controls.SetChildIndex(btnClearFilter, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(btnExport, 0);
            Controls.SetChildIndex(dtpFilter, 0);
            Controls.SetChildIndex(lblTime, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private Controls.MyDataGridView dgvTransactions;
        private Controls.MyButton btnAdd;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem addTransactionToolStripMenuItem;
        private ToolStripMenuItem exportToCSVToolStripMenuItem;
        private ComboBox cbFilterBy;
        private TextBox txtFilterValue;
        private Label lblRecordsCount;
        private Controls.MyButton btnClearFilter;
        private Label label2;
        private Controls.MyButton btnExport;
        private DateTimePicker dtpFilter;
    }
}