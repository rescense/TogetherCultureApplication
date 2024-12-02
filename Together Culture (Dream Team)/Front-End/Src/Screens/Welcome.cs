using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Timer = System.Windows.Forms.Timer;

namespace Together_Culture__Dream_Team_.Front_End.Src.Screens
{
    public partial class Welcome : Form
    {

        Timer timer = new Timer();
        public Welcome()
        {
            InitializeComponent();
        }


        private void Welcome_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = 100; // Set the maximum value
            progressBar1.Value = 0;     // Initialize to 0

            timer.Interval = 30; // Set the timer interval (in milliseconds)
            timer.Tick += Timer_Tick; // Subscribe to the Tick event
            timer.Start(); // Start the timer
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value += 1; // Increment progress bar value
            }
            else
            {
                timer.Stop(); // Stop the timer when progress is complete

                landingPage landingPage = new landingPage(); // Navigate to landing page
                landingPage.Show();

                this.Hide(); // Hide the current form
            }
        }
    }
}
