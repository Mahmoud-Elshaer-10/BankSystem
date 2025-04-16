using D_WinFormsApp.Controls;
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dgvAccounts = new MyDataGridView();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).BeginInit();
            SuspendLayout();
            // 
            // lblTime
            // 
            lblTime.Location = new Point(400, 12);
            lblTime.Text = "21:55:27";
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
            dgvAccounts.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvAccounts.EnableHeadersVisualStyles = false;
            dgvAccounts.Location = new Point(12, 49);
            dgvAccounts.MultiSelect = false;
            dgvAccounts.Name = "dgvAccounts";
            dgvAccounts.ReadOnly = true;
            dgvAccounts.RowHeadersWidth = 51;
            dgvAccounts.RowTemplate.Height = 29;
            dgvAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAccounts.Size = new Size(476, 201);
            dgvAccounts.TabIndex = 0;
            dgvAccounts.TabStop = false;
            dgvAccounts.CellFormatting += dgvAccounts_CellFormatting;
            // 
            // ClientAccountsForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 265);
            Controls.Add(dgvAccounts);
            Name = "ClientAccountsForm";
            Text = "Client Accounts";
            Load += ClientAccountsForm_Load;
            Controls.SetChildIndex(dgvAccounts, 0);
            Controls.SetChildIndex(lblTime, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private MyDataGridView dgvAccounts;
    }
}