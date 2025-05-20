using System.Text.RegularExpressions;

namespace D_WinFormsApp.Controls
{
    public partial class MyDataGridView : DataGridView
    {
        public MyDataGridView()
        {
            InitializeComponent();

            ConfigureBasicSettings();
            StyleColumnHeaders();
        }

        /// <summary>
        /// Sets up grid layout, sizing, and selection behavior.
        /// </summary>
        private void ConfigureBasicSettings()
        {
            // Standard properties
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            BackgroundColor = Color.White;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            EditMode = DataGridViewEditMode.EditProgrammatically;
            MultiSelect = false;
            ReadOnly = true;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            RowHeadersWidth = 51;
            RowTemplate.Height = 29;
            TabStop = false;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); // Color.LightGray still somehow darker than this
            Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right; // Allow resize in all sides
        }

        /// <summary>
        /// Styles column headers with a gray background, no selection highlight.
        /// </summary>
        private void StyleColumnHeaders()
        {
            // differentiate column headers from rows
            ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            // Match selection color to regular background for uniformity with FullRowSelect
            ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightGray;
            EnableHeadersVisualStyles = false;
        }

        protected override void OnDataSourceChanged(EventArgs e)
        {
            base.OnDataSourceChanged(e);
            FormatColumnHeaders();
        }

        private void FormatColumnHeaders()
        {
            foreach (DataGridViewColumn column in Columns)
            {
                string header = column.Name;
                if (!string.IsNullOrEmpty(header))
                {
                    // Split PascalCase and handle special cases like "ID"
                    string formatted = Regex.Replace(header, @"([a-z])([A-Z])", "$1 $2");
                    formatted = Regex.Replace(formatted, @"(\bID\b)", "ID"); // Keep "ID" intact
                    column.HeaderText = formatted;
                }
            }
        }

        /// <summary>
        /// Centralized formatting for Balance columns (currency, color).
        /// </summary>
        protected override void OnCellFormatting(DataGridViewCellFormattingEventArgs e)
        {
            base.OnCellFormatting(e);

            if (e.ColumnIndex < 0 || e.Value == null)
                return;

            var column = this.Columns[e.ColumnIndex];
            if (column.DataPropertyName == "Balance" || column.DataPropertyName == "Amount")
            {
                if (e.Value is decimal balance)
                {
                    //e.Value = balance < 0 ? $"-{balance:C2}" : balance.ToString("C2"); // e.g., -($100.50) or $100.50
                    e.Value = balance.ToString("$#,##0.00"); // e.g., -$100.50 or $100.50
                                                             // Safe: Color.Red and Color.DarkGreen are non-null

                    #pragma warning disable CS8602 // Dereference of a possibly null reference.
                    e.CellStyle.ForeColor = balance < 0 ? Color.Red : Color.DarkGreen;
                    #pragma warning restore CS8602 // Dereference of a possibly null reference.
                    e.FormattingApplied = true;
                }
            }
            //else if (column.DataPropertyName == "CreatedAt")
            //{
            //    if (e.Value is DateTime createdAt)
            //    {
            //        e.Value = createdAt.ToString("MM/dd/yyyy"); // e.g., 04/17/2025
            //        e.FormattingApplied = true;
            //    }
            //}
        }
    }
}