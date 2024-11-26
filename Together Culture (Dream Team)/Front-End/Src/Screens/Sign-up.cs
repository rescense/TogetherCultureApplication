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

namespace Together_Culture__Dream_Team_.Front_End.Src.Screens
{
    public partial class Sign_up : Form

    {
        // Connection String for the database
        private readonly string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Abbas Haider\\source\\repos\\FBGHaider\\Dream-Team\\Together Culture (Dream Team)\\Database1.mdf\";Integrated Security=True";
        
        public Sign_up()
        {
            InitializeComponent();

            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtRpassword.TextChanged += new System.EventHandler(this.txtRetypePassword_TextChanged);


        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            string fNameText = txtFirstname.Text;
            if (IsValidFName(fNameText))
            {
                // Provide feedback for valid First name
                txtFirstname.BackColor = Color.LightGreen;  // Green background for valid email
                label8.Text = "Valid First Name";
            }
            else
            {
                // Provide feedback for invalid name
                txtFirstname.BackColor = Color.Red;  // Red background for invalid email
                label8.Text = "Please write your First Name";
            }
        }

        private void TxtLastName_TextChanged(object sender, EventArgs e)
        {
            string lNameText = txtLastname.Text;
            if (IsValidLName(lNameText))
            {
                // Provide feedback for valid last name
                txtLastname.BackColor = Color.LightGreen;  // Green background for valid last name
                label10.Text = "Valid Last Name";
            }
            else
            {
                // Provide feedback for invalid last name
                txtLastname.BackColor = Color.Red;  // Red background for invalid Last name
                label10.Text = "Please write your Last Name";
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

            string emailText = txtEmail.Text;

            // Validate the email
            if (IsValidEmail(emailText))
            {
                // Provide feedback for valid email
                txtEmail.BackColor = Color.LightGreen;  // Green background for valid email
                lblFeedback.Text = "Valid email address.";
            }
            else
            {
                // Provide feedback for invalid email
                txtEmail.BackColor = Color.Red;  // Red background for invalid email
                lblFeedback.Text = "Invalid email address.";
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            string passwordText = txtPassword.Text;

            // Validate the password
            if (IsValidPassword(passwordText))
            {
                // Password is valid
                txtPassword.BackColor = Color.LightGreen;  // Green background for valid password
                lblFeedback2.Text = "Valid password.";  // Feedback message for valid password
            }

            else
            {
                // Password is invalid
                txtPassword.BackColor = Color.Red;  // Red background for invalid password
                lblFeedback2.Text = "Password must be at least 8 characters and contain at least 3 symbols.";  // Feedback message for invalid password
            }
        }

        private void txtRetypePassword_TextChanged(object sender, EventArgs e)
        {
            ValidatePasswords();
        }

        //validate if user has made an input for First Name
        private bool IsValidFName(string input)
        {
            string pattern = @"^[a-zA-Z]";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }

        //validate if user has made an input for Last Name
        private bool IsValidLName(string input)
        {
            string pattern = @"^[a-zA-Z]";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }
        // Email Validation Method
        private bool IsValidEmail(string input)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }

        // Password Validation Method (at least 8 characters and 3 symbols)
        private bool IsValidPassword(string password)
        {
            // Check if the password has at least 8 characters
            if (password.Length < 8)
            {
                return false;
            }

            // Regex to match symbols (non-alphanumeric characters)
            string pattern = @"[!@#$%^&*(),.?\{ }|<>]";
            Regex regex = new Regex(pattern);
            int symbolCount = regex.Matches(password).Count;

            // Check if the password contains at least 3 symbols
            return symbolCount >= 3;
        }

        // Password and Confirm Password Validation
        private void ValidatePasswords()
        {
            // Get the current text from both textboxes
            string password = txtPassword.Text;
            string confirmPassword = txtRpassword.Text;

            // Check if the passwords match
            if (password == confirmPassword)
            {
                // Passwords match
                txtRpassword.BackColor = Color.LightGreen;  // Green background for matching passwords
                lblFeedback3.Text = "Passwords match.";    // Feedback message for matching passwords
            }
            else
            {
                // Passwords do not match
                txtRpassword.BackColor = Color.LightCoral; // Red background for non-matching passwords
                lblFeedback3.Text = "Passwords do not match."; // Feedback message for non-matching passwords
            }
        }
        private void btnLogin_click(object sender, EventArgs e)
        {
            Log_in log_In = new Log_in();

            log_In.Show();

            this.Hide();
        }

        private void btnSignUp_click(object sender, EventArgs e)
        {
            bool isEmailValid = txtEmail.BackColor == Color.LightGreen;
            bool isPasswordValid = txtPassword.BackColor == Color.LightGreen;
            bool isPasswordMatchValid = txtRpassword.BackColor == Color.LightGreen;
            bool isValidLastName = txtLastname.BackColor == Color.LightGreen;
            bool isValidFirstName = txtFirstname.BackColor == Color.LightGreen;

            if (isEmailValid && isPasswordValid && isPasswordMatchValid && isValidFirstName && isValidLastName)
            {
                try
                {
                    if (check(txtEmail.Text) == 0)
                    {
                        using (SqlConnection connection = new SqlConnection(_connectionString))
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand("INSERT INTO info (f_name, l_name, email, password) VALUES (@f_name, @l_name, @Email, @Password)", connection);
                            command.Parameters.AddWithValue("@f_name", txtFirstname.Text);
                            command.Parameters.AddWithValue("@l_name", txtLastname.Text);
                            command.Parameters.AddWithValue("@Email", txtEmail.Text);
                            command.Parameters.AddWithValue("@Password", txtPassword.Text);

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
                if (!isValidLastName) missingFields += "- Last Name\n";
                if (!isValidFirstName) missingFields += "- First Name\n";
                if (!isEmailValid) missingFields += "- Email\n";
                if (!isPasswordValid) missingFields += "- Password\n";
                if (!isPasswordMatchValid) missingFields += "- Confirm Password\n";

                MessageBox.Show(missingFields, "Incomplete Form", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        int check(String email)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM info WHERE LOWER(email) = LOWER(@Email)";
                    SqlCommand command = new SqlCommand(query, connection);
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
            txtFirstname.Text = "";
            txtLastname.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtRpassword.Text = "";
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        


        
    }

}

