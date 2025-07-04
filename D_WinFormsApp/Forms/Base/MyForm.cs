﻿using D_WinFormsApp.Controls;
using D_WinFormsApp.Helpers;
using D_WinFormsApp.Models;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace D_WinFormsApp
{
    public partial class MyForm : Form
    {
        private int _initialFormWidth; // Stores initial form width to prevent shrinking
        private int _lastGridWidth = 0; // Stores last known grid width

        // Pagination
        protected int CurrentPage { get; set; } = 1;
        protected int RowsPerPage { get; set; } = 10;
        protected int TotalPages { get; set; }
        protected string CurrentFilterField { get; set; } = "";
        protected string CurrentFilterValue { get; set; } = "";

        public MyForm()
        {
            InitializeComponent();
        }

        private void MyForm_Load(object sender, EventArgs e)
        {
            InitializeClock();
            _initialFormWidth = Width; // Set initial width after derived form's InitializeComponent
            MinimumSize = Size; // Prevent shrinking below initial size
        }

        /// <summary>
        /// Initializes a live clock.
        /// </summary>
        private void InitializeClock()
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            clockTimer.Start();
        }

        private void clockTimer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        /// <summary>
        /// Loads paginated data from the API, supporting filtering.
        /// </summary>
        protected async Task LoadPagedDataAsync<T>(
            MyDataGridView grid,
            Label recordsCountLabel,
            string baseEndpoint,
            string field = "",
            string value = "",
            int pageNumber = -1,
            int rowsPerPage = -1)
        {
            try
            {
                Cursor = Cursors.WaitCursor; // Add loading indicator

                // Use provided or default pagination values
                int currentPage = pageNumber > 0 ? pageNumber : CurrentPage;
                int rows = rowsPerPage > 0 ? rowsPerPage : RowsPerPage;

                // Use stored filter if none provided
                field = string.IsNullOrEmpty(field) ? CurrentFilterField : field;
                value = string.IsNullOrEmpty(value) ? CurrentFilterValue : value;

                // Build API URL
                var queryParams = new List<string> { $"pageNumber={currentPage}", $"rowsPerPage={rows}" };
                if (!string.IsNullOrEmpty(field) && !string.IsNullOrEmpty(value))
                {
                    queryParams.Add($"field={Uri.EscapeDataString(field)}");
                    queryParams.Add($"value={Uri.EscapeDataString(value)}");
                }
                string url = $"{baseEndpoint}/paged?{string.Join("&", queryParams)}";

                var response = await ApiClient.Client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<PagedResult<T>>();
                    if (result != null)
                    {
                        grid.DataSource = result.Items ?? [];
                        recordsCountLabel.Text = $"Records: {grid.RowCount} of {result.TotalRecords}";
                        TotalPages = result.TotalPages;
                        CurrentPage = currentPage;
                        RowsPerPage = rows;
                        CurrentFilterField = field; // Store filter
                        CurrentFilterValue = value;
                        AutoResizeFormToDataGridView(grid);
                        UpdatePaginationButtons();
                        return;
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    grid.DataSource = new List<T>();
                    recordsCountLabel.Text = $"Records: 0";
                    TotalPages = 0;
                    CurrentFilterField = field;
                    CurrentFilterValue = value;
                }
                else
                {
                    throw new HttpRequestException($"API call failed with status: {response.StatusCode}");
                }
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
        /// Updates pagination button states (override in derived forms with actual buttons).
        /// </summary>
        protected virtual void UpdatePaginationButtons()
        {
            // Derived forms should override to enable/disable btnNextPage, btnPrevPage, etc.
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

            filterBy.Items.AddRange([.. properties]); // equivalent to properties.ToArray()
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
           MyDataGridView grid, Label recordsCountLabel, string baseEndpoint, DateTimePicker? dtpFilter = null)
        {
            filterValue.TextChanged += (s, e) =>
            {
                CurrentFilterField = "";
                CurrentFilterValue = "";
                debounceTimer.Stop();  // Cancel prior timer
                debounceTimer.Start(); // Delay filter 300ms until typing stops
            };

            if (dtpFilter != null)
            {
                dtpFilter.ValueChanged += (s, e) =>
                {
                    debounceTimer.Stop();
                    debounceTimer.Start();
                };
            }

            debounceTimer.Tick += async (s, e) =>
            {
                debounceTimer.Stop(); // Stop timer immediately
                string field = filterBy.Text == "None" ? "" : MapFieldToColumn(filterBy.Text);
                bool isDateField = field != "" && typeof(T).GetProperty(field)?.PropertyType is Type propType &&
                    (propType == typeof(DateTime) || propType == typeof(DateTime?));
                string value = isDateField && dtpFilter != null && dtpFilter.Visible
                    ? dtpFilter.Value.ToString("yyyy-MM-ddTHH:mm:ss")
                    : filterValue.Text;

                if (isDateField && !string.IsNullOrWhiteSpace(value))
                {
                    if (!DateTime.TryParse(value, out _))
                    {
                        ShowMessage("Invalid date format. Use MM/dd/yyyy, yyyy-MM-dd, or similar.");
                        return;
                    }
                }
                CurrentPage = 1; // Reset to page 1 on filter change
                await LoadPagedDataAsync<T>(grid, recordsCountLabel, baseEndpoint, field, value);
            };
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

        private void MyForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Configures Escape key to close the form.
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void MyForm_Deactivate(object sender, EventArgs e)
        {
            // To supress toolTip bug that shows when pressing escape key to close the form
            btnInvisible.Focus();
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

            saveFileDialog.FileName = defaultFileName;

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                var sb = new StringBuilder();
                var headers = grid.Columns.Cast<DataGridViewColumn>()
                    .Select(c => $"\"{c.HeaderText.Replace("\"", "\"\"")}\""); // escapes double quotes in HeaderText to ensure valid CSV formatting.
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

                File.WriteAllText(saveFileDialog.FileName, sb.ToString());
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
            Dictionary<int, bool> sortDirections = [];

            // Attaches an event handler to grid's header clicks
            grid.ColumnHeaderMouseClick += (s, e) =>
            {
                if (grid.DataSource is not List<T> data || data.Count == 0 || e.ColumnIndex < 0)
                    return;

                var column = grid.Columns[e.ColumnIndex];
                if (column?.DataPropertyName == null)
                    return;

                // Use reflection to Get the PropertyInfo for the column's property (e.g., Client.FullName)
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