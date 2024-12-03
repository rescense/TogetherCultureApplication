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

namespace Together_Culture__Dream_Team_.Front_End.Src.Screens
{
    public partial class Sign_up : Form

    {
        bool isValidFirstName = false;
        bool isValidLastName = false;
        bool isValidUserName = false;
        bool isEmailValid = false;
        bool isPhoneNumberValid = false;
        bool isPasswordValid = false;
        bool isPasswordMatchValid = false;

        public Sign_up()
        {
            InitializeComponent();
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            string input = txtFirstName.Text;

            if (IsValidName(input))
            {
                txtFirstName.BackColor = Color.White; // Valid input
                isValidFirstName = true;
            }
            else
            {
                txtFirstName.BackColor = Color.LightCoral; // Invalid input feedback
            }
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            string input = txtLastName.Text;

            if (IsValidName(input))
            {
                txtLastName.BackColor = Color.White; // Valid input
                isValidLastName = true;
            }
            else
            {
                txtLastName.BackColor = Color.LightCoral; // Invalid input feedback
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if (IsValidUsername(txtUserName.Text))
            {
                txtUserName.BackColor = Color.White; // Valid input
                isValidUserName = true;
            }
            else
            {
                txtUserName.BackColor = Color.LightCoral; // Invalid input feedback
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (IsValidEmail(txtEmail.Text))
            {
                txtEmail.BackColor = Color.White; // Valid input
                isEmailValid = true;
            }
            else
            {
                txtEmail.BackColor = Color.LightCoral; // Invalid input feedback
            }
        }

        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            if (IsValidPhoneNumber(txtPhoneNumber.Text))
            {
                txtPhoneNumber.BackColor = Color.White; // Valid input
                isPhoneNumberValid = true;
            }
            else
            {
                txtPhoneNumber.BackColor = Color.LightCoral; // Invalid input feedback
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (IsValidPassword(txtPassword.Text))
            {
                txtPassword.BackColor = Color.White; // Valid input
                isPasswordValid = true;
            }
            else
            {
                txtPassword.BackColor = Color.LightCoral; // Invalid input feedback
            }
        }

        private void txtRpassword_TextChanged(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            string retypePassword = txtRpassword.Text;

            if (ArePasswordsMatching(password, retypePassword))
            {
                txtRpassword.BackColor = Color.LightGreen; // Match: Set background to green
                isPasswordMatchValid = true;
            }
            else
            {
                txtRpassword.BackColor = Color.LightCoral; // Mismatch: Set background to red
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


        // Login Button
        private void btnLogin_click(object sender, EventArgs e)
        {
            Log_in log_In = new Log_in();

            log_In.Show();

            this.Hide();
        }


        // Sign up button
        private void btnSignUp_click(object sender, EventArgs e)
        {
            // Validate the textboxes for null or empty values
            if (string.IsNullOrEmpty(txtUserName.Text) ||
                string.IsNullOrEmpty(txtFirstName.Text) ||
                string.IsNullOrEmpty(txtLastName.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtPhoneNumber.Text) ||
                string.IsNullOrEmpty(txtPassword.Text) ||
                string.IsNullOrEmpty(txtRpassword.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isEmailValid && isPasswordValid && isPasswordMatchValid && isValidFirstName && isValidLastName && isPhoneNumberValid && isValidUserName)
            {
                try
                {
                    if (check(txtEmail.Text) == 0) // Check if email is already registered
                    {
                        using (DatabaseConnect database = new DatabaseConnect())
                        {
                            database.Open();


                            SqlCommand command = new SqlCommand(
                                "INSERT INTO [user] (username, password, first_name, last_name, email, phone_number, date_of_birth, date_joined) " +
                                "VALUES (@Username, @Password, @FirstName, @LastName, @Email, @PhoneNumber, @DateOfBirth, @DateJoined)",
                                database.Connection
                            );

                            // Adding parameters with AddWithValue
                            command.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                            command.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                            command.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                            command.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                            command.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                            command.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text.Trim());
                            command.Parameters.AddWithValue("@DateOfBirth", txtDateOfBirth.Value);
                            command.Parameters.AddWithValue("@DateJoined", DateTime.Now.Date); // Set current date

                            // Execute the query
                            command.ExecuteNonQuery();

                        }

                        MessageBox.Show("Registered Successfully!");
                        ResetFormFields();

                        Log_in logInForm = new Log_in();
                        logInForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show($"The email '{txtEmail.Text}' is already registered. Please use a different email.", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (!isPasswordValid) missingFields += "- Password\n";
                if (!isPasswordMatchValid) missingFields += "- Confirm Password\n";
                if (!isValidUserName) missingFields += "- Username\n";
                if (!isPhoneNumberValid) missingFields += "- Phone Number\n";

                MessageBox.Show(missingFields, "Incomplete Form", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void ResetFormFields()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtRpassword.Text = "";
        }

        private void Sign_up_Load(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }


    }

}

