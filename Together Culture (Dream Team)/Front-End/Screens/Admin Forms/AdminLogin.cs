using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Together_Culture__Dream_Team_.Back_End.Src.Main;

namespace Together_Culture__Dream_Team_.Front_End.Src.Screens
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void CheckBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // If the checkbox is checked, show the password
            if (CheckBoxShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0'; // Empty string means no masking
            }
            else
            {
                txtPassword.PasswordChar = '*'; // Use '*' to mask the password
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Check if the Name and password fields are not empty
            bool isNameEntered = !string.IsNullOrWhiteSpace(txtName.Text);
            bool isPasswordEntered = !string.IsNullOrWhiteSpace(txtPassword.Text);

            if (!isNameEntered || !isPasswordEntered)
            {
                string missingFields = "Please fill in the following fields:\n";
                if (!isNameEntered) missingFields += "- Email\n";
                if (!isPasswordEntered) missingFields += "- Password\n";

                MessageBox.Show(missingFields, "Incomplete Form", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (DatabaseConnect database = new DatabaseConnect())
                {
                    database.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM [Admin] WHERE first_name = @Name AND Password = @Password", database.Connection))
                    {
                        // Add parameters to avoid SQL injection
                        command.Parameters.Add("@Name", SqlDbType.VarChar).Value = txtName.Text;
                        command.Parameters.Add("@Password", SqlDbType.VarChar).Value = txtPassword.Text;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows) // Check if any rows exist
                            {
                                MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                AdminDashboard adminDashboardcs = new AdminDashboard();
                                adminDashboardcs.Show();

                                this.Close();

                            }
                            else
                            {
                                MessageBox.Show("Invalid name or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }

                    database.Close();
                }

            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error: {sqlEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
