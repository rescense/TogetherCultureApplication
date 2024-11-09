using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace togther_Culture
{
    public partial class eventsMain : Form
    {
        public eventsMain()
        {
            InitializeComponent();
        }

        private void eventsMain_Load(object sender, EventArgs e)
        {
            displayDays();
        }

        private void displayDays()
        {
            DateTime now = DateTime.Now;
            // getting first day of the month and count of days
            DateTime startOfTheMonth = new DateTime(now.Year, now.Month, 1);
            int days = DateTime.DaysInMonth(now.Year, now.Month);
            int dayOfTheWeek = Convert.ToInt32(startOfTheMonth.DayOfWeek.ToString("d"));

            // blank user control
        }
        // ~~~~~  Header Panel  ~~~~~
        private void headerPanel(object sender, PaintEventArgs e) { }

        // together culture label on header panel
        private void Together_Click_1(object sender, EventArgs e)
        {

        }
        private void Culture_Click_1(object sender, EventArgs e)
        {

        }
        private void Cambridge_Click_1(object sender, EventArgs e)
        {

        }

        // Buttons on header Panel
        private void chatSpaceBtn(object sender, EventArgs e)
        {

        }

        private void forYouBtn(object sender, EventArgs e)
        {

        }

        private void eventsBtn(object sender, EventArgs e)
        {

        }

        private void skillShareBtn(object sender, EventArgs e)
        {

        }

        private void myModulesBtn(object sender, EventArgs e)
        {

        }

        private void profileBtn(object sender, EventArgs e)
        {

        }

        // ~~~~~  Events Panel  ~~~~~~
        private void eventsPanel(object sender, PaintEventArgs e)
        {

        }

        // ----------- Calendar -----------
        // ----- label above calender -----
        private void upcomingMonthsLabel(object sender, EventArgs e)
        {

        }
        private void monthLabel(object sender, EventArgs e)
        {

        }
        // days label
        private void mondayLabel(object sender, EventArgs e)
        {

        }

        private void tuesdayLabel(object sender, EventArgs e)
        {

        }
        private void wednesdayLabel(object sender, EventArgs e)
        {

        }

        private void thursdayLabel(object sender, EventArgs e)
        {

        }

        private void fridayLabel(object sender, EventArgs e)
        {

        }

        private void saturdayLabel(object sender, EventArgs e)
        {

        }

        private void sundayLabel(object sender, EventArgs e)
        {

        }


        // buttons for calender
        private void nextBtn(object sender, EventArgs e)
        {

        }

        private void previousBtn(object sender, EventArgs e)
        {

        }

        private void panel44_Paint(object sender, PaintEventArgs e)
        {

        }

        // calender panel

        // details of event label
        // details of event grid view and vertical scroll bar

    }
}
