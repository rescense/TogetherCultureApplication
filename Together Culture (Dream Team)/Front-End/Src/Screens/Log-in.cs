
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Together_Culture__Dream_Team_.Back_End.Src.Main;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


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
            bool isPasswordEntered = !string.IsNullOrWhiteSpace(txtPassword2.Text);

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
                    using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [user] WHERE Email = @email AND Password = @password", database.Connection))
                    {
                        // Securely add parameters to avoid SQL injection
                        command.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text;
                        command.Parameters.Add("@Password", SqlDbType.VarChar).Value = txtPassword.Text; // Use hashed password in a real scenario.

                        int userCount = (int)command.ExecuteScalar();

                        if (userCount > 0)
                        {
                            MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Navigate to the next form or main application window
                            Profile profile = new Profile();
                            profile.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid email or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            MessageBox.Show($"Email: {txtEmail.Text}, Password: {txtPassword.Text}");
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
        private void Log_in_Load(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
