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

        SideMenuBar SideMenuBar = new SideMenuBar();
        public AdminDashboardcs()
        {
            InitializeComponent();
        }

        private void AdminDashboardcs_Load(object sender, EventArgs e)
        {

        }

        private void showSideMenu(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(userControl);
            userControl.BringToFront();

        }

        private bool isSideMenuVisible = false;


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (!isSideMenuVisible)
            {
                // Show the sidebar
                panel1.Visible = true;
                showSideMenu(SideMenuBar);
                isSideMenuVisible = true;
                BringToFront();

                // Change PictureBox color when visible
                pictureBox3.BackColor = Color.Black;
            }
            else
            {
                // Hide the sidebar
                panel1.Controls.Clear();
                panel1.Visible = false;
                isSideMenuVisible = false;

                pictureBox3.BackColor = Color.Transparent;
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (!isSideMenuVisible)
            {
                panel1.Visible = false;

            }
        }

        private void guna2CustomGradientPanel4_Paint(object sender, PaintEventArgs e)
        {

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
            UserControlSearchUsers userControlSearchUsers = new UserControlSearchUsers();
            addUserControl(userControlSearchUsers);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
        }
    }
}
