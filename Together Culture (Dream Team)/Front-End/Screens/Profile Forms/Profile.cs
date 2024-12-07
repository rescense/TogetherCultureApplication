

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

        // Constructor to accept username
        public Profile(string FirstName, String LastName, String UserType)
        {
            InitializeComponent();
            this.firstName = FirstName;
            this.lastName = LastName;
            this.userType = UserType;

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

        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            // Open the ProfilePage form
            Profilepage profilePage = new Profilepage();
            profilePage.Show();
        }
    }
}
