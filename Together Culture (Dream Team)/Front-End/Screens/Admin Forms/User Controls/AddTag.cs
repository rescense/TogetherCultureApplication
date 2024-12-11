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

        public AddTag(SearchUsers searchUsers)
        {
            InitializeComponent();
            _searchUsers = searchUsers;

            confirmAddingTagBtn.Click -= AddTagButton_Click;
            confirmAddingTagBtn.Click += AddTagButton_Click;
        }

        // Property to access the tag input from the TextBox
        public string TagInput => addTagTxtBox.Text.Trim();

        // Button click event handler for adding a tag
        public void AddTagButton_Click(object sender, EventArgs e)
        {
            string tag = TagInput;
            var selectedUsers = _searchUsers.GetSelectedUsers();

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

            HandleAddTagsAction(selectedUsers);
        }


        // A helper method to get the user ID (you need to implement this based on your logic)
        private int GetUserId(string username)
        {
            // Logic to fetch user ID from the database or based on the username.
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

        // Action to add tags to selected users
        public void HandleAddTagsAction(List<string> selectedUsers)
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

            // Fire the event to notify that the tag has been added successfully
            OnTagAdded?.Invoke(this, EventArgs.Empty);
            MessageBox.Show("Tags added successfully.");
        }

        // Helper method to add a tag to a user in the database
        private void AddTagToDatabase(int userId, string tagName)
        {
            string query = "INSERT INTO user_tags (user_id, tag_name) VALUES (@userId, @TagName)";

            using (var dbConnect = new DatabaseConnect())
            {
                dbConnect.Open();

                using (SqlCommand command = new SqlCommand(query, dbConnect.Connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@TagName", tagName);
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
