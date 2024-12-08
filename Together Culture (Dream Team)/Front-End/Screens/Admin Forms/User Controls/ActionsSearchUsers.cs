using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using Together_Culture__Dream_Team_.Front_End.Src.User_Controls;

namespace Together_Culture__Dream_Team_.Front_End.Screens.Admin_Forms.User_Controls
{
    public partial class ActionsSearchUsers : UserControl
    {
    private SearchUsers searchUsersControl;  // Instance variable for SearchUsers
    private List<string> attendedEvents = new List<string>();  // List to store attended events
    private Guna2DataGridView dataGridView1;

    // Constructor that takes a SearchUsers control as a parameter
    public ActionsSearchUsers()
    {
        InitializeComponent();
        this.searchUsersControl = searchUsersControl;
        confirmActionBtn.Click += confirmActionBtn_Click;  // Button click event handler
    }

    // Event handler for the button click
    private void confirmActionBtn_Click(object sender, EventArgs e)
    { 
        List<string> selectedUsers = searchUsersControl.GetSelectedUsers();
        if (seeEventsRadioBtn.Checked)
        {
            HandleSeeEventsAction(selectedUsers);
        }
        else if (addTagsRadioBtn.Checked)
        {
            HandleAddTagsAction(selectedUsers);
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

            // Clear the attended events list before adding new data
            attendedEvents.Clear();

            // Loop through the selected users and fetch events
            foreach (var user in selectedUsers)
            {
                // Example SQL query to fetch events for each selected user
                string query = @"
                SELECT e.event_name, e.date, e.time, e.location 
                FROM event_orders eo
                JOIN events e ON eo.event_id = e.event_id
                WHERE eo.user_id = (SELECT user_id FROM [user] WHERE username = @username)";  // Replace with actual user ID query

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
                // Populate the DataGridView
                DisplayEventsInDataGridView(attendedEvents);
            }
        }

        private void DisplayEventsInDataGridView(List<string> attendedEvents)
        {
            // Clear existing rows in the DataGridView
            dataGridView1.Rows.Clear();

            // Add columns if they are not already added
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("EventName", "Event Name");
                dataGridView1.Columns.Add("Date", "Date");
                dataGridView1.Columns.Add("Time", "Time");
                dataGridView1.Columns.Add("Location", "Location");
            }

            // Loop through the attended events and add them to the DataGridView
            foreach (var eventInfo in attendedEvents)
            {
                // You can split the eventInfo string if needed or use the result data directly
                // For simplicity, assuming each entry in attendedEvents contains a string with the event details
                string[] eventDetails = eventInfo.Split(" - "); // Adjust the split logic based on your data format

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
            }
        }

        // Action to remove selected users
        private void HandleRemoveUsersAction(List<string> selectedUsers)
        {
            if (selectedUsers.Count == 0)
            {
                MessageBox.Show("Please select at least one user.");
            }
        }

        // Execute the query and return the results
        private List<Dictionary<string, object>> ExecuteQuery(string query, SqlParameter parameter)
        {
            var results = new List<Dictionary<string, object>>();

            using (SqlConnection connection = new SqlConnection("YourConnectionStringHere"))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(parameter);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

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

            return results;
        }
    }
}
