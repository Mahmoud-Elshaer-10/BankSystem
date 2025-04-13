using D_WinFormsApp.Controls;

namespace D_WinFormsApp
{
    partial class AccountForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            txtClientID = new TextBox();
            txtBalance = new TextBox();
            lblClientID = new Label();
            lblBalance = new Label();
            btnSave = new MyButton();
            btnCancel = new MyButton();
            SuspendLayout();
            // 
            // lblTime
            // 
            lblTime.Location = new Point(264, 12);
            lblTime.Text = "13:45:12";
            // 
            // txtClientID
            // 
            txtClientID.Location = new Point(122, 42);
            txtClientID.Name = "txtClientID";
            txtClientID.Size = new Size(200, 29);
            txtClientID.TabIndex = 0;
            // 
            // txtBalance
            // 
            txtBalance.Location = new Point(122, 82);
            txtBalance.Name = "txtBalance";
            txtBalance.Size = new Size(200, 29);
            txtBalance.TabIndex = 1;
            // 
            // lblClientID
            // 
            lblClientID.AutoSize = true;
            lblClientID.Location = new Point(42, 45);
            lblClientID.Name = "lblClientID";
            lblClientID.Size = new Size(72, 21);
            lblClientID.TabIndex = 2;
            lblClientID.Text = "Client ID:";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Location = new Point(42, 85);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(66, 21);
            lblBalance.TabIndex = 3;
            lblBalance.Text = "Balance:";
            // 
            // btnSave
            // 
            btnSave.Image = Properties.Resources.save;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(122, 122);
            btnSave.Name = "btnSave";
            btnSave.Padding = new Padding(4);
            btnSave.Size = new Size(94, 39);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.TextAlign = ContentAlignment.MiddleRight;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Image = Properties.Resources.cancel;
            btnCancel.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancel.Location = new Point(228, 122);
            btnCancel.Name = "btnCancel";
            btnCancel.Padding = new Padding(2);
            btnCancel.Size = new Size(94, 39);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.TextAlign = ContentAlignment.MiddleRight;
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // AccountForm
            // 
            AcceptButton = btnSave;
            CancelButton = btnCancel;
            ClientSize = new Size(364, 175);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(lblBalance);
            Controls.Add(lblClientID);
            Controls.Add(txtBalance);
            Controls.Add(txtClientID);
            Name = "AccountForm";
            Text = "Account Form";
            Load += AccountForm_Load;
            Controls.SetChildIndex(txtClientID, 0);
            Controls.SetChildIndex(txtBalance, 0);
            Controls.SetChildIndex(lblClientID, 0);
            Controls.SetChildIndex(lblBalance, 0);
            Controls.SetChildIndex(btnSave, 0);
            Controls.SetChildIndex(btnCancel, 0);
            Controls.SetChildIndex(lblTime, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtClientID;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label lblClientID;
        private System.Windows.Forms.Label lblBalance;
        private MyButton btnSave;
        private MyButton btnCancel;
    }
}
