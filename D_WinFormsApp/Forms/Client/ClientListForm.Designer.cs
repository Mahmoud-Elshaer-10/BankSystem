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
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // lblTime
            // 
            lblTime.Location = new Point(679, 12);
            lblTime.Text = "14:59:24";
            // 
            // dgvClients
            // 
            dgvClients.AllowUserToAddRows = false;
            dgvClients.AllowUserToDeleteRows = false;
            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvClients.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.LightGray;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvClients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.ContextMenuStrip = contextMenuStrip;
            dgvClients.EnableHeadersVisualStyles = false;
            dgvClients.Location = new Point(12, 100);
            dgvClients.Name = "dgvClients";
            dgvClients.ReadOnly = true;
            dgvClients.RowHeadersWidth = 51;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.Size = new Size(755, 356);
            dgvClients.TabIndex = 0;
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
            toolTip.SetToolTip(btnAdd, "Add (Alt + A)");
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
            cbFilterBy.TabIndex = 5;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            // 
            // txtFilterValue
            // 
            txtFilterValue.Location = new Point(231, 65);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.Size = new Size(170, 29);
            txtFilterValue.TabIndex = 6;
            txtFilterValue.Visible = false;
            txtFilterValue.KeyPress += txtFilterValue_KeyPress;
            // 
            // lblRecordsCount
            // 
            lblRecordsCount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRecordsCount.Location = new Point(552, 66);
            lblRecordsCount.Name = "lblRecordsCount";
            lblRecordsCount.Size = new Size(215, 23);
            lblRecordsCount.TabIndex = 7;
            lblRecordsCount.Text = "0";
            lblRecordsCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnClearFilter
            // 
            btnClearFilter.Image = Properties.Resources.clear;
            btnClearFilter.ImageAlign = ContentAlignment.MiddleLeft;
            btnClearFilter.Location = new Point(419, 64);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.Padding = new Padding(4);
            btnClearFilter.Size = new Size(40, 29);
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
            btnExport.TabIndex = 12;
            btnExport.Text = "E&xport";
            btnExport.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnExport, "Export to CSV (Alt+X)");
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // ClientListForm
            // 
            ClientSize = new Size(779, 472);
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
    }
}