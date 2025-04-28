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
            lblTotalClients = new Label();
            lblTotalAccounts = new Label();
            lblAverageBalance = new Label();
            lblTotalBalance = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // lblTime
            // 
            lblTime.Location = new Point(200, 12);
            lblTime.Text = "15:32:05";
            // 
            // lblTotalClients
            // 
            lblTotalClients.AutoSize = true;
            lblTotalClients.Font = new Font("Arial", 12F);
            lblTotalClients.Location = new Point(20, 42);
            lblTotalClients.Name = "lblTotalClients";
            lblTotalClients.Size = new Size(112, 18);
            lblTotalClients.TabIndex = 0;
            lblTotalClients.Text = "Total Clients: ...";
            // 
            // lblTotalAccounts
            // 
            lblTotalAccounts.AutoSize = true;
            lblTotalAccounts.Font = new Font("Arial", 12F);
            lblTotalAccounts.Location = new Point(20, 82);
            lblTotalAccounts.Name = "lblTotalAccounts";
            lblTotalAccounts.Size = new Size(127, 18);
            lblTotalAccounts.TabIndex = 1;
            lblTotalAccounts.Text = "Total Accounts: ...";
            // 
            // lblAverageBalance
            // 
            lblAverageBalance.AutoSize = true;
            lblAverageBalance.Font = new Font("Arial", 12F);
            lblAverageBalance.Location = new Point(20, 122);
            lblAverageBalance.Name = "lblAverageBalance";
            lblAverageBalance.Size = new Size(148, 18);
            lblAverageBalance.TabIndex = 2;
            lblAverageBalance.Text = "Average Balance: ...";
            // 
            // lblTotalBalance
            // 
            lblTotalBalance.AutoSize = true;
            lblTotalBalance.Font = new Font("Arial", 12F);
            lblTotalBalance.Location = new Point(20, 162);
            lblTotalBalance.Name = "lblTotalBalance";
            lblTotalBalance.Size = new Size(121, 18);
            lblTotalBalance.TabIndex = 3;
            lblTotalBalance.Text = "Total Balance: ...";
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
            Name = "DashboardForm";
            Text = "Bank System Dashboard";
            Controls.SetChildIndex(lblTotalClients, 0);
            Controls.SetChildIndex(lblTotalAccounts, 0);
            Controls.SetChildIndex(lblAverageBalance, 0);
            Controls.SetChildIndex(lblTotalBalance, 0);
            Controls.SetChildIndex(lblTime, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}