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


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!guna2CustomGradientPanel2.Controls.Contains(ForgotPasswordWindow.Instance))
            {
                guna2CustomGradientPanel2.Controls.Add(ForgotPasswordWindow.Instance);

                ForgotPasswordWindow.Instance.BringToFront();
            }
            else
                ForgotPasswordWindow.Instance.BringToFront();

        }



        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
