using System.Reflection;
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

        public MyForm()
        {
            InitializeComponent();

            SetupKeyHandling();
            InitializeClock();
        }

        /// <summary>
        /// Populates a ComboBox with filterable fields from a type, formatted as UI-friendly names.
        /// </summary>
        protected void PopulateFilterDropdown<T>(ComboBox filterBy)
        {
            filterBy.Items.Clear();
            filterBy.Items.Add("None");

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
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
        protected void ConfigureFilterDebounce<T>(TextBox filterValue, ComboBox filterBy, Label recordsCount,
            DataGridView grid, Func<string, string, Task<List<T>>> loadDataAsync)
        {
            filterValue.TextChanged += (s, e) =>
            {
                pendingFilterValue = filterValue.Text;
                debounceTimer.Stop(); // Cancel prior timer
                debounceTimer.Start(); // Delay filter 300ms until typing stops
            };
            debounceTimer.Tick += async (s, e) =>
            {
                debounceTimer.Stop();
                await ApplyFilterAsync(filterValue.Text, filterBy, recordsCount, grid, loadDataAsync);
            };
        }

        /// <summary>
        /// Applies an async filter to the grid, updating the records count and loading data from the API.
        /// </summary>
        protected async Task ApplyFilterAsync<T>(string filterValue, ComboBox filterBy, Label recordsCount,
            DataGridView grid, Func<string, string, Task<List<T>>> loadDataAsync)
        {
            try
            {
                string uiField = filterBy.Text;
                string field = uiField == "None" ? null : MapFieldToColumn(uiField);

                List<T> data;
                if (field == null || string.IsNullOrEmpty(filterValue))
                {
                    data = await loadDataAsync(null, null); // Load all data
                }
                else
                {
                    data = await loadDataAsync(field, filterValue); // Load filtered data
                }

                InvokeIfNeeded(() =>
                {
                    grid.DataSource = data;
                    recordsCount.Text = $"Records: {grid.RowCount}";
                });
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
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

        protected void InvokeIfNeeded(Action action)
        {
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        protected bool ValidateSelection(DataGridView dgv, out object selectedItem)
        {
            selectedItem = dgv.CurrentRow?.DataBoundItem;
            if (selectedItem == null)
            {
                ShowMessage("Please select an item.");
                return false;
            }
            return true;
        }
    }
}