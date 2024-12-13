using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using Together_Culture__Dream_Team_.Back_End.Src.Main;
using Together_Culture__Dream_Team_.Front_End.Screens.Profile_Forms;
using Together_Culture__Dream_Team_.Front_End.User_Controls;

namespace Together_Culture__Dream_Team_.Front_End.Src.User_Controls
{
    public partial class UserControlChPassword : UserControl
    {
        bool isPasswordValid = false;
        bool isPasswordMatchValid = false;

        private static UserControlChPassword _instance;
        public static UserControlChPassword Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserControlChPassword();
                return _instance;

            }
        }
        public UserControlChPassword()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox2_TextChanged_1(object sender, EventArgs e)
        {
            if (IsValidPassword(richTextBox2.Text))
            {
                richTextBox2.BackColor = Color.LightGreen; // Valid input
                isPasswordValid = true;
            }
            else
            {
                richTextBox2.BackColor = Color.LightCoral; // Invalid input feedback
            }
        }

        private void richTextBox3_TextChanged_1(object sender, EventArgs e)
        {
            string password = richTextBox2.Text;
            string retypePassword = richTextBox3.Text;

            if (ArePasswordsMatching(password, retypePassword))
            {
                richTextBox3.BackColor = Color.LightGreen; // Match: Set background to green
                isPasswordMatchValid = true;
            }
            else
            {
                richTextBox3.BackColor = Color.LightCoral; // Mismatch: Set background to red
            }
        }

        private bool IsValidPassword(string password)
        {
            // Check if the password has at least 8 characters
            if (password.Length < 8)
            {
                return false;
            }

            // Regex for at least one symbol (any non-alphanumeric character)
            Regex symbolRegex = new Regex(@"[\W_]"); // \W matches any non-word character (symbol) and _ is explicitly included

            // Regex for at least one uppercase letter
            Regex uppercaseRegex = new Regex(@"[A-Z]");

            // Check for at least one symbol and one uppercase letter
            bool hasSymbol = symbolRegex.IsMatch(password);
            bool hasUppercase = uppercaseRegex.IsMatch(password);

            return hasSymbol && hasUppercase;
        }

        // Retype Password Validation
        private bool ArePasswordsMatching(string password, string retypePassword)
        {
            return password == retypePassword;
        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void UpdatePasswordInDatabase(string username, string newPassword)
        {
            try
            {
                using (DatabaseConnect database = new DatabaseConnect())
                {
                    database.Open();

                  

                    // SQL query to update the password
                    string query = "UPDATE [user] SET password = @Password WHERE username = @Username";

                    using (SqlCommand command = new SqlCommand(query, database.Connection))
                    {
                        // Use parameterized queries to avoid SQL injection
                        command.Parameters.Add("@Password", SqlDbType.VarChar).Value = newPassword; // No hashing
                        command.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;

                        // Execute the update query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Password updated successfully
                            MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            // If no rows were affected, something went wrong
                            MessageBox.Show("Failed to update password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the password: " + ex.Message);
            }
        }



        private void guna2HtmlLabel2_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            string enteredUsername = richTextBox1.Text;

            // Exit if no username is entered
            if (string.IsNullOrEmpty(enteredUsername))
            {
                return;
            }

            try
            {
                using (DatabaseConnect database = new DatabaseConnect())
                {
                    database.Open();

                    // Query to check if the username exists in the database
                    string query = "SELECT user_id, password FROM [user] WHERE username = @Username"; // Assuming 'username' is the column name in your database

                    using (SqlCommand command = new SqlCommand(query, database.Connection))
                    {
                        // Use parameterized query to avoid SQL injection
                        command.Parameters.Add("@Username", SqlDbType.VarChar).Value = enteredUsername;

                        // Execute the query and fetch the data
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            // Username exists in the database
                            reader.Read(); // Read the first row (you can also fetch other details if needed)
                            int userId = Convert.ToInt32(reader["user_id"]);
                            string storedPassword = reader["password"].ToString(); // Retrieve the stored password

                            reader.Close(); // Always close the reader after use

                            // Now, the user exists, proceed to check the new password
                            // Make sure the new password (from richTextBox2 and richTextBox3) is valid
                            string newPassword = richTextBox2.Text;
                            string retypePassword = richTextBox3.Text;

                            if (newPassword == retypePassword && IsValidPassword(newPassword))
                            {
                                // Now we proceed to update the password in the database
                                UpdatePasswordInDatabase(enteredUsername, newPassword);
                            }
                            else
                            {
                                MessageBox.Show("Passwords do not match or are invalid. Please try again.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            // If no username is found in the database
                            MessageBox.Show("Username not found. Please check the username and try again.", "Username Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while checking the username: " + ex.Message);
            }


        }
            }
        }
            

    
