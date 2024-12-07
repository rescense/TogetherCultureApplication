using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Together_Culture__Dream_Team_.Front_End.Src.Screens;
using Together_Culture__Dream_Team_.Front_End.Src.User_Controls;

namespace Together_Culture__Dream_Team_.Front_End.Screens.Profile_Forms
{
    public partial class Profilepage : Form
    {
        public Profilepage()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            // Create an instance of UserControlPI
            UserControlPI personalInfoControl = new UserControlPI();

            // Set the Dock property to fill the panel (optional)
            personalInfoControl.Dock = DockStyle.Fill;

            // Add the UserControlPI to the panel
            guna2CustomGradientPanel1.Controls.Add(personalInfoControl);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            // Open the Profile form
            Profile profile = new Profile();
            profile.Show();

            // Close the current form
            this.Close();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
