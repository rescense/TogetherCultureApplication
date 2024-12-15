using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Together_Culture__Dream_Team_.Front_End.Screens.Events_Forms;
using Together_Culture__Dream_Team_.Front_End.Screens.Skill_Share_Forms.latest;
using Together_Culture__Dream_Team_.Front_End.Src.User_Controls;

namespace Together_Culture__Dream_Team_.Front_End.Src.Screens
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void AdminDashboardcs_Load(object sender, EventArgs e)
        {
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

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            guna2CustomGradientPanel4.Controls.Clear();
            guna2CustomGradientPanel4.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            SearchUsers userControlSearchUsers = new SearchUsers();
            addUserControl(userControlSearchUsers);
        }

        private void timeBankLbl_MouseHover(object sender, EventArgs e)
        {
            // Change text color to black on hover
            timeBankLbl.ForeColor = Color.Black;
        }

        private void timeBankLbl_MouseLeave(object sender, EventArgs e)
        {
            // Change text color to white when mouse leaves
            timeBankLbl.ForeColor = Color.White;
        }

        private void eventsLbl_MouseHover(object sender, EventArgs e)
        {
            // Change text color to black on hover
            eventsLbl.ForeColor = Color.Black;
        }

        private void eventsLbl_MouseLeave(object sender, EventArgs e)
        {
            // Change text color to white when mouse leaves
            eventsLbl.ForeColor = Color.White;
        }

        private void forYouLbl_MouseHover(object sender, EventArgs e)
        {
            // Change text color to black on hover
            forYouLbl.ForeColor = Color.Black;
        }

        private void forYouLbl_MouseLeave(object sender, EventArgs e)
        {
            // Change text color to white when mouse leaves
            forYouLbl.ForeColor = Color.White;
        }

        private void chatSpaceLbl_MouseHover(object sender, EventArgs e)
        {
            // Change text color to black on hover
            chatSpaceLbl.ForeColor = Color.Black;
        }

        private void chatSpaceLbl_MouseLeave(object sender, EventArgs e)
        {
            // Change text color to white when mouse leaves
            chatSpaceLbl.ForeColor = Color.White;
        }

        private void togetherCultureLbl_MouseHover(object sender, EventArgs e)
        {
            // Change text color to black on hover
            togetherCultureLbl.ForeColor = Color.Black;
        }

        private void togetherCultureLbl_MouseLeave(object sender, EventArgs e)
        {
            // Change text color to white when mouse leaves
            togetherCultureLbl.ForeColor = Color.White;
        }

        private void eventsLbl_MouseClick(object sender, MouseEventArgs e)
        {
            // Create an instance of the eventsMainForm form
            eventsMain eventsMainForm = new eventsMain();

            // Show the eventsMainForm form
            eventsMainForm.Show();

            this.Close(); //  close the form
        }

        private void togetherCultureLbl_MouseClick(object sender, MouseEventArgs e)
        {
            // Create an instance of the eventsMainForm form
            landingPage landingPageForm = new landingPage();

            // Show the eventsMainForm form
            landingPageForm.Show();

            this.Close(); //  close the form
        }

        private void timeBankLbl_MouseClick(object sender, MouseEventArgs e)
        {
            // Create an instance of the skillShare form
            skillShareMain skillShareForm = new skillShareMain();

            // Show the skillShareMain form
            skillShareForm.Show();

            this.Close(); //  close the form
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            SearchPendingApprovals userControlSearchPendingApprovals = new SearchPendingApprovals();
            addUserControl(userControlSearchPendingApprovals);
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            SearchEventsAdmin userControlSearchEventsAdmin = new SearchEventsAdmin();
            addUserControl(userControlSearchEventsAdmin);
        }

        private void adminPic_Click(object sender, EventArgs e)
        {
            // Create an instance of the AdminDashboardcs form
            AdminDashboard adminDashboardcsForm = new AdminDashboard();

            // Show the eventsMainForm form
            adminDashboardcsForm.Show();

            this.Close(); //  close the form
        }
    }
}
