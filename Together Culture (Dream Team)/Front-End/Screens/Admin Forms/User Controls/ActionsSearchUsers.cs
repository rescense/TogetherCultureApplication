using Guna.UI2.WinForms;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Together_Culture__Dream_Team_.Back_End.Src.Main;
using Together_Culture__Dream_Team_.Front_End.Src.User_Controls;

namespace Together_Culture__Dream_Team_.Front_End.Screens.Admin_Forms.User_Controls
{
    public partial class ActionsSearchUsers : UserControl
    {
        private SearchUsers _searchUsers;  // Instance variable for SearchUsers
        private List<string> attendedEvents = new List<string>();  // List to store attended events
        private Guna2DataGridView dataGridView1;

        private AddTag AddTagControl;
        private bool isAddTagVisible = false;

        // Constructor that takes a SearchUsers control as a parameter
        public ActionsSearchUsers(SearchUsers searchUsers)
        {
            InitializeComponent();
            _searchUsers = searchUsers;

            AddTagControl = new AddTag(_searchUsers);

            // Prevent the button event from happening twice
            confirmActionBtn.Click -= ConfirmActionBtn_Click;  // Detach
            confirmActionBtn.Click += ConfirmActionBtn_Click;  // Button click event handler
        }


        // Expose the tag input from the TextBox in AddTag UserControl
        public string TagInput => AddTagControl.TagInput;

        // Event handler for when the tag is added
        private void TagInputControl_OnTagAdded(object sender, EventArgs e)
        {
            var selectedUsers = _searchUsers.GetSelectedUsers();
            AddTagControl.HandleAddTagsAction(selectedUsers);
        }

        private void ShowAddTag(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            addTagPanel.Controls.Clear();
            addTagPanel.Controls.Add(userControl);
            userControl.BringToFront();
        }

        // Event handler for the button click
        private void ConfirmActionBtn_Click(object sender, EventArgs e)
        {
            var selectedUsers = _searchUsers.GetSelectedUsers();

            if (seeEventsRadioBtn.Checked)
            {
                HandleSeeEventsAction(selectedUsers);
            }
            else if (addTagsRadioBtn.Checked)
            {
                if (!isAddTagVisible)
                {
                    addTagPanel.Visible = true;
                    ShowAddTag(AddTagControl);
                    isAddTagVisible = true;
                    BringToFront();
                }
            }
            else if (removeUsersRadioBtn.Checked)
            {
                HandleRemoveUsersAction(selectedUsers);
            }
            else
            {
                MessageBox.Show("Please select an action first.");
            }
        }


        // Action to view events for selected users
        private void HandleSeeEventsAction(List<string> selectedUsers)
        {
            if (selectedUsers.Count == 0)
            {
                MessageBox.Show("Please select at least one user.");
                return;
            }

            attendedEvents.Clear(); // Clear the attended events list before adding new data

            foreach (var user in selectedUsers)
            {
                string query = @"
                SELECT e.event_name, e.date, e.time, e.location 
                FROM event_orders eo
                JOIN event e ON eo.event_id = e.event_id
                WHERE eo.user_id = (SELECT user_id FROM [user] WHERE username = @username)";

                // Execute the query and get the results
                var results = ExecuteQuery(query, new SqlParameter("@username", user));

                // Add the fetched events to the attendedEvents list
                foreach (var result in results)
                {
                    attendedEvents.Add($"{result["event_name"]} - {result["date"]} at {result["time"]}, Location: {result["location"]}");
                }
            }

            // Display the results in the DataGridView
            if (attendedEvents.Count == 0)
            {
                MessageBox.Show("No events found for the selected users.");
            }
            else
            {
                DisplayEventsInDataGridView(attendedEvents);
            }
        }

        private void DisplayEventsInDataGridView(List<string> attendedEvents)
        {
            if (dataGridView1 == null)
            {
                dataGridView1 = new Guna2DataGridView();
                this.Controls.Add(dataGridView1);
                dataGridView1.Dock = DockStyle.Fill;  // Set docking style to fill the parent container
            }

            dataGridView1.Rows.Clear(); // Clear any existing rows

            // Populate the DataGridView with attended events
            foreach (var eventInfo in attendedEvents)
            {
                string[] eventDetails = eventInfo.Split(" - "); // Adjust the split logic as per your data format
                if (eventDetails.Length >= 4)
                {
                    dataGridView1.Rows.Add(eventDetails[0], eventDetails[1], eventDetails[2], eventDetails[3]);
                }
            }
        }

        private void HandleRemoveUsersAction(List<string> selectedUsers)
        {
            if (selectedUsers.Count == 0)
            {
                MessageBox.Show("Please select at least one user.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to remove the selected users?",
                                          "Confirm Removal",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Remove users from the database
                    RemoveUser(selectedUsers);

                    // Update the grid
                    RemoveUsersFromGrid(selectedUsers);

                    MessageBox.Show("Users removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error removing users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("User removal cancelled.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        // Method to remove users
        private void RemoveUser(List<string> selectedUsers)
        {
            // Start a single transaction for removing all users
            using (var dbConnect = new DatabaseConnect())
            {
                dbConnect.Open();
                using (var transaction = dbConnect.Connection.BeginTransaction())
                {
                    try
                    {
                        foreach (var username in selectedUsers)
                        {
                            // Delete the user from the user table
                            string deleteUserQuery = @"
                        DELETE FROM [user]
                        WHERE username = @username";

                            using (var command = new SqlCommand(deleteUserQuery, dbConnect.Connection, transaction))
                            {
                                command.Parameters.AddWithValue("@username", username);
                                command.ExecuteNonQuery();
                            }
                        }

                        // Commit the transaction if all deletions were successful
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Rollback the transaction in case of an error
                        transaction.Rollback();
                        throw new Exception($"Error removing users: {ex.Message}");
                    }
                }
            }
        }


        private void RemoveUsersFromGrid(List<string> selectedUsers)
        {
            try
            {
                // Ensure the userDataTable exists
                if (_searchUsers?.userDataTable != null)
                {
                    foreach (var username in selectedUsers)
                    {
                        // Find rows in the DataTable with the matching username
                        DataRow[] rowsToRemove = _searchUsers.userDataTable.Select($"username = '{username}'"); // Replace "username" with the actual column name
                        foreach (DataRow row in rowsToRemove)
                        {
                            _searchUsers.userDataTable.Rows.Remove(row); // Remove rows from the DataTable
                        }
                    }

                    // Ensure dataGridView1 is initialised
                    if (dataGridView1 != null)
                    {
                        // Rebind the updated DataTable to the DataGridView
                        dataGridView1.DataSource = null; // Clear current data
                        dataGridView1.DataSource = _searchUsers.userDataTable; // Rebind updated DataTable
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

        // Helper method to execute a SQL query and return the results
        private List<Dictionary<string, object>> ExecuteQuery(string query, SqlParameter parameter)
        {
            var results = new List<Dictionary<string, object>>();

            using (var dbConnect = new DatabaseConnect())
            {
                dbConnect.Open();

                using (SqlCommand command = new SqlCommand(query, dbConnect.Connection))
                {
                    command.Parameters.Add(parameter);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                result[reader.GetName(i)] = reader[i];
                            }
                            results.Add(result);
                        }
                    }
                }

                dbConnect.Close();
            }

            return results;
        }
    }
}
