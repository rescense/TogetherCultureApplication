
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Together_Culture__Dream_Team_.Front_End.Src.ToolBoxItems;
using Together_Culture__Dream_Team_.Front_End.Src.Screens;
using togther_Culture;

namespace Together_Culture__Dream_Team_.Front_End.Src.User_Controls
{
    public partial class SearchUsersAdmin : Form
    {
        public SearchUsersAdmin()
        {
            InitializeComponent();


            RoundedPanel roundedPanel = new RoundedPanel
            {
                Size = new Size(300, 200), // Set size of the panel
                Location = new Point(10, 10), // Set location on the form
                BackColor = Color.LightBlue, // Background color
                ForeColor = Color.DarkBlue, // Border color
                CornerRadius = 30 // Customize corner radius
            };

            // Add the RoundedPanel to the form's controls
            this.Controls.Add(roundedPanel);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SearchUsersAdmin_Load(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timeBankBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the skillShareMain form
            skillShare skillShareForm = new skillShare();

            // Show the skillShareMain form
            skillShareForm.Show();

            this.Close(); //  completely close the form
        }
    }

}
