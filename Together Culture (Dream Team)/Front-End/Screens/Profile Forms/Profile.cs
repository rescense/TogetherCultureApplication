

using Microsoft.VisualBasic.ApplicationServices;
using Together_Culture__Dream_Team_.Front_End.Screens.Profile_Forms;

namespace Together_Culture__Dream_Team_.Front_End.Src.Screens
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
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
            // Close the current form
            this.Close();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Open the Interests page for the current user to update their interests
            Interests interestsPage = new Interests(userId, firstName, lastName, userType);
            interestsPage.Show();

            // Close the current profile form
            this.Close();
        }
    }
}
