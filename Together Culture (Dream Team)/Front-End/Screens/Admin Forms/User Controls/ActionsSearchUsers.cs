﻿using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
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

        private AddTag AddTagControl = new AddTag();
        private bool isAddTagVisible = false;

        // Constructor that takes a SearchUsers control as a parameter
        public ActionsSearchUsers(SearchUsers searchUsers)
        {
            InitializeComponent();
            _searchUsers = searchUsers;

            AddTagControl.OnTagAdded += TagInputControl_OnTagAdded;  // Event for when a tag is added
            confirmActionBtn.Click += confirmActionBtn_Click;  // Button click event handler
        }

        // Expose the tag input from the TextBox in AddTag UserControl
        public string TagInput => AddTagControl.TagInput;

        // Event handler for when the tag is added
        private void TagInputControl_OnTagAdded(object sender, EventArgs e)
        {
            var selectedUsers = _searchUsers.GetSelectedUsers();
            HandleAddTagsAction(selectedUsers);
        }
        private void ShowAddTag(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            addTagPanel.Controls.Clear();
            addTagPanel.Controls.Add(userControl);
            userControl.BringToFront();
        }

        // Event handler for the button click
        private void confirmActionBtn_Click(object sender, EventArgs e)
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
                /* else
                {
                    // Hide the AddTagControl by clearing the panel
                    addTagPanel.Controls.Clear();
                    isAddTagVisible = false;
                } */
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

        // Action to add tags to selected users
        private void HandleAddTagsAction(List<string> selectedUsers)
        {
            if (selectedUsers.Count == 0)
            {
                MessageBox.Show("Please select at least one user.");
                return;
            }

            string tagInput = TagInput; // Get the tag input from the user control
            if (string.IsNullOrEmpty(tagInput))
            {
                MessageBox.Show("Please provide a tag.");
                return;
            }

            string[] tags = tagInput.Split(','); // Split the input if multiple tags are provided

            foreach (var user in selectedUsers)
            {
                int userId = GetUserIdByUsername(user); // Implement this method to get user ID by username

                foreach (var tag in tags)
                {
                    AddTagToDatabase(userId, tag.Trim()); // Add the tag for each user
                }
            }

            MessageBox.Show("Tags added successfully.");
        }

        // Action to remove selected users
        private void HandleRemoveUsersAction(List<string> selectedUsers)
        {
            if (selectedUsers.Count == 0)
            {
                MessageBox.Show("Please select at least one user.");
            }
            else
            {
                // Implement removal logic here
                MessageBox.Show("Users removed successfully.");
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

        // Helper method to add a tag to a user in the database
        private void AddTagToDatabase(int userId, string tag)
        {
            string query = "INSERT INTO user_tags (user_id, tag) VALUES (@userId, @tag)";

            using (var dbConnect = new DatabaseConnect())
            {
                dbConnect.Open();

                using (SqlCommand command = new SqlCommand(query, dbConnect.Connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@tag", tag);
                    command.ExecuteNonQuery();
                }

                dbConnect.Close();
            }
        }

        // Helper method to get the user ID by username
        private int GetUserIdByUsername(string username)
        {
            string query = "SELECT user_id FROM [user] WHERE username = @username";
            var results = ExecuteQuery(query, new SqlParameter("@username", username));

            if (results.Count > 0)
            {
                return Convert.ToInt32(results[0]["user_id"]);
            }
            return -1; // Return an invalid ID if not found
        }
    }
}
