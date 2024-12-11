using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Together_Culture__Dream_Team_.Back_End.Src.Main;
using Together_Culture__Dream_Team_.Front_End.Screens.Admin_Forms.User_Controls;

namespace Together_Culture__Dream_Team_.Front_End.Src.User_Controls
{
    public partial class SearchEventsAdmin : UserControl
    {
        public DataTable eventDataTable;

        FilterSearchUsers FilterSearchUsers = new FilterSearchUsers();
        private bool isFilterSearchUsersVisible = false;

        public SearchEventsAdmin()
        {
            InitializeComponent();

            // Ensure dataGridView1 is initialized
            if (eventDataGridView == null)
            {
                eventDataGridView = new Guna2DataGridView();
                this.Controls.Add(eventDataGridView);
            }

            LoadDataIntoDataGridView();
            AddCheckBoxColumn();
            FilterSearchUsers.FilterApplied += FilterSearchUsers_FilterApplied;
        }

        private void AddCheckBoxColumn()
        {
            // Add a checkbox column if not already present
            if (!eventDataGridView.Columns.Contains("Select"))
            {
                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "Select",
                    Name = "Select",
                    Width = 50,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                };
                eventDataGridView.Columns.Insert(0, checkBoxColumn);
            }
        }


        private void Guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the clicked column is the checkbox column
            if (e.ColumnIndex == eventDataGridView.Columns["Select"].Index)
            {
                // Check if all rows are selected or not
                bool allChecked = true;
                foreach (DataGridViewRow row in eventDataGridView.Rows)
                {
                    if (row.Cells["Select"].Value == null || !(bool)row.Cells["Select"].Value)
                    {
                        allChecked = false;
                        break;
                    }
                }

                // Update the "Select All" checkbox state
                selectAllCheckBox.CheckedChanged -= SelectAllCheckBox_CheckedChanged; // Temporarily unsubscribe
                selectAllCheckBox.Checked = allChecked;
                selectAllCheckBox.CheckedChanged += SelectAllCheckBox_CheckedChanged; // Re-subscribe
            }
        }

        public void LoadDataIntoDataGridView()
        {
            // Ensure pendingApprovalsDataGridView is initialized
            if (eventDataGridView == null)
            {
                eventDataGridView = new Guna2DataGridView();
                this.Controls.Add(eventDataGridView);
            }

            try
            {
                using (DatabaseConnect database = new DatabaseConnect())
                {
                    database.Open();

                    // Query to fetch all user data
                    string query = "SELECT event_name, date, time, location " +
                                   "FROM [event];";


                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, database.Connection);

                    // Fill the DataTable with the retrieved data
                    eventDataTable = new DataTable();
                    dataAdapter.Fill(eventDataTable);

                    // Bind the DataTable to the DataGridView
                    eventDataGridView.DataSource = eventDataTable;

                    // Set column headers
                    eventDataGridView.Columns["event_name"].HeaderText = "Event Name";
                    eventDataGridView.Columns["date"].HeaderText = "Event Date";
                    eventDataGridView.Columns["time"].HeaderText = "Event Time";
                    eventDataGridView.Columns["location"].HeaderText = "Event Location";

                    // Set default header height
                    eventDataGridView.ColumnHeadersHeight = 40;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FilterPanel_Paint(object sender, PaintEventArgs e)
        {
            if (!isFilterSearchUsersVisible)
            {
                filterPanel.Visible = false;
            }
        }

        private void ShowFilterSearchUsersVisible(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            filterPanel.Controls.Clear();
            filterPanel.Controls.Add(userControl);
            userControl.BringToFront();
        }

        public void FilterBtn_Click(object sender, EventArgs e)
        {
            if (!isFilterSearchUsersVisible)
            {
                //show the filter menu bar
                filterPanel.Visible = true;
                ShowFilterSearchUsersVisible(FilterSearchUsers);
                isFilterSearchUsersVisible = true;
                BringToFront();
            }
            else
            {
                //hide the filter panel
                filterPanel.Controls.Clear();
                filterPanel.Visible = false;
                isFilterSearchUsersVisible = false;
            }
        }

        public void SearchEventsTxtBx_TextChanged(object sender, EventArgs e)
        {
            if (eventDataTable != null)
            {
                string searchValue = searchEventsTxtBx.Text.Trim().Replace("'", "''");

                // Prevent the placeholder text from being used in the search
                if (string.IsNullOrEmpty(searchValue) || searchValue == "Search events...")
                {
                    // Reset the data grid to the original data when no search text is entered
                    eventDataGridView.DataSource = eventDataTable;
                }
                else
                {
                    // Apply filter only when there's actual input in the search box
                    DataView dv = eventDataTable.DefaultView;
                    dv.RowFilter = $@"
                event_name LIKE '%{searchValue}%' OR
                location LIKE '%{searchValue}%'";
                    eventDataGridView.DataSource = dv;
                }
            }
        }

        public void FilterSearchUsers_FilterApplied(object sender, EventArgs e)
        {
            // Check if the filter is sorting by name and if it's ascending or descending
            bool isAscending = FilterSearchUsers.IsAscending;

            // Apply the sort to the DataGridView based on the selected radio button
            SortDataGridView(isAscending);
        }

        private void SortDataGridView(bool isAscending)
        {
            if (eventDataTable != null)
            {
                string sortOrder = isAscending ? "ASC" : "DESC";
                eventDataTable.DefaultView.Sort = $"event_name {sortOrder}";
                eventDataGridView.DataSource = eventDataTable.DefaultView;
            }
            else
            {
                MessageBox.Show("No data available to sort.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void SearchEventsTxtBx_MouseClic(object sender, MouseEventArgs e)
        {
            // Only clear the placeholder text if it's the default
            if (searchEventsTxtBx.Text == "Search events...")
            {
                searchEventsTxtBx.Text = "";
                searchEventsTxtBx.ForeColor = System.Drawing.Color.Black; // Change text color to black when editing
            }
        }

        public void SearchEventsTxtBxx_Leave(object sender, EventArgs e)
        {
            // Restore the placeholder text if the user has left it empty
            if (string.IsNullOrEmpty(searchEventsTxtBx.Text))
            {
                searchEventsTxtBx.Text = "Search events...";
                searchEventsTxtBx.ForeColor = System.Drawing.Color.Gray; // Change color back to gray
            }
        }

        public void SelectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (selectAllCheckBox.Focused) // Ensure triggered by user action
            {
                // Ensure DataGridView contains rows
                if (eventDataGridView.Rows.Count > 0)
                {
                    bool selectAll = selectAllCheckBox.Checked;


                    // Iterate through rows and set checkbox state
                    foreach (DataGridViewRow row in eventDataGridView.Rows)
                    {
                        DataGridViewCheckBoxCell checkBoxCell = row.Cells["Select"] as DataGridViewCheckBoxCell;
                        if (checkBoxCell != null)
                        {
                            checkBoxCell.Value = selectAll; // Check or Uncheck based on Select All state
                        }
                    }
                }
            }
        }

        private void OtherCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Determine if all or none are checked
            bool allChecked = true;
            bool noneChecked = true;

            foreach (CheckBox checkBox in GetAllCheckBoxes(eventDataGridView))
            {
                if (checkBox != selectAllCheckBox)
                {
                    if (checkBox.Checked)
                        noneChecked = false;
                    else
                        allChecked = false;
                }
            }

            // Update "Select All" checkbox state
            selectAllCheckBox.CheckedChanged -= SelectAllCheckBox_CheckedChanged; // Detach event
            selectAllCheckBox.Checked = allChecked; // Update state
            selectAllCheckBox.CheckedChanged += SelectAllCheckBox_CheckedChanged; // Reattach event

            UpdateSelectAllText();
        }

        private void UpdateSelectAllText()
        {
            // Check if none are checked
            bool noneChecked = true;

            foreach (CheckBox checkBox in GetAllCheckBoxes(panel1))
            {
                if (checkBox != selectAllCheckBox && checkBox.Checked)
                {
                    noneChecked = false;
                    break;
                }
            }

            selectAllCheckBox.Text = noneChecked ? "Select All" : "Deselect All";
        }

        // Helper function to get all checkboxes recursively
        private IEnumerable<CheckBox> GetAllCheckBoxes(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is CheckBox checkBox)
                    yield return checkBox;
                else if (control.HasChildren)
                {
                    foreach (var childCheckBox in GetAllCheckBoxes(control))
                        yield return childCheckBox;
                }
            }
        }
    }
}
