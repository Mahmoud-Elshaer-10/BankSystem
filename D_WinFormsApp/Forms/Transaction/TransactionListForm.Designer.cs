using D_WinFormsApp.Controls;

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
            dgvTransactions = new MyDataGridView();
            contextMenuStrip = new ContextMenuStrip(components);
            addTransactionToolStripMenuItem = new ToolStripMenuItem();
            exportToCSVToolStripMenuItem = new ToolStripMenuItem();
            btnAdd = new MyButton();
            btnExport = new MyButton();
            cbFilterBy = new ComboBox();
            txtFilterValue = new TextBox();
            lblRecordsCount = new Label();
            btnClearFilter = new MyButton();
            label2 = new Label();
            dtpFilter = new DateTimePicker();
            label1 = new Label();
            cbCurrentPage = new ComboBox();
            txtRowsPerPage = new TextBox();
            btnLastPage = new MyButton();
            btnFirstPage = new MyButton();
            btnPrevPage = new MyButton();
            btnNextPage = new MyButton();
            pnlFilter = new Panel();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            contextMenuStrip.SuspendLayout();
            pnlFilter.SuspendLayout();
            SuspendLayout();
            // 
            // lblTime
            // 
            lblTime.Location = new Point(599, 12);
            lblTime.Size = new Size(75, 19);
            lblTime.Text = "17:45:27";
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
            dgvTransactions.ShowCellToolTips = false;
            dgvTransactions.Size = new Size(673, 352);
            dgvTransactions.TabIndex = 0;
            dgvTransactions.TabStop = false;
            dgvTransactions.DoubleClick += dgvTransactions_DoubleClick;
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
            // btnExport
            // 
            btnExport.Image = Properties.Resources.notes;
            btnExport.ImageAlign = ContentAlignment.MiddleLeft;
            btnExport.Location = new Point(104, 12);
            btnExport.Name = "btnExport";
            btnExport.Padding = new Padding(4);
            btnExport.Size = new Size(100, 37);
            btnExport.TabIndex = 2;
            btnExport.Text = "E&xport";
            btnExport.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnExport, "Export to CSV (Alt+X)");
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // cbFilterBy
            // 
            cbFilterBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterBy.Location = new Point(87, 2);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new Size(150, 29);
            cbFilterBy.TabIndex = 3;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            // 
            // txtFilterValue
            // 
            txtFilterValue.Location = new Point(272, 2);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.Size = new Size(170, 29);
            txtFilterValue.TabIndex = 4;
            txtFilterValue.Visible = false;
            txtFilterValue.KeyPress += txtFilterValue_KeyPress;
            // 
            // lblRecordsCount
            // 
            lblRecordsCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblRecordsCount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRecordsCount.Location = new Point(527, 70);
            lblRecordsCount.Name = "lblRecordsCount";
            lblRecordsCount.Size = new Size(158, 21);
            lblRecordsCount.TabIndex = 8;
            lblRecordsCount.Text = "0";
            lblRecordsCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnClearFilter
            // 
            btnClearFilter.Image = Properties.Resources.clear2;
            btnClearFilter.ImageAlign = ContentAlignment.MiddleLeft;
            btnClearFilter.Location = new Point(448, 2);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.Padding = new Padding(4);
            btnClearFilter.Size = new Size(29, 29);
            btnClearFilter.TabIndex = 6;
            btnClearFilter.TextAlign = ContentAlignment.MiddleRight;
            btnClearFilter.UseVisualStyleBackColor = true;
            btnClearFilter.Visible = false;
            btnClearFilter.Click += btnClearFilter_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(3, 6);
            label2.Name = "label2";
            label2.Size = new Size(76, 21);
            label2.TabIndex = 11;
            label2.Text = "Filter By:";
            // 
            // dtpFilter
            // 
            dtpFilter.Format = DateTimePickerFormat.Short;
            dtpFilter.Location = new Point(272, 2);
            dtpFilter.Name = "dtpFilter";
            dtpFilter.Size = new Size(128, 29);
            dtpFilter.TabIndex = 5;
            dtpFilter.Visible = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(407, 466);
            label1.Name = "label1";
            label1.Size = new Size(114, 21);
            label1.TabIndex = 28;
            label1.Text = "Rows Per Page:";
            // 
            // cbCurrentPage
            // 
            cbCurrentPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbCurrentPage.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCurrentPage.Location = new Point(166, 462);
            cbCurrentPage.Name = "cbCurrentPage";
            cbCurrentPage.Size = new Size(62, 29);
            cbCurrentPage.TabIndex = 9;
            toolTip.SetToolTip(cbCurrentPage, "Select page");
            cbCurrentPage.SelectedIndexChanged += cbCurrentPage_SelectedIndexChanged;
            // 
            // txtRowsPerPage
            // 
            txtRowsPerPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtRowsPerPage.Location = new Point(527, 462);
            txtRowsPerPage.Name = "txtRowsPerPage";
            txtRowsPerPage.Size = new Size(73, 29);
            txtRowsPerPage.TabIndex = 12;
            txtRowsPerPage.Text = "10";
            toolTip.SetToolTip(txtRowsPerPage, "Rows per page");
            txtRowsPerPage.TextChanged += txtRowsPerPage_TextChanged;
            txtRowsPerPage.KeyPress += txtRowsPerPage_KeyPress;
            // 
            // btnLastPage
            // 
            btnLastPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLastPage.FlatAppearance.BorderSize = 0;
            btnLastPage.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnLastPage.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnLastPage.FlatStyle = FlatStyle.Flat;
            btnLastPage.Image = Properties.Resources.Last;
            btnLastPage.ImageAlign = ContentAlignment.MiddleLeft;
            btnLastPage.Location = new Point(335, 458);
            btnLastPage.Name = "btnLastPage";
            btnLastPage.Padding = new Padding(4);
            btnLastPage.Size = new Size(47, 37);
            btnLastPage.TabIndex = 11;
            btnLastPage.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnLastPage, "Last Page");
            btnLastPage.UseVisualStyleBackColor = true;
            btnLastPage.Click += btnLastPage_Click;
            // 
            // btnFirstPage
            // 
            btnFirstPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnFirstPage.FlatAppearance.BorderSize = 0;
            btnFirstPage.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnFirstPage.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnFirstPage.FlatStyle = FlatStyle.Flat;
            btnFirstPage.Image = Properties.Resources.First;
            btnFirstPage.ImageAlign = ContentAlignment.MiddleLeft;
            btnFirstPage.Location = new Point(12, 458);
            btnFirstPage.Name = "btnFirstPage";
            btnFirstPage.Padding = new Padding(4);
            btnFirstPage.Size = new Size(47, 37);
            btnFirstPage.TabIndex = 7;
            btnFirstPage.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnFirstPage, "First Page");
            btnFirstPage.UseVisualStyleBackColor = true;
            btnFirstPage.Click += btnFirstPage_Click;
            // 
            // btnPrevPage
            // 
            btnPrevPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPrevPage.FlatAppearance.BorderSize = 0;
            btnPrevPage.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnPrevPage.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnPrevPage.FlatStyle = FlatStyle.Flat;
            btnPrevPage.Image = Properties.Resources.previous;
            btnPrevPage.ImageAlign = ContentAlignment.MiddleLeft;
            btnPrevPage.Location = new Point(72, 458);
            btnPrevPage.Name = "btnPrevPage";
            btnPrevPage.Padding = new Padding(4);
            btnPrevPage.Size = new Size(81, 37);
            btnPrevPage.TabIndex = 8;
            btnPrevPage.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnPrevPage, "Previous Page");
            btnPrevPage.UseVisualStyleBackColor = true;
            btnPrevPage.Click += btnPrevPage_Click;
            // 
            // btnNextPage
            // 
            btnNextPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnNextPage.BackColor = Color.Transparent;
            btnNextPage.FlatAppearance.BorderSize = 0;
            btnNextPage.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnNextPage.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnNextPage.FlatStyle = FlatStyle.Flat;
            btnNextPage.Image = Properties.Resources.Next;
            btnNextPage.ImageAlign = ContentAlignment.MiddleLeft;
            btnNextPage.Location = new Point(241, 458);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Padding = new Padding(4);
            btnNextPage.Size = new Size(81, 37);
            btnNextPage.TabIndex = 10;
            btnNextPage.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnNextPage, "Next Page");
            btnNextPage.UseVisualStyleBackColor = false;
            btnNextPage.Click += btnNextPage_Click;
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = Color.Transparent;
            pnlFilter.Controls.Add(label2);
            pnlFilter.Controls.Add(cbFilterBy);
            pnlFilter.Controls.Add(dtpFilter);
            pnlFilter.Controls.Add(txtFilterValue);
            pnlFilter.Controls.Add(btnClearFilter);
            pnlFilter.Location = new Point(12, 57);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(488, 36);
            pnlFilter.TabIndex = 30;
            // 
            // TransactionListForm
            // 
            ClientSize = new Size(699, 507);
            Controls.Add(pnlFilter);
            Controls.Add(label1);
            Controls.Add(cbCurrentPage);
            Controls.Add(txtRowsPerPage);
            Controls.Add(btnLastPage);
            Controls.Add(btnFirstPage);
            Controls.Add(btnPrevPage);
            Controls.Add(btnNextPage);
            Controls.Add(btnExport);
            Controls.Add(lblRecordsCount);
            Controls.Add(btnAdd);
            Controls.Add(dgvTransactions);
            MinimumSize = new Size(300, 300);
            Name = "TransactionListForm";
            Text = "Bank System - Transaction List";
            Load += TransactionListForm_Load;
            Controls.SetChildIndex(btnInvisible, 0);
            Controls.SetChildIndex(dgvTransactions, 0);
            Controls.SetChildIndex(btnAdd, 0);
            Controls.SetChildIndex(lblRecordsCount, 0);
            Controls.SetChildIndex(lblTime, 0);
            Controls.SetChildIndex(btnExport, 0);
            Controls.SetChildIndex(btnNextPage, 0);
            Controls.SetChildIndex(btnPrevPage, 0);
            Controls.SetChildIndex(btnFirstPage, 0);
            Controls.SetChildIndex(btnLastPage, 0);
            Controls.SetChildIndex(txtRowsPerPage, 0);
            Controls.SetChildIndex(cbCurrentPage, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(pnlFilter, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            contextMenuStrip.ResumeLayout(false);
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private MyDataGridView dgvTransactions;
        private MyButton btnAdd;
        private MyButton btnExport;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem addTransactionToolStripMenuItem;
        private ToolStripMenuItem exportToCSVToolStripMenuItem;
        private ComboBox cbFilterBy;
        private TextBox txtFilterValue;
        private Label lblRecordsCount;
        private MyButton btnClearFilter;
        private Label label2;
        private DateTimePicker dtpFilter;
        private Label label1;
        private ComboBox cbCurrentPage;
        private TextBox txtRowsPerPage;
        private MyButton btnLastPage;
        private MyButton btnFirstPage;
        private MyButton btnPrevPage;
        private MyButton btnNextPage;
        private Panel pnlFilter;
    }
}