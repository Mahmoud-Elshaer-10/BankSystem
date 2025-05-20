using D_WinFormsApp.Controls;

namespace D_WinFormsApp
{
    partial class MainForm
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
            btnClients = new MyButton();
            btnAccounts = new MyButton();
            btnDashboard = new MyButton();
            btnTransactions = new MyButton();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // lblTime
            // 
            lblTime.Location = new Point(184, 12);
            lblTime.Size = new Size(75, 19);
            lblTime.Text = "15:26:49";
            // 
            // btnClients
            // 
            btnClients.Image = Properties.Resources.user__1_;
            btnClients.ImageAlign = ContentAlignment.MiddleLeft;
            btnClients.Location = new Point(49, 46);
            btnClients.Name = "btnClients";
            btnClients.Padding = new Padding(4);
            btnClients.Size = new Size(186, 44);
            btnClients.TabIndex = 1;
            btnClients.Text = "Manage &Clients";
            btnClients.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnClients, "Show Clients (Alt+C)");
            btnClients.UseVisualStyleBackColor = true;
            btnClients.Click += btnClients_Click;
            // 
            // btnAccounts
            // 
            btnAccounts.Image = Properties.Resources.wallet;
            btnAccounts.ImageAlign = ContentAlignment.MiddleLeft;
            btnAccounts.Location = new Point(49, 105);
            btnAccounts.Name = "btnAccounts";
            btnAccounts.Padding = new Padding(4);
            btnAccounts.Size = new Size(186, 44);
            btnAccounts.TabIndex = 2;
            btnAccounts.Text = "Manage &Accounts";
            btnAccounts.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnAccounts, "Show Accounts (Alt+A)");
            btnAccounts.UseVisualStyleBackColor = true;
            btnAccounts.Click += btnAccounts_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.Image = Properties.Resources.graph;
            btnDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnDashboard.Location = new Point(49, 223);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(4);
            btnDashboard.Size = new Size(186, 44);
            btnDashboard.TabIndex = 4;
            btnDashboard.Text = "&Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnDashboard, "Show Dashboard (Alt+D)");
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // btnTransactions
            // 
            btnTransactions.Image = Properties.Resources.Transactions1;
            btnTransactions.ImageAlign = ContentAlignment.MiddleLeft;
            btnTransactions.Location = new Point(49, 164);
            btnTransactions.Name = "btnTransactions";
            btnTransactions.Padding = new Padding(4);
            btnTransactions.Size = new Size(186, 44);
            btnTransactions.TabIndex = 3;
            btnTransactions.Text = "&Transactions";
            btnTransactions.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnTransactions, "Show Transactions (Alt+T)");
            btnTransactions.UseVisualStyleBackColor = true;
            btnTransactions.Click += btnTransactions_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 306);
            Controls.Add(btnTransactions);
            Controls.Add(btnDashboard);
            Controls.Add(btnAccounts);
            Controls.Add(btnClients);
            MinimizeBox = true;
            MinimumSize = new Size(300, 300);
            Name = "MainForm";
            ShowInTaskbar = true;
            Text = "Bank System";
            Controls.SetChildIndex(btnInvisible, 0);
            Controls.SetChildIndex(btnClients, 0);
            Controls.SetChildIndex(btnAccounts, 0);
            Controls.SetChildIndex(btnDashboard, 0);
            Controls.SetChildIndex(lblTime, 0);
            Controls.SetChildIndex(btnTransactions, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private MyButton btnClients;
        private MyButton btnAccounts;
        private MyButton btnDashboard;
        private MyButton btnTransactions;
    }
}