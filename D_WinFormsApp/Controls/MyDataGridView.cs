using System.Text.RegularExpressions;
using System.Windows.Forms;

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
    }
}