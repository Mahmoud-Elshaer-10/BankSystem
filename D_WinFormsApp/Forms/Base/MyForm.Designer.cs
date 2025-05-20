namespace D_WinFormsApp
{
    partial class MyForm
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyForm));
            btnInvisible = new Button();
            lblTime = new Label();
            SuspendLayout();
            // 
            // btnInvisible
            // 
            btnInvisible.Location = new Point(-100, 12);
            btnInvisible.Name = "btnInvisible";
            btnInvisible.Size = new Size(75, 23);
            btnInvisible.TabIndex = 0;
            btnInvisible.UseVisualStyleBackColor = true;
            // 
            // lblTime
            // 
            lblTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTime.Location = new Point(220, 9);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(46, 19);
            lblTime.TabIndex = 0;
            lblTime.Text = "Time";
            // 
            // MyForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(284, 261);
            Controls.Add(lblTime);
            Controls.Add(btnInvisible);
            Font = new Font("Segoe UI", 12F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MyForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MyForm";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected Button btnInvisible;
        protected Label lblTime;
    }
}