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

namespace Together_Culture__Dream_Team_.Front_End.Src.Screens
{
    public partial class landingPage : Form
    {
        public landingPage()
        {
            InitializeComponent();
        }

        usrCntrl_AboutUs usrCntrl_AboutUs = new usrCntrl_AboutUs();
        usrCntrl_Memberships usrCntrl_Memberships = new usrCntrl_Memberships();
        SideMenuBar SideMenuBar = new SideMenuBar();

        private bool isSideMenuVisible = false;

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            guna2CustomGradientPanel4.Controls.Clear();
            guna2CustomGradientPanel4.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void showSideMenu(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(userControl);
            userControl.BringToFront();

        }

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
                pictureBox3.BackColor = Color.White; // Example color
            }
            else
            {
                // Hide the sidebar
                panel1.Controls.Clear(); // Remove the sidebar from the panel
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
                BringToFront();
                
            }

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            usrCntrl_AboutUs usrCntrl_AboutUs = new usrCntrl_AboutUs();
            addUserControl(usrCntrl_AboutUs);
        }
        private void guna2ButtonMembership_Click(object sender, EventArgs e)
        {
            addUserControl(usrCntrl_Memberships);
        }




        private void landingPage_Load(object sender, EventArgs e)
        {

        }

        private void usrCntrl_AboutUs1_Load(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void userControl11_Load_1(object sender, EventArgs e)
        {

        }

        private void usrCntrl_Memberships1_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel4_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
