using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public Sign_up()
        {
            InitializeComponent();
            this.richTextBox4.TextChanged += new System.EventHandler(this.richTextBox4_TextChanged);
            this.richTextBox5.TextChanged += new System.EventHandler(this.richTextBox5_TextChanged);

        }

        private void Sign_up_Load(object sender, EventArgs e)
        {

        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string fNameText = richTextBox1.Text;
            if (IsValidFName(fNameText))
            {
                // Provide feedback for valid First name
                richTextBox1.BackColor = Color.LightGreen;  // Green background for valid email
                label8.Text = "Valid First Name";
            }
            else
            {
                // Provide feedback for invalid name
                richTextBox1.BackColor = Color.Red;  // Red background for invalid email
                label8.Text = "Please write your First Name";
            }

        }

        //validate if user has made an input for name
        private bool IsValidFName(string input)
        {
            string pattern = @"^[a-zA-Z]";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

            string emailText = richTextBox3.Text;

            // Validate the email
            if (IsValidEmail(emailText))
            {
                // Provide feedback for valid email
                richTextBox3.BackColor = Color.LightGreen;  // Green background for valid email
                lblFeedback.Text = "Valid email address.";
            }
            else
            {
                // Provide feedback for invalid email
                richTextBox3.BackColor = Color.Red;  // Red background for invalid email
                lblFeedback.Text = "Invalid email address.";
            }
        }

        // Email Validation Method
        private bool IsValidEmail(string input)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            string lNameText = richTextBox2.Text;
            if (IsValidLName(lNameText))
            {
                // Provide feedback for valid last name
                richTextBox2.BackColor = Color.LightGreen;  // Green background for valid last name
                label10.Text = "Valid Last Name";
            }
            else
            {
                // Provide feedback for invalid last name
                richTextBox2.BackColor = Color.Red;  // Red background for invalid Last name
                label10.Text = "Please write your Last Name";
            }

        }
        private bool IsValidLName(string input)
        {
            string pattern = @"^[a-zA-Z]";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }


        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

            string passwordText = richTextBox4.Text;

            // Validate the password
            if (IsValidPassword(passwordText))
            {
                // Password is valid
                richTextBox4.BackColor = Color.LightGreen;  // Green background for valid password
                lblFeedback2.Text = "Valid password.";  // Feedback message for valid password
            }
            else
            {
                // Password is invalid
                richTextBox4.BackColor = Color.Red;  // Red background for invalid password
                lblFeedback2.Text = "Password must be at least 8 characters and contain at least 3 symbols.";  // Feedback message for invalid password
            }
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

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {
            ValidatePasswords();
        }

        private void ValidatePasswords()
        {
            // Get the current text from both textboxes
            string password = richTextBox4.Text;
            string confirmPassword = richTextBox5.Text;

            // Check if the passwords match
            if (password == confirmPassword)
            {
                // Passwords match
                richTextBox5.BackColor = Color.LightGreen;  // Green background for matching passwords
                lblFeedback3.Text = "Passwords match.";    // Feedback message for matching passwords
            }
            else
            {
                // Passwords do not match
                richTextBox5.BackColor = Color.LightCoral; // Red background for non-matching passwords
                lblFeedback3.Text = "Passwords do not match."; // Feedback message for non-matching passwords
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

       

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            Log_in log_In = new Log_in();

            log_In.Show();

            this.Close();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {

            // Check if all fields have a green background (valid)
            bool isEmailValid = richTextBox3.BackColor == Color.LightGreen;
            bool isPasswordValid = richTextBox4.BackColor == Color.LightGreen;
            bool isPasswordMatchValid = richTextBox5.BackColor == Color.LightGreen;
            bool IsValidLName = richTextBox2.BackColor == Color.LightGreen;
            bool IsValidFName = richTextBox1.BackColor == Color.LightGreen;
            // If all fields are valid (green), proceed to the next page or action
            if (isEmailValid && isPasswordValid && isPasswordMatchValid && IsValidFName && IsValidLName)
            {
                // Proceed to the next page or action
                MessageBox.Show("Registered Successfully! Please Login now.");

                // code to proceed to the Login
                Log_in log_In = new Log_in();

                log_In.Show();

                this.Close();
                //need to add code for data base save later
            }
            else
            {
                // Notify the user which fields need attention
                string missingFields = "Please check the following fields:\n";

                if (!IsValidLName)
                {
                    missingFields += "- Last name\n";
                }
                if (!IsValidFName)
                {
                    missingFields += "- First name\n";
                }
                if (!isEmailValid)
                {
                    missingFields += "- Email\n";
                }
                if (!isPasswordValid)
                {
                    missingFields += "- Password\n";
                }
                if (!isPasswordMatchValid)
                {
                    missingFields += "- Confirm Password\n";
                }

                MessageBox.Show(missingFields, "Incomplete Form", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

