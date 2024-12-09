using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Together_Culture__Dream_Team_.Back_End.Src.Main;
using Together_Culture__Dream_Team_.Front_End.Screens.Admin_Forms.User_Controls;

namespace Together_Culture__Dream_Team_.Front_End.Src.User_Controls
{
    public partial class SearchPendingApprovals : UserControl
    {
        public DataTable userDataTable;

        FilterSearchUsers FilterSearchUsers = new FilterSearchUsers();

        private bool isFilterSearchUsersVisible = false;
        public SearchPendingApprovals()
        {
            InitializeComponent();

            // Ensure dataGridView1 is initialized
            if (pendingApprovalsDataGridView == null)
            {
                pendingApprovalsDataGridView = new Guna2DataGridView();
                this.Controls.Add(pendingApprovalsDataGridView);
            }

            LoadDataIntoDataGridView();
            AddCheckBoxColumn();
            FilterSearchUsers.FilterApplied += FilterSearchUsers_FilterApplied;
        }

        private void FilterSearchUsers_FilterApplied(object sender, EventArgs e)
        {
            // Check if the filter is sorting by name and if it's ascending or descending
            bool isAscending = FilterSearchUsers.IsAscending;

            // Apply the sort to the DataGridView based on the selected radio button
            SortDataGridView(isAscending);
        }

        private void SortDataGridView(bool isAscending)
        {
            if (userDataTable != null)
            {
                string sortOrder = isAscending ? "ASC" : "DESC";
                userDataTable.DefaultView.Sort = $"last_name {sortOrder}";
                pendingApprovalsDataGridView.DataSource = userDataTable.DefaultView;
            }
            else
            {
                MessageBox.Show("No data available to sort.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UserControlSearchPendingApprovals_Load(object sender, EventArgs e)
        {

        }

        private void SearchPendingApprovals_MouseClic(object sender, MouseEventArgs e)
        {
            // Only clear the placeholder text if it's the default
            if (searchPendingApprovalsTxtBx.Text == "Search pending approvals...")
            {
                searchPendingApprovalsTxtBx.Text = "";
                searchPendingApprovalsTxtBx.ForeColor = System.Drawing.Color.Black; // Change text color to black when editing
            }
        }

        private void SearchPendingApprovalsTxtBx_Leave(object sender, EventArgs e)
        {
            // Restore the placeholder text if the user has left it empty
            if (string.IsNullOrEmpty(searchPendingApprovalsTxtBx.Text))
            {
                searchPendingApprovalsTxtBx.Text = "Search pending approvals...";
                searchPendingApprovalsTxtBx.ForeColor = System.Drawing.Color.Gray; // Change color back to gray
            }
        }

        private void UpdateSelectAllText()
        {
            // Check if any checkboxes are checked in the DataGridView
            bool allChecked = true;

            foreach (DataGridViewRow row in pendingApprovalsDataGridView.Rows)
            {
                if (row.Cells["Select"].Value == null || !(bool)row.Cells["Select"].Value)
                {
                    allChecked = false;
                    break;
                }
            }

            // Update "Select All" checkbox text and set the "Select All" checkbox state
            selectAllCheckBox.Text = allChecked ? "Deselect All" : "Select All";
            selectAllCheckBox.Checked = allChecked;

            // Update the checkbox state in the DataGridView based on the Select All checkbox state
            foreach (DataGridViewRow row in pendingApprovalsDataGridView.Rows)
            {
                DataGridViewCheckBoxCell checkBoxCell = row.Cells["Select"] as DataGridViewCheckBoxCell;
                if (checkBoxCell != null)
                {
                    checkBoxCell.Value = allChecked; // Check or Uncheck based on Select All state
                }
            }
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

        private void SelectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Ensure DataGridView contains rows
            if (pendingApprovalsDataGridView.Rows.Count > 0)
            {
                bool selectAll = selectAllCheckBox.Checked;


                // Iterate through rows and set checkbox state
                foreach (DataGridViewRow row in pendingApprovalsDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell checkBoxCell = row.Cells["Select"] as DataGridViewCheckBoxCell;
                    if (checkBoxCell != null)
                    {
                        checkBoxCell.Value = selectAll; // Check or Uncheck based on Select All state
                    }
                }
            }
        }

        private void AddCheckBoxColumn()
        {
            // Add a checkbox column if not already present
            if (!pendingApprovalsDataGridView.Columns.Contains("Select"))
            {
                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "Select",
                    Name = "Select",
                    Width = 50
                };
                pendingApprovalsDataGridView.Columns.Insert(0, checkBoxColumn);
            }
        }


        private void Guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the clicked column is the checkbox column
            if (e.ColumnIndex == pendingApprovalsDataGridView.Columns["Select"].Index)
            {
                // Check if all rows are selected or not
                bool allChecked = true;
                foreach (DataGridViewRow row in pendingApprovalsDataGridView.Rows)
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

        private void LoadDataIntoDataGridView()
        {
            // Ensure pendingApprovalsDataGridView is initialized
            if (pendingApprovalsDataGridView == null)
            {
                pendingApprovalsDataGridView = new Guna2DataGridView();
                this.Controls.Add(pendingApprovalsDataGridView);
            }

            try
            {
                using (DatabaseConnect database = new DatabaseConnect())
                {
                    database.Open();

                    // Query to fetch all user data
                    string query = "SELECT u.username, u.first_name, u.last_name " +
                                   "FROM [user] u " +
                                   "INNER JOIN [user_memberships] um ON u.user_id = um.user_id " +
                                   "INNER JOIN [admin_approvals] aa ON um.approval_id = aa.approval_id " +
                                   "WHERE aa.is_approved = 0;";


                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, database.Connection);

                    // Fill the DataTable with the retrieved data
                    userDataTable = new DataTable();
                    dataAdapter.Fill(userDataTable);

                    // Bind the DataTable to the DataGridView
                    pendingApprovalsDataGridView.DataSource = userDataTable;

                    // Set column headers
                    pendingApprovalsDataGridView.Columns["username"].HeaderText = "Username";
                    pendingApprovalsDataGridView.Columns["first_name"].HeaderText = "First Name";
                    pendingApprovalsDataGridView.Columns["last_name"].HeaderText = "Last Name";

                    // Set default header height
                    pendingApprovalsDataGridView.ColumnHeadersHeight = 40;
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

        private void FilterBtn_Click(object sender, EventArgs e)
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

        private void SearchPendingApprovalsTxtBx_TextChanged(object sender, EventArgs e)
        {
            if (userDataTable != null)
            {
                string searchValue = searchPendingApprovalsTxtBx.Text.Trim().Replace("'", "''");

                // Prevent the placeholder text from being used in the search
                if (string.IsNullOrEmpty(searchValue) || searchValue == "Search users...")
                {
                    // Reset the data grid to the original data when no search text is entered
                    pendingApprovalsDataGridView.DataSource = userDataTable;
                }
                else
                {
                    // Apply filter only when there's actual input in the search box
                    DataView dv = userDataTable.DefaultView;
                    dv.RowFilter = $@"
                username LIKE '%{searchValue}%' OR
                first_name LIKE '%{searchValue}%' OR
                last_name LIKE '%{searchValue}%'";
                    pendingApprovalsDataGridView.DataSource = dv;
                }
            }
        }

        private void ApproveBtn_Click(object sender, EventArgs e)
        {
            var selectedUsers = GetSelectedUsers();
            HandleApproveUserConfirm(selectedUsers);
        }

        private void HandleApproveUserConfirm(List<string> selectedUsers)
        {
            if (selectedUsers.Count == 0)
            {
                MessageBox.Show("Please select at least one user.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to approve the selected users?",
                                          "Confirm Approval",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Remove users from the database
                    ApproveUser(selectedUsers);

                    // Update the grid
                    RemoveUsersFromGrid(selectedUsers);

                    MessageBox.Show("Users approved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error approving users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("User approval cancelled.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Method to approve users
        private void ApproveUser(List<string> selectedUsers)
        {
            // Start a single transaction for approving users one by one
            using (var dbConnect = new DatabaseConnect())
            {
                dbConnect.Open();
                using (var transaction = dbConnect.Connection.BeginTransaction())
                {
                    try
                    {
                        foreach (var username in selectedUsers)
                        {
                            // Update the user's approval status to true for each user
                            string updateUserQuery = @"
                        WITH UserApprovals AS (
                            SELECT u.user_id, aa.approval_id
                            FROM [user] u
                            JOIN [user_memberships] um ON u.user_id = um.user_id
                            JOIN [admin_approvals] aa ON um.approval_id = aa.approval_id
                            WHERE u.username = @username  -- Use single username per iteration
                              AND aa.is_approved = 0  -- Only update unapproved users
                        )
                        UPDATE aa
                        SET aa.is_approved = 1
                        FROM [admin_approvals] aa
                        INNER JOIN UserApprovals ua ON aa.approval_id = ua.approval_id;";

                            using (var command = new SqlCommand(updateUserQuery, dbConnect.Connection, transaction))
                            {
                                // Add the username parameter for each iteration
                                command.Parameters.AddWithValue("@username", username);

                                // Execute the query for the current user
                                command.ExecuteNonQuery();
                            }
                        }

                        // Commit the transaction if all updates were successful
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Rollback the transaction in case of an error
                        transaction.Rollback();
                        throw new Exception($"Error approving users: {ex.Message}");
                    }
                }
            }
        }



        private void RemoveUsersFromGrid(List<string> selectedUsers)
        {
            try
            {
                // Ensure the userDataTable exists
                if (userDataTable != null)
                {
                    foreach (var username in selectedUsers)
                    {
                        // Find rows in the DataTable with the matching username
                        DataRow[] rowsToRemove = userDataTable.Select($"username = '{username}'"); // Replace "username" with the actual column name
                        foreach (DataRow row in rowsToRemove)
                        {
                            userDataTable.Rows.Remove(row); // Remove rows from the DataTable
                        }
                    }

                    // Ensure dataGridView1 is initialised
                    if (pendingApprovalsDataGridView != null)
                    {
                        // Rebind the updated DataTable to the DataGridView
                        pendingApprovalsDataGridView.DataSource = null; // Clear current data
                        pendingApprovalsDataGridView.DataSource = userDataTable; // Rebind updated DataTable
                    }
                }
                else
                {
                    MessageBox.Show("Data table is not loaded. Please reload the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the grid: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public List<string> GetSelectedUsers()
        {
            List<string> selectedUsers = new List<string>();

            foreach (DataGridViewRow row in pendingApprovalsDataGridView.Rows)
            {
                var checkBoxCell = row.Cells["Select"] as DataGridViewCheckBoxCell;
                if (checkBoxCell != null && checkBoxCell.Value != null && (bool)checkBoxCell.Value)
                {
                    // Adjust column index or name based on your DataGridView configuration
                    var userIdCell = row.Cells["username"] ?? row.Cells[1]; // Fallback to column index
                    if (userIdCell != null)
                    {
                        selectedUsers.Add(userIdCell.Value.ToString());
                    }
                }
            }
            return selectedUsers;
        }
    }
}
