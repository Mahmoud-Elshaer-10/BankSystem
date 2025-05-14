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
            btnFirstPage = new MyButton();
            btnNextPage = new MyButton();
            btnPrevPage = new MyButton();
            btnLastPage = new MyButton();
            txtRowsPerPage = new TextBox();
            cbCurrentPage = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // lblTime
            // 
            lblTime.Location = new Point(599, 12);
            lblTime.Text = "20:44:37";
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
            dgvTransactions.Size = new Size(673, 352);
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
            lblRecordsCount.TabIndex = 8;
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
            btnClearFilter.TabIndex = 9;
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
            // dtpFilter
            // 
            dtpFilter.Format = DateTimePickerFormat.Short;
            dtpFilter.Location = new Point(278, 65);
            dtpFilter.Name = "dtpFilter";
            dtpFilter.Size = new Size(128, 29);
            dtpFilter.TabIndex = 14;
            dtpFilter.Visible = false;
            // 
            // btnFirstPage
            // 
            btnFirstPage.FlatAppearance.BorderSize = 0;
            btnFirstPage.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnFirstPage.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnFirstPage.FlatStyle = FlatStyle.Flat;
            //btnFirstPage.Image = Properties.Resources.Next;
            btnFirstPage.ImageAlign = ContentAlignment.MiddleLeft;
            btnFirstPage.Location = new Point(12, 458);
            btnFirstPage.Name = "btnFirstPage";
            btnFirstPage.Padding = new Padding(4);
            btnFirstPage.Size = new Size(81, 37);
            btnFirstPage.TabIndex = 15;
            btnFirstPage.Text = "First";
            btnFirstPage.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnFirstPage, "First Page");
            btnFirstPage.UseVisualStyleBackColor = true;
            btnFirstPage.Click += btnFirstPage_Click;
            // 
            // btnNextPage
            // 
            btnNextPage.FlatAppearance.BorderSize = 0;
            btnNextPage.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnNextPage.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnNextPage.FlatStyle = FlatStyle.Flat;
            //btnNextPage.Image = Properties.Resources.Next;
            btnNextPage.ImageAlign = ContentAlignment.MiddleLeft;
            btnNextPage.Location = new Point(206, 458);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Padding = new Padding(4);
            btnNextPage.Size = new Size(81, 37);
            btnNextPage.TabIndex = 16;
            btnNextPage.Text = "Next";
            btnNextPage.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnNextPage, "Next Page");
            btnNextPage.UseVisualStyleBackColor = true;
            btnNextPage.Click += btnNextPage_Click;
            // 
            // btnPrevPage
            // 
            btnPrevPage.FlatAppearance.BorderSize = 0;
            btnPrevPage.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnPrevPage.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnPrevPage.FlatStyle = FlatStyle.Flat;
            btnPrevPage.Image = Properties.Resources.previous;
            btnPrevPage.ImageAlign = ContentAlignment.MiddleLeft;
            btnPrevPage.Location = new Point(107, 458);
            btnPrevPage.Name = "btnPrevPage";
            btnPrevPage.Padding = new Padding(4);
            btnPrevPage.Size = new Size(81, 37);
            btnPrevPage.TabIndex = 17;
            btnPrevPage.Text = "Prev";
            btnPrevPage.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnPrevPage, "Previous Page");
            btnPrevPage.UseVisualStyleBackColor = true;
            btnPrevPage.Click += btnPrevPage_Click;
            // 
            // btnLastPage
            // 
            btnLastPage.FlatAppearance.BorderSize = 0;
            btnLastPage.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnLastPage.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnLastPage.FlatStyle = FlatStyle.Flat;
            btnLastPage.Image = Properties.Resources.previous;
            btnLastPage.ImageAlign = ContentAlignment.MiddleLeft;
            btnLastPage.Location = new Point(307, 458);
            btnLastPage.Name = "btnLastPage";
            btnLastPage.Padding = new Padding(4);
            btnLastPage.Size = new Size(81, 37);
            btnLastPage.TabIndex = 18;
            btnLastPage.Text = "Last";
            btnLastPage.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnLastPage, "Last Page");
            btnLastPage.UseVisualStyleBackColor = true;
            btnLastPage.Click += btnLastPage_Click;
            // 
            // txtRowsPerPage
            // 
            txtRowsPerPage.Location = new Point(394, 458);
            txtRowsPerPage.Name = "txtRowsPerPage";
            txtRowsPerPage.Size = new Size(50, 29);
            txtRowsPerPage.TabIndex = 19;
            txtRowsPerPage.Text = "10";
            toolTip.SetToolTip(txtRowsPerPage, "Rows per page");
            txtRowsPerPage.TextChanged += txtRowsPerPage_TextChanged;
            txtRowsPerPage.KeyPress += txtRowsPerPage_KeyPress;
            // 
            // cbCurrentPage
            // 
            cbCurrentPage.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCurrentPage.Location = new Point(450, 458);
            cbCurrentPage.Name = "cbCurrentPage";
            cbCurrentPage.Size = new Size(60, 29);
            cbCurrentPage.TabIndex = 20;
            toolTip.SetToolTip(cbCurrentPage, "Select page");
            cbCurrentPage.SelectedIndexChanged += cbCurrentPage_SelectedIndexChanged;
            // 
            // TransactionListForm
            // 
            ClientSize = new Size(699, 507);
            Controls.Add(cbCurrentPage);
            Controls.Add(txtRowsPerPage);
            Controls.Add(btnLastPage);
            Controls.Add(btnPrevPage);
            Controls.Add(btnNextPage);
            Controls.Add(btnFirstPage);
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
            Controls.SetChildIndex(lblTime, 0);
            Controls.SetChildIndex(btnExport, 0);
            Controls.SetChildIndex(dtpFilter, 0);
            Controls.SetChildIndex(btnFirstPage, 0);
            Controls.SetChildIndex(btnNextPage, 0);
            Controls.SetChildIndex(btnPrevPage, 0);
            Controls.SetChildIndex(btnLastPage, 0);
            Controls.SetChildIndex(txtRowsPerPage, 0);
            Controls.SetChildIndex(cbCurrentPage, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            contextMenuStrip.ResumeLayout(false);
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
        private MyButton btnFirstPage;
        private MyButton btnNextPage;
        private MyButton btnPrevPage;
        private MyButton btnLastPage;
        private TextBox txtRowsPerPage;
        private ComboBox cbCurrentPage;
    }
}