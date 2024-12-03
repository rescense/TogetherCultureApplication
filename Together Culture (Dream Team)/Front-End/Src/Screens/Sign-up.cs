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
        bool isEmailValid = false;
        bool isPasswordValid = false;
        bool isPasswordMatchValid = false;
        bool isValidLastName = false;
        bool isValidFirstName = false;

        public Sign_up()
        {
            InitializeComponent();
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
            return symbolCount >= 1;
        }

        // Password and Confirm Password Validation
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
            bool isValidLastName = txtLastName.BackColor == Color.LightGreen;
            bool isValidFirstName = txtFirstName.BackColor == Color.LightGreen;

            if (isEmailValid && isPasswordValid && isPasswordMatchValid && isValidFirstName && isValidLastName)
            {
                try
                {
                    if (check(txtEmail.Text) == 0)
                    {
                        using (DatabaseConnect database = new DatabaseConnect())
                        {
                            database.Open();
                            SqlCommand command = new SqlCommand("INSERT INTO info (f_name, l_name, email, password) VALUES (@f_name, @l_name, @Email, @Password)", database.Connection);
                            command.Parameters.AddWithValue("@f_name", txtFirstName.Text);
                            command.Parameters.AddWithValue("@l_name", txtLastName.Text);
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
                using (DatabaseConnect database = new DatabaseConnect())
                {
                    database.Open();
                    string query = "SELECT COUNT(*) FROM info WHERE LOWER(email) = LOWER(@Email)";
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

