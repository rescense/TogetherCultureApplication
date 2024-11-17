using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Together_Culture__Dream_Team_.Front_End.Src.Screens.All_Users_Screen;
using Together_Culture__Dream_Team_.Front_End.Src.User_Controls;
using togther_Culture;

namespace Together_Culture__Dream_Team_.Front_End.Src.Screens
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();

            myModulesBtn.FlatAppearance.MouseOverBackColor = myModulesBtn.BackColor; // No background change on hover
            myModulesBtn.FlatAppearance.MouseDownBackColor = myModulesBtn.BackColor; // No background change on click

            timeBankBtn.FlatAppearance.MouseOverBackColor = timeBankBtn.BackColor; // No background change on hover
            timeBankBtn.FlatAppearance.MouseDownBackColor = timeBankBtn.BackColor; // No background change on click

            eventsBtn.FlatAppearance.MouseOverBackColor = eventsBtn.BackColor; // No background change on hover
            eventsBtn.FlatAppearance.MouseDownBackColor = eventsBtn.BackColor; // No background change on click

            forYouBtn.FlatAppearance.MouseOverBackColor = forYouBtn.BackColor; // No background change on hover
            forYouBtn.FlatAppearance.MouseDownBackColor = forYouBtn.BackColor; // No background change on click

            chatBtn.FlatAppearance.MouseOverBackColor = chatBtn.BackColor; // No background change on hover
            chatBtn.FlatAppearance.MouseDownBackColor = chatBtn.BackColor; // No background change on click
        }

        private void adminDashboardPanel_MouseHover(object sender, EventArgs e)
        {
            // Change text color to black on hover
            adminDashboardPanel.BackColor = Color.FromArgb(217, 204, 200);
        }

        private void adminDashboardPanel_MouseLeave(object sender, EventArgs e)
        {
            // Change text color to black on hover
            adminDashboardPanel.BackColor = Color.FromArgb(248, 237, 235);
        }

        private void adminDashboardPanel2_MouseHover(object sender, EventArgs e)
        {
            // Change text color to black on hover
            adminDashboardPanel2.BackColor = Color.FromArgb(217, 204, 200);
        }

        private void adminDashboardPanel2_MouseLeave(object sender, EventArgs e)
        {
            // Change text color to black on hover
            adminDashboardPanel2.BackColor = Color.FromArgb(248, 237, 235);
        }

        private void adminDashboardPanel3_MouseHover(object sender, EventArgs e)
        {
            // Change text color to black on hover
            adminDashboardPanel3.BackColor = Color.FromArgb(217, 204, 200);
        }

        private void adminDashboardPanel3_MouseLeave(object sender, EventArgs e)
        {
            // Change text color to black on hover
            adminDashboardPanel3.BackColor = Color.FromArgb(248, 237, 235);
        }

        private void ChatBtn_MouseHover(object sender, EventArgs e)
        {
            // Change text color to black on hover
            chatBtn.ForeColor = Color.Black;
        }

        private void ChatBtn_MouseLeave(object sender, EventArgs e)
        {
            // Reset text color when the mouse leaves
            chatBtn.ForeColor = Color.White;
        }

        private void ForYouBtn_MouseHover(object sender, EventArgs e)
        {
            // Change text color to black on hover
            forYouBtn.ForeColor = Color.Black;
        }

        private void ForYouBtn_MouseLeave(object sender, EventArgs e)
        {
            // Reset text color when the mouse leaves
            forYouBtn.ForeColor = Color.White;
        }

        private void EventsBtn_MouseHover(object sender, EventArgs e)
        {
            // Change text color to black on hover
            eventsBtn.ForeColor = Color.Black;
        }

        private void EventsBtn_MouseLeave(object sender, EventArgs e)
        {
            // Reset text color when the mouse leaves
            eventsBtn.ForeColor = Color.White;
        }

        private void TimeBankBtn_MouseHover(object sender, EventArgs e)
        {
            // Change text color to black on hover
            timeBankBtn.ForeColor = Color.Black;
        }

        private void TimeBankBtn_MouseLeave(object sender, EventArgs e)
        {
            // Reset text color when the mouse leaves
            timeBankBtn.ForeColor = Color.White;
        }

        private void MyModulesBtn_MouseHover(object sender, EventArgs e)
        {
            // Change text color to black on hover
            myModulesBtn.ForeColor = Color.Black;
        }

        private void MyModulesBtn_MouseLeave(object sender, EventArgs e)
        {
            // Reset text color when the mouse leaves
            myModulesBtn.ForeColor = Color.White;
        }

        private void timeBankBtn_MouseClick(object sender, MouseEventArgs e)
        {
            // Create an instance of the skillShare form
            skillShare skillShareForm = new skillShare();

            // Show the skillShareMain form
            skillShareForm.Show();

            this.Close(); //  close the form
        }

        private void eventsBtn_MouseClick(object sender, MouseEventArgs e)
        {
            // Create an instance of the eventsMainForm form
            eventsMain eventsMainForm = new eventsMain();

            // Show the eventsMainForm form
            eventsMainForm.Show();

            this.Close(); //  close the form
        }

        private void label7_MouseClick(object sender, MouseEventArgs e)
        {
            // Create an instance of the eventsMainForm form
            landingPage landingPageForm = new landingPage();

            // Show the eventsMainForm form
            landingPageForm.Show();

            this.Close(); //  close the form
        }
        private void Label7_MouseLeave(object sender, EventArgs e)
        {
            // Reset text color when the mouse leaves
            label7.ForeColor = Color.White;
        }

        private void Label7_MouseHover(object sender, EventArgs e)
        {
            // Change text color to black on hover
            label7.ForeColor = Color.Black;
        }

        private void AdminDashboardcs_Load(object sender, EventArgs e)
        {

        }

        private void adminDashboardPanel2_MouseClick(object sender, MouseEventArgs e)
        {
            // Create an instance of the SearchUsersAdmin form
            SearchPendingApprovalsAdmin searchPendingApprovalsAdminForm = new SearchPendingApprovalsAdmin();

            // Show the SearchUsersAdmin form
            searchPendingApprovalsAdminForm.Show();

            this.Close(); //  close the form
        }

        private void adminDashboardPanel3_MouseClick(object sender, MouseEventArgs e)
        {
            // Create an instance of the SearchUsersAdmin form
            SearchUsersAdmin searchUsersAdminForm = new SearchUsersAdmin();

            // Show the SearchUsersAdmin form
            searchUsersAdminForm.Show();

            this.Close(); //  close the form
        }

        private void pictureBox4_MouseClick(object sender, MouseEventArgs e)
        {
            // Create an instance of the SearchUsersAdmin form
            SearchUsersAdmin searchUsersAdminForm = new SearchUsersAdmin();

            // Show the SearchUsersAdmin form
            searchUsersAdminForm.Show();

            this.Close(); //  close the form
        }

        private void searchUsersLabel_MouseClick(object sender, MouseEventArgs e)
        {
            // Create an instance of the SearchUsersAdmin form
            SearchUsersAdmin searchUsersAdminForm = new SearchUsersAdmin();

            // Show the SearchUsersAdmin form
            searchUsersAdminForm.Show();

            this.Close(); //  close the form
        }
    }
}
