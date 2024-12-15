using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Together_Culture__Dream_Team_.Front_End.Screens.Skill_Share_Forms.latest.user_controls
{
    public partial class TimeBankUserControl : UserControl
    {
        public TimeBankUserControl()
        {
            InitializeComponent();
            InitializeTimeBankInfo();
        }

        private void InitializeTimeBankInfo()
        {
            // Sample data for Time Bank
            // These values would ideally come from a database or another source
            int timeRequested = 3;  // In hours
            int timeOffered = 5;    // In hours
            int timeLeft = 10;      // In hours

            // Update the labels with the data
            label5.Text = $"{timeRequested} hours";    // Label showing the time requested
            label6.Text = $"{timeOffered} hours";        // Label showing the time offered
            label8.Text = $"You have {timeLeft} hours left in your\nTime Bank.";  // Label showing the time left
        }
        private void guna2CustomGradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}