using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Together_Culture__Dream_Team_.Front_End.Screens.Skill_Share_Forms.latest.user_controls
{
    public partial class TimeBankUserControl : UserControl
    {
        public TimeBankUserControl()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            var timeRequested = new Label { Text = "Time Requested: 5 hours" };
            var timeOffered = new Label { Text = "Time Offered: 10 hours" };
            var timeLeft = new Label { Text = "Time Left: 5 hours" };

            var layout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, AutoSize = true };
            layout.Controls.Add(timeRequested);
            layout.Controls.Add(timeOffered);
            layout.Controls.Add(timeLeft);

            Controls.Add(layout);
        }
        private void guna2CustomGradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}