namespace D_WinFormsApp
{
    partial class TransactionForm
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
            lblFromAccountID = new Label();
            txtFromAccountID = new TextBox();
            lblTransactionType = new Label();
            cbTransactionType = new ComboBox();
            lblAmount = new Label();
            txtAmount = new TextBox();
            lblToAccountID = new Label();
            txtToAccountID = new TextBox();
            btnSave = new D_WinFormsApp.Controls.MyButton();
            btnCancel = new D_WinFormsApp.Controls.MyButton();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // lblTime
            // 
            lblTime.Location = new Point(265, 12);
            lblTime.Size = new Size(75, 19);
            lblTime.Text = "16:17:22";
            // 
            // lblFromAccountID
            // 
            lblFromAccountID.AutoSize = true;
            lblFromAccountID.Location = new Point(14, 51);
            lblFromAccountID.Name = "lblFromAccountID";
            lblFromAccountID.Size = new Size(110, 21);
            lblFromAccountID.TabIndex = 0;
            lblFromAccountID.Text = "From Account:";
            // 
            // txtFromAccountID
            // 
            txtFromAccountID.Enabled = false;
            txtFromAccountID.Location = new Point(134, 48);
            txtFromAccountID.Name = "txtFromAccountID";
            txtFromAccountID.Size = new Size(194, 29);
            txtFromAccountID.TabIndex = 1;
            toolTip.SetToolTip(txtFromAccountID, "Source account ID");
            // 
            // lblTransactionType
            // 
            lblTransactionType.AutoSize = true;
            lblTransactionType.Location = new Point(14, 89);
            lblTransactionType.Name = "lblTransactionType";
            lblTransactionType.Size = new Size(45, 21);
            lblTransactionType.TabIndex = 2;
            lblTransactionType.Text = "Type:";
            // 
            // cbTransactionType
            // 
            cbTransactionType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTransactionType.Items.AddRange(new object[] { "Deposit", "Withdraw", "Transfer" });
            cbTransactionType.Location = new Point(134, 86);
            cbTransactionType.Name = "cbTransactionType";
            cbTransactionType.Size = new Size(194, 29);
            cbTransactionType.TabIndex = 2;
            toolTip.SetToolTip(cbTransactionType, "Select transaction type");
            cbTransactionType.SelectedIndexChanged += cbTransactionType_SelectedIndexChanged;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(14, 127);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(69, 21);
            lblAmount.TabIndex = 4;
            lblAmount.Text = "Amount:";
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(134, 124);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(194, 29);
            txtAmount.TabIndex = 3;
            toolTip.SetToolTip(txtAmount, "Enter transaction amount");
            txtAmount.KeyPress += txtAmount_KeyPress;
            txtAmount.Leave += txtAmount_Leave;
            // 
            // lblToAccountID
            // 
            lblToAccountID.AutoSize = true;
            lblToAccountID.Location = new Point(14, 165);
            lblToAccountID.Name = "lblToAccountID";
            lblToAccountID.Size = new Size(88, 21);
            lblToAccountID.TabIndex = 6;
            lblToAccountID.Text = "To Account:";
            lblToAccountID.Visible = false;
            // 
            // txtToAccountID
            // 
            txtToAccountID.Location = new Point(134, 162);
            txtToAccountID.Name = "txtToAccountID";
            txtToAccountID.Size = new Size(194, 29);
            txtToAccountID.TabIndex = 4;
            toolTip.SetToolTip(txtToAccountID, "Destination account ID for transfers");
            txtToAccountID.Visible = false;
            txtToAccountID.KeyPress += txtToAccountID_KeyPress;
            txtToAccountID.Leave += txtToAccountID_Leave;
            // 
            // btnSave
            // 
            btnSave.Image = Properties.Resources.save;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(134, 206);
            btnSave.Name = "btnSave";
            btnSave.Padding = new Padding(4);
            btnSave.Size = new Size(94, 39);
            btnSave.TabIndex = 5;
            btnSave.Text = "&Save";
            btnSave.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnSave, "Save (Alt+S)");
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Image = Properties.Resources.cancel;
            btnCancel.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancel.Location = new Point(234, 206);
            btnCancel.Name = "btnCancel";
            btnCancel.Padding = new Padding(2);
            btnCancel.Size = new Size(94, 39);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "&Cancel";
            btnCancel.TextAlign = ContentAlignment.MiddleRight;
            toolTip.SetToolTip(btnCancel, "Cancel (Alt+C)");
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // TransactionForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(365, 261);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtToAccountID);
            Controls.Add(lblToAccountID);
            Controls.Add(txtAmount);
            Controls.Add(lblAmount);
            Controls.Add(cbTransactionType);
            Controls.Add(lblTransactionType);
            Controls.Add(txtFromAccountID);
            Controls.Add(lblFromAccountID);
            MinimumSize = new Size(136, 88);
            Name = "TransactionForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bank System - Add Transaction";
            Load += TransactionForm_Load;
            Controls.SetChildIndex(btnInvisible, 0);
            Controls.SetChildIndex(lblTime, 0);
            Controls.SetChildIndex(lblFromAccountID, 0);
            Controls.SetChildIndex(txtFromAccountID, 0);
            Controls.SetChildIndex(lblTransactionType, 0);
            Controls.SetChildIndex(cbTransactionType, 0);
            Controls.SetChildIndex(lblAmount, 0);
            Controls.SetChildIndex(txtAmount, 0);
            Controls.SetChildIndex(lblToAccountID, 0);
            Controls.SetChildIndex(txtToAccountID, 0);
            Controls.SetChildIndex(btnSave, 0);
            Controls.SetChildIndex(btnCancel, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblFromAccountID;
        private TextBox txtFromAccountID;
        private Label lblTransactionType;
        private ComboBox cbTransactionType;
        private Label lblAmount;
        private TextBox txtAmount;
        private Label lblToAccountID;
        private TextBox txtToAccountID;
        private Controls.MyButton btnSave;
        private Controls.MyButton btnCancel;
    }
}