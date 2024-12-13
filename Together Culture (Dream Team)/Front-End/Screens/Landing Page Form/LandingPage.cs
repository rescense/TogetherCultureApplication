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

        SideMenuBar SideMenuBar = new SideMenuBar();
        AboutUs AboutUs = new AboutUs();
        Memberships Memberships = new Memberships();
        Shop Shop = new Shop();
        Blog Blog = new Blog();
        PlaceHire UserControlPlaceHire = new PlaceHire();

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

        private void guna2CustomGradientPanel4_Paint_1(object sender, PaintEventArgs e)
        {
            addUserControl(AboutUs);
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

            addUserControl(Blog);

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
                addUserControl(UserControlPlaceHire);

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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String url = "https://static1.squarespace.com/static/63bc104e8f7c476406bd6221/t/63eb86ae583c021a4fbf916b/1676379822886/Privacy+and+Data+Protection+Statement_Together+Culture+2023.pdf";
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String url = "https://www.togetherculture.com/contact";
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

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String url = "https://static1.squarespace.com/static/63bc104e8f7c476406bd6221/t/63eb86ae583c021a4fbf916b/1676379822886/Privacy+and+Data+Protection+Statement_Together+Culture+2023.pdf";
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

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Black;

        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Transparent;
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            Sign_up sign_Up = new Sign_up();

            sign_Up.Show();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            Log_in log_In = new Log_in();
            log_In.Show();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
