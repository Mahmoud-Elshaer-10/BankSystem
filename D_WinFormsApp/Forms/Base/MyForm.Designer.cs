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
            // MyForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(484, 261);
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
        }

        #endregion

        protected Button btnInvisible;
    }
}