using D_WinFormsApp.Controls;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace D_WinFormsApp
{
    public partial class MyForm : Form
    {
        /// <summary>
        /// Label displaying the current time, updated every second.
        /// </summary>
        protected Label lblTime = new Label();
        private System.Windows.Forms.Timer clockTimer = new System.Windows.Forms.Timer { Interval = 1000 };
        protected ToolTip toolTip = new ToolTip();
        protected System.Windows.Forms.Timer debounceTimer = new System.Windows.Forms.Timer { Interval = 300 };
        protected string pendingFilterValue = "";
        protected ErrorProvider errorProvider = new ErrorProvider();
        private int _initialFormWidth; // Stores initial form width to prevent shrinking
        private int _lastGridWidth = 0; // Stores last known grid width

        public MyForm()
        {
            InitializeComponent();

            SetupKeyHandling();
            InitializeClock();

            errorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError; // Optional: blink on error
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _initialFormWidth = Width; // Set initial width after derived form's InitializeComponent
        }

        protected bool ValidateField(Control control, string value, string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                errorProvider.SetError(control, errorMessage);
                return false;
            }
            errorProvider.SetError(control, "");
            return true;
        }

        /// <summary>
        /// Populates a ComboBox with filterable fields from a type using reflection, formatted as UI-friendly names.
        /// </summary>
        protected void PopulateFilterDropdown<T>(ComboBox filterBy)
        {
            filterBy.Items.Clear();
            filterBy.Items.Add("None");

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance) // still works without arguments
                .Select(p => p.Name)
                .Select(name => Regex.Replace(name, @"([a-z])([A-Z])", "$1 $2")) // e.g., ClientID -> Client ID
                .Select(name => Regex.Replace(name, @"(\bID\b)", "ID")); // Keep "ID" intact

            filterBy.Items.AddRange([.. properties]);
        }

        /// <summary>
        /// Sets up tooltips for filter controls to guide user interaction.
        /// </summary>
        protected void SetupFilterToolTips(ComboBox filterBy, TextBox filterValue, Button clearFilter)
        {
            toolTip.SetToolTip(filterBy, "Select a field to filter by");
            toolTip.SetToolTip(filterValue, "Enter a value to filter the list");
            toolTip.SetToolTip(clearFilter, "Clear the filter");
        }

        /// <summary>
        /// Configures debounce for filter input to delay grid updates until typing stops and applies async filtering using the provided grid and load function.
        /// </summary>
        protected void ConfigureFilterDebounce<T>(TextBox filterValue, ComboBox filterBy,
           MyDataGridView grid, Func<string, string, Task<List<T>>> loadDataAsync, DateTimePicker? dtpFilter = null)
        {
            filterValue.TextChanged += (s, e) =>
            {
                pendingFilterValue = filterValue.Text;
                debounceTimer.Stop(); // Cancel prior timer
                debounceTimer.Start(); // Delay filter 300ms until typing stops
            };

            if (dtpFilter != null)
            {
                dtpFilter.ValueChanged += (s, e) =>
                {
                    pendingFilterValue = dtpFilter.Value.ToString("yyyy-MM-ddTHH:mm:ss");
                    debounceTimer.Stop();
                    debounceTimer.Start();
                };
            }

            debounceTimer.Tick += async (s, e) =>
            {
                debounceTimer.Stop(); // Stop timer immediately
                string value = filterBy.Text == "Created At" && dtpFilter != null && dtpFilter.Visible
                    ? dtpFilter.Value.ToString("yyyy-MM-ddTHH:mm:ss")
                    : filterValue.Text;

                if (filterBy.Text == "Created At" && !string.IsNullOrWhiteSpace(value))
                {
                    if (!DateTime.TryParse(value, out _))
                    {
                        ShowMessage("Invalid date format. Use MM/dd/yyyy, yyyy-MM-dd, or similar.");
                        return;
                    }
                }
                await ApplyFilterAsync(value, filterBy, grid, loadDataAsync);
            };
        }


        /// <summary>
        /// Applies an async filter to the grid, updating the records count and loading data from the API.
        /// </summary>
        protected async Task ApplyFilterAsync<T>(string filterValue, ComboBox filterBy,
            MyDataGridView grid, Func<string, string, Task<List<T>>> loadDataAsync)
        {
            try
            {
                Cursor = Cursors.WaitCursor; // Show wait cursor
                string uiField = filterBy.Text;
                string field = uiField == "None" ? "" : MapFieldToColumn(uiField);
                List<T> data = await loadDataAsync(field, filterValue) ?? [];
                AutoResizeFormToDataGridView(grid); // if called here not derived class, does not get called for initial load
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default; // Reset cursor
            }
        }

        protected void AutoResizeFormToDataGridView(MyDataGridView dataGridView)
        {
            if (dataGridView == null)
                return;

            // Calculate grid width
            int totalWidth = dataGridView.RowHeadersVisible ? dataGridView.RowHeadersWidth : 0;
            if (dataGridView.Columns.Count > 0 && dataGridView.Rows.Count > 0)
            {
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    totalWidth += column.Width;
                }
                totalWidth += SystemInformation.VerticalScrollBarWidth + 12; // Scrollbar/borders
                totalWidth += dataGridView.BorderStyle == BorderStyle.None ? 0 : 6;
                totalWidth += dataGridView.Margin.Left + dataGridView.Margin.Right;

                // Store last known width
                _lastGridWidth = totalWidth;
            }
            else
            {
                // Use last known width for empty data
                totalWidth = _lastGridWidth > 0 ? _lastGridWidth : dataGridView.Width;
            }

            // Get form's non-client width
            int nonClientWidth = Width - ClientSize.Width;

            // Calculate new form width
            int newFormWidth = totalWidth + nonClientWidth + 24;
            newFormWidth = Math.Max(newFormWidth, _initialFormWidth); // Prevent shrinking below initial width

            // Respect screen bounds
            int maxWidth = Screen.PrimaryScreen?.WorkingArea.Width ?? 800;
            newFormWidth = Math.Min(newFormWidth, maxWidth);

            // Update DataGridView and form
            Width = newFormWidth;
            //dataGridView.Width = totalWidth; // automatically resized based on form width

            // Center form if resized significantly
            //if (Math.Abs(Width - newFormWidth) > 50)
            //{
            //Location = new Point(
            //Screen.FromControl(this).WorkingArea.Left + (Screen.FromControl(this).WorkingArea.Width - Width) / 2,
            //            Location.Y);
            //}
        }

        /// <summary>
        /// Maps a UI-friendly field name (e.g., "Client ID") to a database column name (e.g., "ClientID").
        /// </summary>
        private string MapFieldToColumn(string uiField)
        {
            string formatted = Regex.Replace(uiField, @"\s+", ""); // Remove all spaces
            formatted = Regex.Replace(formatted, @"(\bID\b)", "ID"); // Ensure "ID" stays intact
            return formatted;
        }

        /// <summary>
        /// Configures Escape key to close the form.
        /// </summary>
        private void SetupKeyHandling()
        {
            KeyPreview = true;
            KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape)
                {
                    Close();
                }
            };
        }

        /// <summary>
        /// Initializes a live clock in the top-right corner.
        /// </summary>
        private void InitializeClock()
        {
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTime.Location = new Point(this.ClientSize.Width - 100, 12); // Top-right, adjust as needed
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            Controls.Add(lblTime);

            // Update clock every second
            clockTimer.Tick += (s, e) => lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            clockTimer.Start();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            // Keep clock pinned 100px from right edge
            lblTime.Location = new Point(this.ClientSize.Width - 100, 12); // Reposition on resize
        }

        protected void ShowError(string message)
        {
            MessageBox.Show($"An error occurred: {message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected DialogResult ShowMessage(string message, string caption = "Info", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            return MessageBox.Show(message, caption, buttons, icon);
        }

        protected bool ValidateSelection(DataGridView dgv, out object selectedItem)
        {
            selectedItem = dgv.CurrentRow?.DataBoundItem ?? new object();
            if (dgv.CurrentRow == null)
            {
                ShowMessage("Please select an item.");
                return false;
            }
            return true;
        }

        protected void ExportToCsv<T>(DataGridView grid, string defaultFileName)
        {
            if (grid.DataSource is not List<T> data || data.Count == 0)
            {
                ShowMessage("No data to export.");
                return;
            }

            using SaveFileDialog sfd = new()
            {
                Filter = "CSV Files (*.csv)|*.csv",
                FileName = defaultFileName
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                var sb = new StringBuilder();
                var headers = grid.Columns.Cast<DataGridViewColumn>()
                    .Select(c => $"\"{c.HeaderText.Replace("\"", "\"\"")}\"");
                sb.AppendLine(string.Join(",", headers));

                foreach (var item in data)
                {
                    var fields = typeof(T).GetProperties()
                        .Select(p =>
                        {
                            var value = p.GetValue(item)?.ToString() ?? "";
                            return $"\"{value.Replace("\"", "\"\"")}\"";
                        });
                    sb.AppendLine(string.Join(",", fields));
                }

                File.WriteAllText(sfd.FileName, sb.ToString());
                ShowMessage("Export successful!");
            }
            catch (Exception ex)
            {
                ShowError($"Export failed: {ex.Message}");
            }
        }

        protected void EnableSorting<T>(DataGridView grid)
        {
            // Tracks sort direction (ascending true, descending false) for each column by index.
            Dictionary<int, bool> sortDirections = new Dictionary<int, bool>();

            // Attaches an event handler to grid’s header clicks
            grid.ColumnHeaderMouseClick += (s, e) =>
            {
                if (grid.DataSource is not List<T> data || data.Count == 0 || e.ColumnIndex < 0)
                    return;

                var column = grid.Columns[e.ColumnIndex];
                if (column?.DataPropertyName == null)
                    return;

                // Use reflection to Get the PropertyInfo for the column’s property (e.g., Client.FullName)
                var property = typeof(T).GetProperty(column.DataPropertyName);
                if (property == null)
                    return;

                // Toggle sort direction. Sets ascending: If column was sorted, toggles direction; else defaults to true (ascending).
                bool ascending = sortDirections.ContainsKey(e.ColumnIndex) ? !sortDirections[e.ColumnIndex] : true;
                sortDirections[e.ColumnIndex] = ascending;

                // Sort the data based on the property value using LINQ
                List<T> sorted = ascending
                    ? data.OrderBy(x => property.GetValue(x)).ToList()
                    : data.OrderByDescending(x => property.GetValue(x)).ToList();

                // Update the DataGridView with the sorted data
                grid.DataSource = sorted;

                // Clears sort arrows from all columns except the clicked one.
                foreach (DataGridViewColumn c in grid.Columns)
                    if (c.Index != e.ColumnIndex)
                        c.HeaderCell.SortGlyphDirection = SortOrder.None;

                // Sets the sort arrow for the clicked column.
                if (grid.Columns[e.ColumnIndex].DataGridView == grid)
                    grid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = ascending ? SortOrder.Ascending : SortOrder.Descending;
            };
        }
    }
}