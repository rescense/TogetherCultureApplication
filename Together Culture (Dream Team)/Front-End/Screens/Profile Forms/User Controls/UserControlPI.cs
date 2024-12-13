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
using Together_Culture__Dream_Team_.Back_End.Src.Main;
using Together_Culture__Dream_Team_.Front_End.Src.Screens;

namespace Together_Culture__Dream_Team_.Front_End.Src.User_Controls
{
    public partial class UserControlPI : UserControl
    {
        bool isValidFirstName = false;
        bool isValidLastName = false;
        bool isValidUserName = false;
        bool isEmailValid = false;
        bool isPhoneNumberValid = false;

        private static UserControlPI _instance;
        public static UserControlPI Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserControlPI();
                return _instance;

            }
        }
        public UserControlPI()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged_1(object sender, EventArgs e)
        {
            if (IsValidEmail(richTextBox2.Text))
            {
                richTextBox2.BackColor = Color.LightGreen; // Valid input
                isEmailValid = true;
            }
            else
            {
                richTextBox2.BackColor = Color.LightCoral; // Invalid input feedback
            }
        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel8_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox4_TextChanged_1(object sender, EventArgs e)
        {
            string input = richTextBox4.Text;

            if (IsValidName(input))
            {
                richTextBox4.BackColor = Color.LightGreen; // Valid input
                isValidFirstName = true;
            }
            else
            {
                richTextBox4.BackColor = Color.LightCoral; // Invalid input feedback
            }
        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            string input = richTextBox1.Text;

            if (IsValidName(input))
            {
                richTextBox1.BackColor = Color.LightGreen; // Valid input
                isValidLastName = true;
            }
            else
            {
                richTextBox1.BackColor = Color.LightCoral; // Invalid input feedback
            }
        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {
            if (IsValidUsername(richTextBox5.Text))
            {
                richTextBox5.BackColor = Color.LightGreen; // Valid input
                isValidUserName = true;
            }
            else
            {
                richTextBox5.BackColor = Color.LightCoral; // Invalid input feedback
            }
        }


        // Validation method for Name
        private bool IsValidName(string input)
        {
            string pattern = @"^[a-zA-Z]+$"; // Only alphabetic characters, no spaces or special characters
            Regex regex = new Regex(pattern);

            return !string.IsNullOrEmpty(input) && regex.IsMatch(input);
        }

        // Validation method for Username
        private bool IsValidUsername(string input)
        {
            string pattern = @"^[a-zA-Z0-9_]+$"; // Allows letters, numbers, and underscores
            Regex regex = new Regex(pattern);

            return !string.IsNullOrEmpty(input) && regex.IsMatch(input);
        }

        // Email Validation Method
        private bool IsValidEmail(string input)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }

        // Phone Number Validation Method
        private bool IsValidPhoneNumber(string input)
        {
            // Pattern explanation:
            // ^(\+?\d{1,3})? - Optional country code with '+' sign (e.g., +1, +44)
            // [\s.-]? - Optional separator (space, dot, or dash)
            // \(?\d{3}\)? - Area code, optional parentheses (e.g., (123) or 123)
            // [\s.-]? - Optional separator
            // \d{3} - First 3 digits
            // [\s.-]? - Optional separator
            // \d{4}$ - Last 4 digits
            string pattern = @"^(\+?\d{1,3})?[\s.-]?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$";

            Regex regex = new Regex(pattern);

            return regex.IsMatch(input);
        }
        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {
            if (IsValidPhoneNumber(richTextBox3.Text))
            {
                richTextBox3.BackColor = Color.LightGreen; // Valid input
                isPhoneNumberValid = true;
            }
            else
            {
                richTextBox3.BackColor = Color.LightCoral; // Invalid input feedback
            }
        }

         int check(String email)
        {
            try
            {
                using (DatabaseConnect database = new DatabaseConnect())
                {
                    database.Open();
                    string query = "SELECT COUNT(*) FROM [user] WHERE LOWER(email) = LOWER(@Email)";
                    SqlCommand command = new SqlCommand(query, database.Connection);
                    command.Parameters.AddWithValue("@Email", email);

                    int count = (int)command.ExecuteScalar();
                    return count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1; // Indicate an error
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Validate the textboxes for null or empty values
            if (string.IsNullOrEmpty(richTextBox5.Text) ||
                string.IsNullOrEmpty(richTextBox4.Text) ||
                string.IsNullOrEmpty(richTextBox1.Text) ||
                string.IsNullOrEmpty(richTextBox2.Text) ||
                string.IsNullOrEmpty(richTextBox3.Text) )
            {
                MessageBox.Show("Please fill in all required fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isEmailValid &&  isValidFirstName && isValidLastName && isPhoneNumberValid && isValidUserName)
            {
                try
                {
                    if ( check(richTextBox2.Text) == 0) // Check if email is already registered
                    {
                        using (DatabaseConnect database = new DatabaseConnect())
                        {
                            database.Open();


                            SqlCommand command = new SqlCommand(
                                "INSERT INTO [user] (username, first_name, last_name, email, phone_number) " +
                                "VALUES (@Username, @FirstName, @LastName, @Email, @PhoneNumber)",
                                database.Connection
                            );

                            // Adding parameters with AddWithValue
                            command.Parameters.AddWithValue("@Username", richTextBox5.Text.Trim());
                          
                            command.Parameters.AddWithValue("@FirstName", richTextBox4.Text.Trim());
                            command.Parameters.AddWithValue("@LastName", richTextBox1.Text.Trim());
                            command.Parameters.AddWithValue("@Email", richTextBox2.Text.Trim());
                            command.Parameters.AddWithValue("@PhoneNumber", richTextBox3.Text.Trim());
                           // Set current date

                            // Execute the query
                            command.ExecuteNonQuery();

                        }

                        MessageBox.Show("Successfully!");
                       

               
                    }
                    else
                    {
                        MessageBox.Show($"The email '{richTextBox2.Text}' is already registered. Please use a different email.", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string missingFields = "Please check the following fields:\n";
                if (!isValidFirstName) missingFields += "- First Name\n";
                if (!isValidLastName) missingFields += "- Last Name\n";
                if (!isEmailValid) missingFields += "- Email\n";
               
                if (!isValidUserName) missingFields += "- Username\n";
                if (!isPhoneNumberValid) missingFields += "- Phone Number\n";

                MessageBox.Show(missingFields, "Incomplete Form", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        
    }
    }
}
