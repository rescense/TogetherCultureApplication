using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Together_Culture__Dream_Team_.Front_End.Src.User_Controls;
using togther_Culture;

namespace Together_Culture__Dream_Team_.Front_End.Src.Screens
{
    public partial class AdminDashboardcs : Form
    {
        public AdminDashboardcs()
        {
            InitializeComponent();
        }

        private void AdminDashboardcs_Load(object sender, EventArgs e)
        {

        }

        private void adminDashboardPanel2_MouseClick(object sender, MouseEventArgs e)
        {
            // Create an instance of the eventsMainForm form
            SearchUsersAdmin searchUsersAdminForm = new SearchUsersAdmin();

            // Show the eventsMainForm form
            searchUsersAdminForm.Show();

            this.Hide(); //  hide the form
        }

        private void adminDashboardPanel3_MouseClick(object sender, MouseEventArgs e)
        {
            // Create an instance of the eventsMainForm form
            SearchUsersAdmin searchUsersAdminForm = new SearchUsersAdmin();

            // Show the eventsMainForm form
            searchUsersAdminForm.Show();

            this.Hide(); //  hide the form
        }

        private void pictureBox4_MouseClick(object sender, MouseEventArgs e)
        {
            // Create an instance of the eventsMainForm form
            SearchUsersAdmin searchUsersAdminForm = new SearchUsersAdmin();

            // Show the eventsMainForm form
            searchUsersAdminForm.Show();

            this.Hide(); //  hide the form
        }

        private void searchUsersLabel_MouseClick(object sender, MouseEventArgs e)
        {
            // Create an instance of the eventsMainForm form
            SearchUsersAdmin searchUsersAdminForm = new SearchUsersAdmin();

            // Show the eventsMainForm form
            searchUsersAdminForm.Show();

            this.Hide(); //  hide the form
        }
    }
}
