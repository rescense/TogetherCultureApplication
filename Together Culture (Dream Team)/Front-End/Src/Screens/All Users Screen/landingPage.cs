using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        AboutUs AboutUs = new AboutUs();
        Memberships Memberships = new Memberships();
        Shop Shop = new Shop();

        private bool isSideMenuVisible = false;
        private bool colorChange = false;

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

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            if (!isSideMenuVisible)
            {
                panel1.Visible = false;

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
            addUserControl(AboutUs);
        }

        // Community Member button redirect to website
        private void communityMemberButton_Click_1(object sender, EventArgs e)
        {

        }

        // Creative Workspace Member button redirect to website
        private void creativeWorkspaceButton_Click_1(object sender, EventArgs e)
        {
            String url = "https://www.togetherculture.com/creative-workspace";
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

        // Organization Member button redirect to website
        private void organizationMemberButton_Click(object sender, EventArgs e)
        {
            String url = "https://www.togetherculture.com/business-unusual-membership";
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

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void aboutUsLabel_Click(object sender, EventArgs e)
        {
            addUserControl(AboutUs);


            if (!colorChange)
            {

                // Change PictureBox color when visible
                label2.BackColor = Color.Black; // Example color
                label3.BackColor = Color.Transparent;
                label4.BackColor = Color.Transparent;
                label17.BackColor = Color.Transparent;
                label18.BackColor = Color.Transparent;
            }
            else
            {

                label2.BackColor = Color.Transparent;
            }
        }

        private void membershipLabel_Click(object sender, EventArgs e)
        {
            addUserControl(Memberships);

            if (!colorChange)
            {

                // Change PictureBox color when visible
                label3.BackColor = Color.Black; // Example color
                label2.BackColor = Color.Transparent;
                label4.BackColor = Color.Transparent;
                label17.BackColor = Color.Transparent;
                label18.BackColor = Color.Transparent;
            }
            else
            {

                label3.BackColor = Color.Transparent;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

            addUserControl(Shop);
            if (!colorChange)
            {

                // Change PictureBox color when visible
                label4.BackColor = Color.Black; // Example color
                label2.BackColor = Color.Transparent;
                label3.BackColor = Color.Transparent;
                label17.BackColor = Color.Transparent;
                label18.BackColor = Color.Transparent;
            }
            else
            {

                label4.BackColor = Color.Transparent;
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {
            if (!colorChange)
            {

                // Change PictureBox color when visible
                label17.BackColor = Color.Black; // Example color
                label2.BackColor = Color.Transparent;
                label3.BackColor = Color.Transparent;
                label4.BackColor = Color.Transparent;
                label18.BackColor = Color.Transparent;
            }
            else
            {

                label17.BackColor = Color.Transparent;
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {
            if (!colorChange)
            {

                // Change PictureBox color when visible
                label18.BackColor = Color.Black; // Example color
                label2.BackColor = Color.Transparent;
                label3.BackColor = Color.Transparent;
                label4.BackColor = Color.Transparent;
                label17.BackColor = Color.Transparent;
            }
            else
            {

                label18.BackColor = Color.Transparent;
            }
        }
    }
}
