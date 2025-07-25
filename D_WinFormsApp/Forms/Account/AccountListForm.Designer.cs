﻿using D_WinFormsApp.Controls;

namespace D_WinFormsApp
{
    partial class AccountListForm
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
            dgvAccounts = new MyDataGridView();
            contextMenuStrip = new ContextMenuStrip(components);
            addAccountToolStripMenuItem = new ToolStripMenuItem();
            editAccountToolStripMenuItem = new ToolStripMenuItem();
            deleteAccountToolStripMenuItem = new ToolStripMenuItem();
            showClientToolStripMenuItem = new ToolStripMenuItem();
            showTransactionsToolStripMenuItem = new ToolStripMenuItem();
            exportToCSVToolStripMenuItem = new ToolStripMenuItem();
            btnAdd = new MyButton();
            btnEdit = new MyButton();
            btnDelete = new MyButton();
            btnShowClient = new MyButton();
            cbFilterBy = new ComboBox();
            txtFilterValue = new TextBox();
            lblRecordsCount = new Label();
            btnClearFilter = new MyButton();
            label2 = new Label();
            btnExport = new MyButton();
            dtpFilter = new DateTimePicker();
            label1 = new Label();
            cbCurrentPage = new ComboBox();
            txtRowsPerPage = new TextBox();
            btnLastPage = new MyButton();
            btnFirstPage = new MyButton();
            btnPrevPage = new MyButton();
            btnNextPage = new MyButton();
            btnShowTransactions = new MyButton();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).BeginInit();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // lblTime
            // 
            lblTime.Location = new Point(613, 12);
            lblTime.Size = new Size(75, 19);
            lblTime.Text = "15:20:24";
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
            dgvAccounts.Location = new Point(12, 160);
            dgvAccounts.MultiSelect = false;
            dgvAccounts.Name = "dgvAccounts";
            dgvAccounts.ReadOnly = true;
            dgvAccounts.RowHeadersWidth = 51;
            dgvAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAccounts.ShowCellToolTips = false;
            dgvAccounts.Size = new Size(689, 347);
            dgvAccounts.TabIndex = 0;
            dgvAccounts.TabStop = false;
            dgvAccounts.DoubleClick += dgvAccounts_DoubleClick;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { addAccountToolStripMenuItem, editAccountToolStripMenuItem, deleteAccountToolStripMenuItem, showClientToolStripMenuItem, showTransactionsToolStripMenuItem, exportToCSVToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(210, 136);
            // 
            // addAccountToolStripMenuItem
            // 
            addAccountToolStripMenuItem.Image = Properties.Resources.AddIcon;
            addAccountToolStripMenuItem.Name = "addAccountToolStripMenuItem";
            addAccountToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.A;
            addAccountToolStripMenuItem.Size = new Size(209, 22);
            addAccountToolStripMenuItem.Text = "Add Account";
            addAccountToolStripMenuItem.Click += addAccountToolStripMenuItem_Click;
            // 
            // editAccountToolStripMenuItem
            // 
            editAccountToolStripMenuItem.Image = Properties.Resources.EditIcon;
            editAccountToolStripMenuItem.Name = "editAccountToolStripMenuItem";
            editAccountToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.E;
            editAccountToolStripMenuItem.Size = new Size(209, 22);
            editAccountToolStripMenuItem.Text = "Edit Account";
            editAccountToolStripMenuItem.Click += editAccountToolStripMenuItem_Click;
            // 
            // deleteAccountToolStripMenuItem
            // 
            deleteAccountToolStripMenuItem.Image = Properties.Resources.DeleteIcon;
            deleteAccountToolStripMenuItem.Name = "deleteAccountToolStripMenuItem";
            deleteAccountToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.D;
            deleteAccountToolStripMenuItem.Size = new Size(209, 22);
            deleteAccountToolStripMenuItem.Text = "Delete Account";
            deleteAccountToolStripMenuItem.Click += deleteAccountToolStripMenuItem_Click;
            // 
            // showClientToolStripMenuItem
            // 
            showClientToolStripMenuItem.Image = Properties.Resources.ShowIcon;
            showClientToolStripMenuItem.Name = "showClientToolStripMenuItem";
            showClientToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.S;
            showClientToolStripMenuItem.Size = new Size(209, 22);
            showClientToolStripMenuItem.Text = "Show Client";
            showClientToolStripMenuItem.Click += showClientToolStripMenuItem_Click;
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
            // exportToCSVToolStripMenuItem
            // 
            exportToCSVToolStripMenuItem.Image = Properties.Resources.notes;
            exportToCSVToolStripMenuItem.Name = "exportToCSVToolStripMenuItem";
            exportToCSVToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.X;
            exportToCSVToolStripMenuItem.Size = new Size(209, 22);
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
            // btnEdit
            // 
            btnEdit.Image = Properties.Resources.EditIcon;
            btnEdit.ImageAlign = ContentAlignment.MiddleLeft;
            btnEdit.Location = new Point(105, 12);
            btnEdit.Name = "btnEdit";
            btnEdit.Padding = new Padding(4);
            btnEdit.Size = new Size(86, 37);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "&Edit";
            btnEdit.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnEdit, "Edit (Alt+E)");
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Image = Properties.Resources.DeleteIcon;
            btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            btnDelete.Location = new Point(198, 12);
            btnDelete.Name = "btnDelete";
            btnDelete.Padding = new Padding(2);
            btnDelete.Size = new Size(95, 37);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "&Delete";
            btnDelete.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnDelete, "Delete (Alt+D)");
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnShowClient
            // 
            btnShowClient.Image = Properties.Resources.ShowIcon;
            btnShowClient.ImageAlign = ContentAlignment.MiddleLeft;
            btnShowClient.Location = new Point(300, 12);
            btnShowClient.Name = "btnShowClient";
            btnShowClient.Padding = new Padding(4);
            btnShowClient.Size = new Size(135, 37);
            btnShowClient.TabIndex = 4;
            btnShowClient.Text = "&Show Client";
            btnShowClient.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnShowClient, "Show Client (Alt+S)");
            btnShowClient.UseVisualStyleBackColor = true;
            btnShowClient.Click += btnShowClient_Click;
            // 
            // cbFilterBy
            // 
            cbFilterBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterBy.Location = new Point(93, 113);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new Size(120, 29);
            cbFilterBy.TabIndex = 7;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            // 
            // txtFilterValue
            // 
            txtFilterValue.Location = new Point(226, 113);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.Size = new Size(170, 29);
            txtFilterValue.TabIndex = 8;
            txtFilterValue.Visible = false;
            txtFilterValue.KeyPress += txtFilterValue_KeyPress;
            // 
            // lblRecordsCount
            // 
            lblRecordsCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblRecordsCount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRecordsCount.Location = new Point(527, 115);
            lblRecordsCount.Name = "lblRecordsCount";
            lblRecordsCount.Size = new Size(161, 23);
            lblRecordsCount.TabIndex = 7;
            lblRecordsCount.Text = "0";
            lblRecordsCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnClearFilter
            // 
            btnClearFilter.Image = Properties.Resources.clear2;
            btnClearFilter.ImageAlign = ContentAlignment.MiddleLeft;
            btnClearFilter.Location = new Point(402, 113);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.Padding = new Padding(4);
            btnClearFilter.Size = new Size(29, 29);
            btnClearFilter.TabIndex = 10;
            btnClearFilter.TextAlign = ContentAlignment.MiddleRight;
            btnClearFilter.UseVisualStyleBackColor = true;
            btnClearFilter.Visible = false;
            btnClearFilter.Click += btnClearFilter_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(12, 116);
            label2.Name = "label2";
            label2.Size = new Size(76, 21);
            label2.TabIndex = 12;
            label2.Text = "Filter By:";
            // 
            // btnExport
            // 
            btnExport.Image = Properties.Resources.notes;
            btnExport.ImageAlign = ContentAlignment.MiddleLeft;
            btnExport.Location = new Point(442, 12);
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
            dtpFilter.Location = new Point(226, 113);
            dtpFilter.Name = "dtpFilter";
            dtpFilter.Size = new Size(128, 29);
            dtpFilter.TabIndex = 9;
            dtpFilter.Visible = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(409, 521);
            label1.Name = "label1";
            label1.Size = new Size(114, 21);
            label1.TabIndex = 28;
            label1.Text = "Rows Per Page:";
            // 
            // cbCurrentPage
            // 
            cbCurrentPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbCurrentPage.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCurrentPage.Location = new Point(168, 517);
            cbCurrentPage.Name = "cbCurrentPage";
            cbCurrentPage.Size = new Size(62, 29);
            cbCurrentPage.TabIndex = 13;
            toolTip.SetToolTip(cbCurrentPage, "Select page");
            cbCurrentPage.SelectedIndexChanged += cbCurrentPage_SelectedIndexChanged;
            // 
            // txtRowsPerPage
            // 
            txtRowsPerPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtRowsPerPage.Location = new Point(529, 517);
            txtRowsPerPage.Name = "txtRowsPerPage";
            txtRowsPerPage.Size = new Size(73, 29);
            txtRowsPerPage.TabIndex = 16;
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
            btnLastPage.Location = new Point(337, 513);
            btnLastPage.Name = "btnLastPage";
            btnLastPage.Padding = new Padding(4);
            btnLastPage.Size = new Size(47, 37);
            btnLastPage.TabIndex = 15;
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
            btnFirstPage.Location = new Point(14, 513);
            btnFirstPage.Name = "btnFirstPage";
            btnFirstPage.Padding = new Padding(4);
            btnFirstPage.Size = new Size(47, 37);
            btnFirstPage.TabIndex = 11;
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
            btnPrevPage.Location = new Point(74, 513);
            btnPrevPage.Name = "btnPrevPage";
            btnPrevPage.Padding = new Padding(4);
            btnPrevPage.Size = new Size(81, 37);
            btnPrevPage.TabIndex = 12;
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
            btnNextPage.Location = new Point(243, 513);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Padding = new Padding(4);
            btnNextPage.Size = new Size(81, 37);
            btnNextPage.TabIndex = 14;
            btnNextPage.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnNextPage, "Next Page");
            btnNextPage.UseVisualStyleBackColor = false;
            btnNextPage.Click += btnNextPage_Click;
            // 
            // btnShowTransactions
            // 
            btnShowTransactions.Image = Properties.Resources.ShowIcon;
            btnShowTransactions.ImageAlign = ContentAlignment.MiddleLeft;
            btnShowTransactions.Location = new Point(12, 55);
            btnShowTransactions.Name = "btnShowTransactions";
            btnShowTransactions.Padding = new Padding(4);
            btnShowTransactions.Size = new Size(186, 37);
            btnShowTransactions.TabIndex = 6;
            btnShowTransactions.Text = "Show &Transactions";
            btnShowTransactions.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnShowTransactions, "Show Transactions (Alt+S)");
            btnShowTransactions.UseVisualStyleBackColor = true;
            btnShowTransactions.Click += btnShowTransactions_Click;
            // 
            // AccountListForm
            // 
            ClientSize = new Size(713, 563);
            Controls.Add(btnShowTransactions);
            Controls.Add(label1);
            Controls.Add(cbCurrentPage);
            Controls.Add(txtRowsPerPage);
            Controls.Add(btnLastPage);
            Controls.Add(btnFirstPage);
            Controls.Add(btnPrevPage);
            Controls.Add(btnNextPage);
            Controls.Add(dtpFilter);
            Controls.Add(btnExport);
            Controls.Add(label2);
            Controls.Add(btnClearFilter);
            Controls.Add(lblRecordsCount);
            Controls.Add(txtFilterValue);
            Controls.Add(cbFilterBy);
            Controls.Add(btnShowClient);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dgvAccounts);
            MinimumSize = new Size(300, 300);
            Name = "AccountListForm";
            Text = "Bank System - Account List";
            Load += AccountListForm_Load;
            Controls.SetChildIndex(btnInvisible, 0);
            Controls.SetChildIndex(dgvAccounts, 0);
            Controls.SetChildIndex(btnAdd, 0);
            Controls.SetChildIndex(btnEdit, 0);
            Controls.SetChildIndex(btnDelete, 0);
            Controls.SetChildIndex(btnShowClient, 0);
            Controls.SetChildIndex(cbFilterBy, 0);
            Controls.SetChildIndex(txtFilterValue, 0);
            Controls.SetChildIndex(lblRecordsCount, 0);
            Controls.SetChildIndex(btnClearFilter, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(lblTime, 0);
            Controls.SetChildIndex(btnExport, 0);
            Controls.SetChildIndex(dtpFilter, 0);
            Controls.SetChildIndex(btnNextPage, 0);
            Controls.SetChildIndex(btnPrevPage, 0);
            Controls.SetChildIndex(btnFirstPage, 0);
            Controls.SetChildIndex(btnLastPage, 0);
            Controls.SetChildIndex(txtRowsPerPage, 0);
            Controls.SetChildIndex(cbCurrentPage, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(btnShowTransactions, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).EndInit();
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private MyDataGridView dgvAccounts;
        private MyButton btnAdd;
        private MyButton btnEdit;
        private MyButton btnDelete;
        private MyButton btnShowClient;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem addAccountToolStripMenuItem;
        private ToolStripMenuItem editAccountToolStripMenuItem;
        private ToolStripMenuItem deleteAccountToolStripMenuItem;
        private ToolStripMenuItem showClientToolStripMenuItem;
        private ComboBox cbFilterBy;
        private TextBox txtFilterValue;
        private Label lblRecordsCount;
        private MyButton btnClearFilter;
        private Label label2;
        private MyButton btnExport;
        private ToolStripMenuItem exportToCSVToolStripMenuItem;
        private DateTimePicker dtpFilter;
        private Label label1;
        private ComboBox cbCurrentPage;
        private TextBox txtRowsPerPage;
        private MyButton btnLastPage;
        private MyButton btnFirstPage;
        private MyButton btnPrevPage;
        private MyButton btnNextPage;
        private MyButton btnShowTransactions;
        private ToolStripMenuItem showTransactionsToolStripMenuItem;
    }
}