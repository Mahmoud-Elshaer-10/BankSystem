using D_WinFormsApp.Controls;
namespace D_WinFormsApp
{
    partial class ClientListForm
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
            dgvClients = new MyDataGridView();
            contextMenuStrip = new ContextMenuStrip(components);
            addClientToolStripMenuItem = new ToolStripMenuItem();
            editClientToolStripMenuItem = new ToolStripMenuItem();
            deleteClientToolStripMenuItem = new ToolStripMenuItem();
            showAccountsToolStripMenuItem = new ToolStripMenuItem();
            exportToCSVToolStripMenuItem = new ToolStripMenuItem();
            btnAdd = new MyButton();
            btnEdit = new MyButton();
            btnDelete = new MyButton();
            btnShowAccounts = new MyButton();
            cbFilterBy = new ComboBox();
            txtFilterValue = new TextBox();
            lblRecordsCount = new Label();
            btnClearFilter = new MyButton();
            label2 = new Label();
            btnExport = new MyButton();
            dtpFilter = new DateTimePicker();
            btnNextPage = new MyButton();
            btnPrevPage = new MyButton();
            btnFirstPage = new MyButton();
            btnLastPage = new MyButton();
            txtRowsPerPage = new TextBox();
            cbCurrentPage = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // lblTime
            // 
            lblTime.Location = new Point(599, 12);
            lblTime.Text = "14:26:30";
            // 
            // dgvClients
            // 
            dgvClients.AllowUserToAddRows = false;
            dgvClients.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 240, 240);
            dgvClients.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvClients.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvClients.BackgroundColor = Color.White;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.LightGray;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvClients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.ContextMenuStrip = contextMenuStrip;
            dgvClients.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvClients.EnableHeadersVisualStyles = false;
            dgvClients.Location = new Point(12, 100);
            dgvClients.MultiSelect = false;
            dgvClients.Name = "dgvClients";
            dgvClients.ReadOnly = true;
            dgvClients.RowHeadersWidth = 51;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.ShowCellToolTips = false;
            dgvClients.Size = new Size(673, 352);
            dgvClients.TabIndex = 0;
            dgvClients.TabStop = false;
            dgvClients.DoubleClick += dgvClients_DoubleClick;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { addClientToolStripMenuItem, editClientToolStripMenuItem, deleteClientToolStripMenuItem, showAccountsToolStripMenuItem, exportToCSVToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(193, 114);
            // 
            // addClientToolStripMenuItem
            // 
            addClientToolStripMenuItem.Image = Properties.Resources.AddIcon;
            addClientToolStripMenuItem.Name = "addClientToolStripMenuItem";
            addClientToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.A;
            addClientToolStripMenuItem.Size = new Size(192, 22);
            addClientToolStripMenuItem.Text = "Add Client";
            addClientToolStripMenuItem.Click += addClientToolStripMenuItem_Click;
            // 
            // editClientToolStripMenuItem
            // 
            editClientToolStripMenuItem.Image = Properties.Resources.EditIcon;
            editClientToolStripMenuItem.Name = "editClientToolStripMenuItem";
            editClientToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.E;
            editClientToolStripMenuItem.Size = new Size(192, 22);
            editClientToolStripMenuItem.Text = "Edit Client";
            editClientToolStripMenuItem.Click += editClientToolStripMenuItem_Click;
            // 
            // deleteClientToolStripMenuItem
            // 
            deleteClientToolStripMenuItem.Image = Properties.Resources.DeleteIcon;
            deleteClientToolStripMenuItem.Name = "deleteClientToolStripMenuItem";
            deleteClientToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.D;
            deleteClientToolStripMenuItem.Size = new Size(192, 22);
            deleteClientToolStripMenuItem.Text = "Delete Client";
            deleteClientToolStripMenuItem.Click += deleteClientToolStripMenuItem_Click;
            // 
            // showAccountsToolStripMenuItem
            // 
            showAccountsToolStripMenuItem.Image = Properties.Resources.ShowIcon;
            showAccountsToolStripMenuItem.Name = "showAccountsToolStripMenuItem";
            showAccountsToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.S;
            showAccountsToolStripMenuItem.Size = new Size(192, 22);
            showAccountsToolStripMenuItem.Text = "Show Accounts";
            showAccountsToolStripMenuItem.Click += showAccountsToolStripMenuItem_Click;
            // 
            // exportToCSVToolStripMenuItem
            // 
            exportToCSVToolStripMenuItem.Image = Properties.Resources.notes;
            exportToCSVToolStripMenuItem.Name = "exportToCSVToolStripMenuItem";
            exportToCSVToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.X;
            exportToCSVToolStripMenuItem.Size = new Size(192, 22);
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
            btnEdit.Location = new Point(102, 12);
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
            btnDelete.Location = new Point(192, 12);
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
            // btnShowAccounts
            // 
            btnShowAccounts.Image = Properties.Resources.ShowIcon;
            btnShowAccounts.ImageAlign = ContentAlignment.MiddleLeft;
            btnShowAccounts.Location = new Point(291, 12);
            btnShowAccounts.Name = "btnShowAccounts";
            btnShowAccounts.Padding = new Padding(4);
            btnShowAccounts.Size = new Size(157, 37);
            btnShowAccounts.TabIndex = 4;
            btnShowAccounts.Text = "&Show Accounts";
            btnShowAccounts.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnShowAccounts, "Show Accounts (Alt+S)");
            btnShowAccounts.UseVisualStyleBackColor = true;
            btnShowAccounts.Click += btnShowAccounts_Click;
            // 
            // cbFilterBy
            // 
            cbFilterBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterBy.Items.AddRange(new object[] { "None", "Client ID", "Full Name", "Email" });
            cbFilterBy.Location = new Point(93, 65);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new Size(120, 29);
            cbFilterBy.TabIndex = 6;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            // 
            // txtFilterValue
            // 
            txtFilterValue.Location = new Point(231, 65);
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
            btnClearFilter.Location = new Point(407, 65);
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
            btnExport.Location = new Point(452, 12);
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
            dtpFilter.Location = new Point(231, 65);
            dtpFilter.Name = "dtpFilter";
            dtpFilter.Size = new Size(128, 29);
            dtpFilter.TabIndex = 14;
            dtpFilter.Visible = false;
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
            btnNextPage.Location = new Point(241, 459);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Padding = new Padding(4);
            btnNextPage.Size = new Size(81, 37);
            btnNextPage.TabIndex = 15;
            btnNextPage.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnNextPage, "Next Page");
            btnNextPage.UseVisualStyleBackColor = false;
            btnNextPage.Click += btnNextPage_Click;
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
            btnPrevPage.Location = new Point(72, 459);
            btnPrevPage.Name = "btnPrevPage";
            btnPrevPage.Padding = new Padding(4);
            btnPrevPage.Size = new Size(81, 37);
            btnPrevPage.TabIndex = 16;
            btnPrevPage.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnPrevPage, "Previous Page");
            btnPrevPage.UseVisualStyleBackColor = true;
            btnPrevPage.Click += btnPrevPage_Click;
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
            btnFirstPage.Location = new Point(12, 459);
            btnFirstPage.Name = "btnFirstPage";
            btnFirstPage.Padding = new Padding(4);
            btnFirstPage.Size = new Size(47, 37);
            btnFirstPage.TabIndex = 17;
            btnFirstPage.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnFirstPage, "First Page");
            btnFirstPage.UseVisualStyleBackColor = true;
            btnFirstPage.Click += btnFirstPage_Click;
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
            btnLastPage.Location = new Point(335, 459);
            btnLastPage.Name = "btnLastPage";
            btnLastPage.Padding = new Padding(4);
            btnLastPage.Size = new Size(47, 37);
            btnLastPage.TabIndex = 18;
            btnLastPage.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnLastPage, "Last Page");
            btnLastPage.UseVisualStyleBackColor = true;
            btnLastPage.Click += btnLastPage_Click;
            // 
            // txtRowsPerPage
            // 
            txtRowsPerPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtRowsPerPage.Location = new Point(527, 463);
            txtRowsPerPage.Name = "txtRowsPerPage";
            txtRowsPerPage.Size = new Size(73, 29);
            txtRowsPerPage.TabIndex = 19;
            txtRowsPerPage.Text = "10";
            toolTip.SetToolTip(txtRowsPerPage, "Rows per page");
            txtRowsPerPage.TextChanged += txtRowsPerPage_TextChanged;
            txtRowsPerPage.KeyPress += txtRowsPerPage_KeyPress;
            // 
            // cbCurrentPage
            // 
            cbCurrentPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cbCurrentPage.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCurrentPage.Location = new Point(166, 463);
            cbCurrentPage.Name = "cbCurrentPage";
            cbCurrentPage.Size = new Size(62, 29);
            cbCurrentPage.TabIndex = 20;
            toolTip.SetToolTip(cbCurrentPage, "Select page");
            cbCurrentPage.SelectedIndexChanged += cbCurrentPage_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(407, 467);
            label1.Name = "label1";
            label1.Size = new Size(114, 21);
            label1.TabIndex = 21;
            label1.Text = "Rows Per Page:";
            // 
            // ClientListForm
            // 
            ClientSize = new Size(699, 503);
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
            Controls.Add(btnShowAccounts);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dgvClients);
            Name = "ClientListForm";
            Text = "Bank System - Client List";
            Load += ClientListForm_Load;
            Controls.SetChildIndex(btnInvisible, 0);
            Controls.SetChildIndex(dgvClients, 0);
            Controls.SetChildIndex(btnAdd, 0);
            Controls.SetChildIndex(btnEdit, 0);
            Controls.SetChildIndex(btnDelete, 0);
            Controls.SetChildIndex(btnShowAccounts, 0);
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
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private MyDataGridView dgvClients;
        private MyButton btnAdd;
        private MyButton btnEdit;
        private MyButton btnDelete;
        private MyButton btnShowAccounts;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem addClientToolStripMenuItem;
        private ToolStripMenuItem editClientToolStripMenuItem;
        private ToolStripMenuItem deleteClientToolStripMenuItem;
        private ToolStripMenuItem showAccountsToolStripMenuItem;
        private ComboBox cbFilterBy;
        private TextBox txtFilterValue;
        private Label lblRecordsCount;
        private MyButton btnClearFilter;
        private Label label2;
        private MyButton btnExport;
        private ToolStripMenuItem exportToCSVToolStripMenuItem;
        private DateTimePicker dtpFilter;
        private MyButton btnNextPage;
        private MyButton btnPrevPage;
        private MyButton btnFirstPage;
        private MyButton btnLastPage;
        private TextBox txtRowsPerPage;
        private ComboBox cbCurrentPage;
        private Label label1;
    }
}