using D_WinFormsApp.Controls;

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
            dgvAccounts = new MyDataGridView();
            contextMenuStrip = new ContextMenuStrip(components);
            addAccountToolStripMenuItem = new ToolStripMenuItem();
            editAccountToolStripMenuItem = new ToolStripMenuItem();
            deleteAccountToolStripMenuItem = new ToolStripMenuItem();
            showClientToolStripMenuItem = new ToolStripMenuItem();
            btnAdd = new MyButton();
            btnEdit = new MyButton();
            btnDelete = new MyButton();
            btnShowClient = new MyButton();
            cbFilterBy = new ComboBox();
            txtFilterValue = new TextBox();
            lblRecordsCount = new Label();
            btnClearFilter = new MyButton();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).BeginInit();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // lblTime
            // 
            lblTime.Location = new Point(542, 12);
            lblTime.Text = "14:51:26";
            // 
            // dgvAccounts
            // 
            dgvAccounts.AllowUserToAddRows = false;
            dgvAccounts.AllowUserToDeleteRows = false;
            dgvAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvAccounts.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.LightGray;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvAccounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccounts.ContextMenuStrip = contextMenuStrip;
            dgvAccounts.EnableHeadersVisualStyles = false;
            dgvAccounts.Location = new Point(12, 97);
            dgvAccounts.Name = "dgvAccounts";
            dgvAccounts.ReadOnly = true;
            dgvAccounts.RowHeadersWidth = 51;
            dgvAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAccounts.Size = new Size(617, 356);
            dgvAccounts.TabIndex = 0;
            dgvAccounts.DoubleClick += dgvAccounts_DoubleClick;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { addAccountToolStripMenuItem, editAccountToolStripMenuItem, deleteAccountToolStripMenuItem, showClientToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(156, 92);
            // 
            // addAccountToolStripMenuItem
            // 
            addAccountToolStripMenuItem.Image = Properties.Resources.AddIcon;
            addAccountToolStripMenuItem.Name = "addAccountToolStripMenuItem";
            addAccountToolStripMenuItem.Size = new Size(155, 22);
            addAccountToolStripMenuItem.Text = "Add Account";
            addAccountToolStripMenuItem.Click += addAccountToolStripMenuItem_Click;
            // 
            // editAccountToolStripMenuItem
            // 
            editAccountToolStripMenuItem.Image = Properties.Resources.EditIcon;
            editAccountToolStripMenuItem.Name = "editAccountToolStripMenuItem";
            editAccountToolStripMenuItem.Size = new Size(155, 22);
            editAccountToolStripMenuItem.Text = "Edit Account";
            editAccountToolStripMenuItem.Click += editAccountToolStripMenuItem_Click;
            // 
            // deleteAccountToolStripMenuItem
            // 
            deleteAccountToolStripMenuItem.Image = Properties.Resources.DeleteIcon;
            deleteAccountToolStripMenuItem.Name = "deleteAccountToolStripMenuItem";
            deleteAccountToolStripMenuItem.Size = new Size(155, 22);
            deleteAccountToolStripMenuItem.Text = "Delete Account";
            deleteAccountToolStripMenuItem.Click += deleteAccountToolStripMenuItem_Click;
            // 
            // showClientToolStripMenuItem
            // 
            showClientToolStripMenuItem.Image = Properties.Resources.ShowIcon;
            showClientToolStripMenuItem.Name = "showClientToolStripMenuItem";
            showClientToolStripMenuItem.Size = new Size(155, 22);
            showClientToolStripMenuItem.Text = "Show Client";
            showClientToolStripMenuItem.Click += showClientToolStripMenuItem_Click;
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
            btnAdd.Text = "Add";
            btnAdd.TextAlign = ContentAlignment.MiddleRight;
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Image = Properties.Resources.EditIcon;
            btnEdit.ImageAlign = ContentAlignment.MiddleLeft;
            btnEdit.Location = new Point(106, 12);
            btnEdit.Name = "btnEdit";
            btnEdit.Padding = new Padding(4);
            btnEdit.Size = new Size(86, 37);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Edit";
            btnEdit.TextAlign = ContentAlignment.MiddleRight;
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Image = Properties.Resources.DeleteIcon;
            btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            btnDelete.Location = new Point(200, 12);
            btnDelete.Name = "btnDelete";
            btnDelete.Padding = new Padding(2);
            btnDelete.Size = new Size(95, 37);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.TextAlign = ContentAlignment.MiddleRight;
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnShowClient
            // 
            btnShowClient.Image = Properties.Resources.ShowIcon;
            btnShowClient.ImageAlign = ContentAlignment.MiddleLeft;
            btnShowClient.Location = new Point(303, 12);
            btnShowClient.Name = "btnShowClient";
            btnShowClient.Padding = new Padding(4);
            btnShowClient.Size = new Size(135, 37);
            btnShowClient.TabIndex = 4;
            btnShowClient.Text = "Show Client";
            btnShowClient.TextAlign = ContentAlignment.MiddleRight;
            btnShowClient.UseVisualStyleBackColor = true;
            btnShowClient.Click += btnShowClient_Click;
            // 
            // cbFilterBy
            // 
            cbFilterBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterBy.Items.AddRange(new object[] { "None", "Account ID", "Client ID", "Balance" });
            cbFilterBy.Location = new Point(93, 63);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new Size(120, 29);
            cbFilterBy.TabIndex = 5;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            // 
            // txtFilterValue
            // 
            txtFilterValue.Location = new Point(226, 63);
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.Size = new Size(170, 29);
            txtFilterValue.TabIndex = 6;
            txtFilterValue.Visible = false;
            txtFilterValue.KeyPress += txtFilterValue_KeyPress;
            // 
            // lblRecordsCount
            // 
            lblRecordsCount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRecordsCount.Location = new Point(468, 63);
            lblRecordsCount.Name = "lblRecordsCount";
            lblRecordsCount.Size = new Size(161, 23);
            lblRecordsCount.TabIndex = 7;
            lblRecordsCount.Text = "0";
            lblRecordsCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnClearFilter
            // 
            btnClearFilter.Image = Properties.Resources.clear;
            btnClearFilter.Location = new Point(410, 63);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.Size = new Size(29, 29);
            btnClearFilter.TabIndex = 8;
            btnClearFilter.UseVisualStyleBackColor = true;
            btnClearFilter.Visible = false;
            btnClearFilter.Click += btnClearFilter_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(12, 66);
            label2.Name = "label2";
            label2.Size = new Size(76, 21);
            label2.TabIndex = 12;
            label2.Text = "Filter By:";
            // 
            // AccountListForm
            // 
            ClientSize = new Size(642, 466);
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
            Name = "AccountListForm";
            Text = "Bank System - Account List";
            Load += AccountListForm_Load;
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
    }
}