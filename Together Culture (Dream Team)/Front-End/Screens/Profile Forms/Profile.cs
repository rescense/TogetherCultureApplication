using System.Data.SqlClient;
using System.Data;
using System.Text;
using Together_Culture__Dream_Team_.Back_End.Src.Main;
using Together_Culture__Dream_Team_.Front_End.Screens.Profile_Forms;
using System.Diagnostics;

namespace Together_Culture__Dream_Team_.Front_End.Src.Screens
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();

            lblStatus.Visible = false;
        }

        private string firstName;
        private string lastName;
        private string userType;
        private int userId;

        // Constructor to accept username
        public Profile(int userId, string FirstName, String LastName, String UserType)
        {
            InitializeComponent();
            this.firstName = FirstName;
            this.lastName = LastName;
            this.userType = UserType;
            this.userId = userId;

        }

        private void Profile_Load(object sender, EventArgs e)
        {
            LoadProfilePicture(userId);

            MakePictureBoxRound(profilePictureBox);

            lblUserName.Text = $"{firstName}";
            lblUserType.Text = $"{userType}";

            // Create a copy of the Application.OpenForms collection
            var openFormsList = new List<Form>(Application.OpenForms.Cast<Form>());

            // Close LandingPage form from the copied list, but not Profile
            foreach (Form form in openFormsList)
            {
                if (form.Name == "landingPage") // Check for the LandingPage form by its Name
                {
                    form.Close();
                }
            }
            //displays the user's interests
            LoadUserInterests();

            if (lblUserType.Text == "non_member")
            {
                lblStatus.Visible = true;
                btnBuyMembership.Visible = true;
            }
            else
            {
                btnBuyMembership.Visible = false;
                lblStatus.Visible = false;
                picLock.Visible = false;
            }
        }
        private void LoadUserInterests()
        {
            // Create a database connection and retrieve the interests
            string query = "SELECT interest FROM interests WHERE user_id = @userId";

            using (DatabaseConnect database = new DatabaseConnect())
            {
                try
                {
                    database.Open();
                    using (SqlCommand command = new SqlCommand(query, database.Connection))
                    {
                        command.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int)).Value = userId;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Build a string of interests
                            StringBuilder interests = new StringBuilder();
                            while (reader.Read())
                            {
                                // Append each interest followed by a new line
                                interests.AppendLine(reader["interest"].ToString());
                            }

                            // Display the interests in the TextBox (each on a new line)
                            txtInterest.Text = interests.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }


        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
            // Open the ProfilePage form
            Profilepage profilePage = new Profilepage();
            profilePage.Show();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            // Open the ProfilePage form
            Profilepage profilePage = new Profilepage();
            profilePage.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Open the Interests page for the current user to update their interests
            Interests interestsPage = new Interests(userId, firstName, lastName, userType);
            interestsPage.Show();

            // Close the current profile form
            this.Close();
        }

        private void lblEditPhoto_MouseHover(object sender, EventArgs e)
        {
            lblEditPhoto.ForeColor = Color.Black;
        }

        private void lblEditPhoto_MouseLeave(object sender, EventArgs e)
        {
            lblEditPhoto.ForeColor = Color.White;
        }

        private void lblEditPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set filter to show image files only
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";

            // Show the dialog and check if the user selected a file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Load the selected image into the PictureBox
                    string selectedFilePath = openFileDialog.FileName;
                    profilePictureBox.Image = Image.FromFile(selectedFilePath);

                    profilePictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                    // Save to database
                    SaveImageToDatabase(selectedFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveImageToDatabase(string imagePath)
        {
            try
            {
                // Read the image file into a byte array
                byte[] imageBytes = File.ReadAllBytes(imagePath);

                // SQL query to update the ProfilePicture column
                string query = "UPDATE [user] SET profile_picture = @ProfilePicture WHERE user_id = @UserId";

                using (var db = new DatabaseConnect())
                {
                    db.Open();

                    using (var command = new SqlCommand(query, db.Connection))
                    {
                        // Add parameters to the query
                        command.Parameters.AddWithValue("@ProfilePicture", imageBytes);
                        command.Parameters.AddWithValue("@UserId", userId);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Profile picture updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to update profile picture.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    db.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving image to database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadProfilePicture(int userId)
        {
            try
            {
                // SQL query to retrieve the profile picture
                string query = "SELECT profile_picture FROM [user] WHERE user_id = @UserId";

                using (var db = new DatabaseConnect())
                {
                    db.Open();

                    using (var command = new SqlCommand(query, db.Connection))
                    {
                        // Add the user ID as a parameter
                        command.Parameters.AddWithValue("@UserId", userId);

                        // Execute the query and retrieve the image
                        var result = command.ExecuteScalar();
                        if (result != DBNull.Value && result != null)
                        {
                            byte[] imageBytes = (byte[])result;

                            // Convert the byte array to an Image and display it in the PictureBox
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                profilePictureBox.Image = Image.FromStream(ms);
                                profilePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                            }
                        }

                    }

                    db.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile picture: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MakePictureBoxRound(PictureBox pictureBox)
        {
            // Create a circular region
            System.Drawing.Drawing2D.GraphicsPath graphicsPath = new System.Drawing.Drawing2D.GraphicsPath();
            graphicsPath.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);

            // Apply the circular region to the PictureBox
            pictureBox.Region = new Region(graphicsPath);
        }

        private void btnBuyMembership_Click(object sender, EventArgs e)
        {
            String url = "https://www.togetherculture.com/about-our-membership";
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // Ensures compatibility with modern systems
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to open the link: {ex.Message}");
            }
        }
    }
}
