using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using togther_Culture;

namespace Together_Culture__Dream_Team_.Front_End.Src.Screens.All_Users_Screen
{
    public partial class SearchPendingApprovalsAdmin : Form
    {
        public SearchPendingApprovalsAdmin()
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

        private void SearchPendingApprovalsAdmin_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void searchApprovalsTxtBx_Leave(object sender, EventArgs e)
        {
            // Restore the placeholder text if the user has left it empty
            if (string.IsNullOrEmpty(searchApprovalsTxtBx.Text))
            {
                searchApprovalsTxtBx.Text = "Search pending approvals...";
                searchApprovalsTxtBx.ForeColor = System.Drawing.Color.Gray; // Change color back to gray
            }
        }

        private void searchApprovalsTxtBx_MouseClick(object sender, MouseEventArgs e)
        {
            // Only clear the placeholder text if it's the default
            if (searchApprovalsTxtBx.Text == "Search pending approvals...")
            {
                searchApprovalsTxtBx.Text = "";
                searchApprovalsTxtBx.ForeColor = System.Drawing.Color.Black; // Change text color to black when editing
            }
        }

        private void adminPic_MouseClick(object sender, MouseEventArgs e)
        {
            // Create an instance of the eventsMainForm form
            AdminDashboard adminDashboardForm = new AdminDashboard();

            // Show the eventsMainForm form
            adminDashboardForm.Show();

            this.Close(); //  close the form
        }
    }
}
