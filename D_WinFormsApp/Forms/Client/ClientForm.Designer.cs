using D_WinFormsApp.Controls;

namespace D_WinFormsApp
{
    partial class ClientForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            btnSave = new MyButton();
            btnCancel = new MyButton();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // lblTime
            // 
            lblTime.Location = new Point(303, 12);
            lblTime.Text = "20:50:42";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(14, 51);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(84, 21);
            lblFullName.TabIndex = 0;
            lblFullName.Text = "Full Name:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(104, 48);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(271, 29);
            txtFullName.TabIndex = 1;
            txtFullName.Leave += txtFullName_Leave;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(14, 89);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(51, 21);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(104, 86);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(271, 29);
            txtEmail.TabIndex = 3;
            txtEmail.Leave += txtEmail_Leave;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(14, 127);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(57, 21);
            lblPhone.TabIndex = 4;
            lblPhone.Text = "Phone:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(104, 124);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(271, 29);
            txtPhone.TabIndex = 5;
            txtPhone.KeyPress += txtPhone_KeyPress;
            txtPhone.Leave += txtPhone_Leave;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(14, 165);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(69, 21);
            lblAddress.TabIndex = 6;
            lblAddress.Text = "Address:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(104, 162);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(271, 29);
            txtAddress.TabIndex = 7;
            txtAddress.Leave += txtAddress_Leave;
            // 
            // btnSave
            // 
            btnSave.Image = Properties.Resources.save;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(181, 209);
            btnSave.Name = "btnSave";
            btnSave.Padding = new Padding(4);
            btnSave.Size = new Size(94, 39);
            btnSave.TabIndex = 8;
            btnSave.Text = "&Save";
            btnSave.TextAlign = ContentAlignment.MiddleRight;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Image = Properties.Resources.cancel;
            btnCancel.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancel.Location = new Point(281, 209);
            btnCancel.Name = "btnCancel";
            btnCancel.Padding = new Padding(2);
            btnCancel.Size = new Size(94, 39);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "&Cancel";
            btnCancel.TextAlign = ContentAlignment.MiddleRight;
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // ClientForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(403, 257);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtAddress);
            Controls.Add(lblAddress);
            Controls.Add(txtPhone);
            Controls.Add(lblPhone);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtFullName);
            Controls.Add(lblFullName);
            Name = "ClientForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Client Details";
            Load += ClientForm_Load;
            Controls.SetChildIndex(lblFullName, 0);
            Controls.SetChildIndex(txtFullName, 0);
            Controls.SetChildIndex(lblEmail, 0);
            Controls.SetChildIndex(txtEmail, 0);
            Controls.SetChildIndex(lblPhone, 0);
            Controls.SetChildIndex(txtPhone, 0);
            Controls.SetChildIndex(lblAddress, 0);
            Controls.SetChildIndex(txtAddress, 0);
            Controls.SetChildIndex(btnSave, 0);
            Controls.SetChildIndex(btnCancel, 0);
            Controls.SetChildIndex(lblTime, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblAddress;
        private TextBox txtAddress;
        private MyButton btnSave;
        private MyButton btnCancel;
        #endregion
    }
}
