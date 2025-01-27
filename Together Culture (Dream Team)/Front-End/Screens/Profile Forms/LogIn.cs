﻿
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Together_Culture__Dream_Team_.Back_End.Src.Main;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace Together_Culture__Dream_Team_.Front_End.Src.Screens
{
    public partial class Log_in : Form
    {
        public Log_in()
        {
            InitializeComponent();
            // Attach KeyPress event
        }

        private void btnLogin_click(object sender, EventArgs e)
        {
            // Check if the email and password fields are not empty
            bool isEmailEntered = !string.IsNullOrWhiteSpace(txtEmail.Text);
            bool isPasswordEntered = !string.IsNullOrWhiteSpace(txtPassword.Text);

            if (!isEmailEntered || !isPasswordEntered)
            {
                string missingFields = "Please fill in the following fields:\n";
                if (!isEmailEntered) missingFields += "- Email\n";
                if (!isPasswordEntered) missingFields += "- Password\n";

                MessageBox.Show(missingFields, "Incomplete Form", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (DatabaseConnect database = new DatabaseConnect())
                {
                    database.Open();

                    // Modify the SQL query to retrieve: the user id, the first name, last name, and user type
                    using (SqlCommand command = new SqlCommand("SELECT user_id, first_name, last_name, user_type FROM [user] WHERE Email = @Email AND Password = @Password", database.Connection))
                    {
                        // Add parameters to avoid SQL injection
                        command.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text;
                        command.Parameters.Add("@Password", SqlDbType.VarChar).Value = txtPassword.Text;

                        // Execute the query and fetch the data
                        SqlDataReader reader = command.ExecuteReader();

                        // Check if any rows were returned
                        if (reader.HasRows)
                        {
                            // Read the data from the reader (the first record)
                            reader.Read(); // You must call Read() to move to the first row

                            int userId = Convert.ToInt32(reader["user_id"]);
                            string firstName = reader["first_name"].ToString();
                            string lastName = reader["last_name"].ToString();
                            string userType = reader["user_type"].ToString();
                            // Always close the reader after usage
                            reader.Close();

                            //Check if user has selected any interests
                            using (SqlCommand interestCheckCmd = new SqlCommand("SELECT COUNT(*) FROM interests WHERE user_id = @UserId", database.Connection))
                            {
                                interestCheckCmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                                int interestCount = (int)interestCheckCmd.ExecuteScalar();

                                if (interestCount == 0)
                                {
                                    // If no interests are found, redirect to Interests Form
                                    MessageBox.Show("You need to select your interests before proceeding.", "Interests Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Interests interestsForm = new Interests(userId, firstName, lastName, userType);
                                    interestsForm.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    // If any Interests are found, proceed to Profile Form
                                    MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Profile profile = new Profile(userId, firstName, lastName, userType);
                                    profile.Show();
                                    this.Hide();
                                }
                            }

                        }
                        else
                        {
                            // If no user is found, show a failure message
                            MessageBox.Show("Invalid email or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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



        private void btnSignUp_click(object sender, EventArgs e)
        {
            Sign_up sign_Up = new Sign_up();

            sign_Up.Show();

            this.Close();
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
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

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
