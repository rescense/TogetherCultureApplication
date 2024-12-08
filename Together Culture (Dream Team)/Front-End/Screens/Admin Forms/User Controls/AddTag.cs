using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Together_Culture__Dream_Team_.Back_End.Src.Main;
using Together_Culture__Dream_Team_.Front_End.Src.User_Controls;

namespace Together_Culture__Dream_Team_.Front_End.Screens.Admin_Forms.User_Controls
{
    public partial class AddTag : UserControl
    {
        // Event to notify when the tag is added
        public event EventHandler OnTagAdded;
        private SearchUsers _searchUsers;  // Instance variable for SearchUsers

        public AddTag()
        {
            InitializeComponent();
        }

        public AddTag(SearchUsers searchUsers)
        {
        }



        // Property to access the tag input from the TextBox
        public string TagInput => addTagTxtBox.Text.Trim();

        // Add the tag to the database
        public void AddTagToDatabase(int userId, string tag)
        {
            string query = @"
        INSERT INTO user_tags (user_id, tag)
        VALUES (@userId, @tag)";

            using (var dbConnect = new DatabaseConnect())
            {
                dbConnect.Open();

                using (SqlCommand command = new SqlCommand(query, dbConnect.Connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@tag", tag);

                    command.ExecuteNonQuery(); // Insert the tag into the database
                }

                dbConnect.Close();
            }
        }

        private int GetUserIdByUsername(string username)
        {
            // Define the query to fetch the user_id based on the username
            string query = "SELECT user_id FROM users WHERE username = @username";

            // Initialize the user_id variable
            int userId = -1;  // Default value in case the username is not found

            try
            {
                using (var dbConnect = new DatabaseConnect())  // Assuming DatabaseConnect handles your DB connection
                {
                    dbConnect.Open();  // Open the connection

                    // Prepare the command with the query and parameter
                    using (SqlCommand command = new SqlCommand(query, dbConnect.Connection))
                    {
                        // Add the username as a parameter to prevent SQL injection
                        command.Parameters.AddWithValue("@username", username);

                        // Execute the query and retrieve the user_id
                        object result = command.ExecuteScalar();

                        // If result is not null and not DBNull, convert it to an integer
                        if (result != DBNull.Value && result != null)
                        {
                            userId = Convert.ToInt32(result);
                        }
                    }

                    dbConnect.Close();  // Close the connection
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving user ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Return the retrieved userId (or -1 if not found)
            return userId;
        }


        // Button click event handler for adding a tag
        private void AddTagButton_Click(object sender, EventArgs e)
        {
            string tag = TagInput;

            if (string.IsNullOrEmpty(tag))
            {
                MessageBox.Show("Tag cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate tag for any invalid characters or formats
            if (tag.Contains(",") || tag.Contains(";") || tag.Contains("'"))
            {
                MessageBox.Show("Tag contains invalid characters. Please avoid using commas, semicolons, or quotes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Fetch the selected users from SearchUsers control
                var selectedUsers = _searchUsers.GetSelectedUsers();

                if (selectedUsers.Count == 0)
                {
                    MessageBox.Show("Please select at least one user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Add the tag for each selected user
                foreach (var username in selectedUsers) // Assuming selectedUsers contains usernames
                {
                    int userId = GetUserIdByUsername(username);  // Fetch the userId based on the username

                    if (userId == -1)
                    {
                        MessageBox.Show($"User with username {username} not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;  // Skip to the next user if userId is not found
                    }

                    // Directly use userId to add the tag
                    AddTagToDatabase(userId, tag);
                }

                // Clear the input field after successful insertion
                addTagTxtBox.Clear();

                // Trigger the event to notify that the tag was added
                OnTagAdded?.Invoke(this, EventArgs.Empty);

                MessageBox.Show("Tag added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding tag: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // A helper method to get the user ID (you need to implement this based on your logic)
        private int GetUserId(string username)
        {
            // Logic to fetch user ID from the database or based on the username.
            // For now, assuming a mock implementation:
            string query = "SELECT user_id FROM [user] WHERE username = @username";
            using (var dbConnect = new DatabaseConnect())
            {
                dbConnect.Open();
                using (var command = new SqlCommand(query, dbConnect.Connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    var result = command.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }
            }
        }
    }
}
