using D_WinFormsApp.Controls;

namespace D_WinFormsApp
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTotalClients;
        private Label lblTotalAccounts;
        private Label lblAverageBalance;
        private Label lblTotalBalance;
        private ToolTip toolTip;

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
            toolTip = new ToolTip(components);
            lblTotalClients = new Label();
            lblTotalAccounts = new Label();
            lblAverageBalance = new Label();
            lblTotalBalance = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // lblTotalClients
            // 
            lblTotalClients.AutoSize = true;
            lblTotalClients.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTotalClients.Location = new Point(20, 20);
            lblTotalClients.Name = "lblTotalClients";
            lblTotalClients.Size = new Size(150, 30);
            lblTotalClients.TabIndex = 0;
            lblTotalClients.Text = "Total Clients: ...";
            toolTip.SetToolTip(lblTotalClients, "Number of clients in the system");
            // 
            // lblTotalAccounts
            // 
            lblTotalAccounts.AutoSize = true;
            lblTotalAccounts.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTotalAccounts.Location = new Point(20, 60);
            lblTotalAccounts.Name = "lblTotalAccounts";
            lblTotalAccounts.Size = new Size(150, 30);
            lblTotalAccounts.TabIndex = 1;
            lblTotalAccounts.Text = "Total Accounts: ...";
            toolTip.SetToolTip(lblTotalAccounts, "Number of accounts in the system");
            // 
            // lblAverageBalance
            // 
            lblAverageBalance.AutoSize = true;
            lblAverageBalance.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblAverageBalance.Location = new Point(20, 100);
            lblAverageBalance.Name = "lblAverageBalance";
            lblAverageBalance.Size = new Size(150, 30);
            lblAverageBalance.TabIndex = 2;
            lblAverageBalance.Text = "Average Balance: ...";
            toolTip.SetToolTip(lblAverageBalance, "Average balance across all accounts");
            // 
            // lblTotalBalance
            // 
            lblTotalBalance.AutoSize = true;
            lblTotalBalance.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTotalBalance.Location = new Point(20, 140);
            lblTotalBalance.Name = "lblTotalBalance";
            lblTotalBalance.Size = new Size(150, 30);
            lblTotalBalance.TabIndex = 3;
            lblTotalBalance.Text = "Total Balance: ...";
            toolTip.SetToolTip(lblTotalBalance, "Sum of all account balances");
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 200);
            Controls.Add(lblTotalBalance);
            Controls.Add(lblAverageBalance);
            Controls.Add(lblTotalAccounts);
            Controls.Add(lblTotalClients);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "DashboardForm";
            Text = "Bank System Dashboard";
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}