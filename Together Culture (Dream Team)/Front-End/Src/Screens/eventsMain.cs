using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Together_Culture__Dream_Team_.Front_End.Src.Screens
{
    public partial class eventsMain : Form
    {
        public static int yearVar, monthVar;
        public eventsMain()
        {
            InitializeComponent();
        }

        private void eventsMain_Load(object sender, EventArgs e)
        {
            showDays(DateTime.Now.Month, DateTime.Now.Year);
        }

        // Header Panel
        private void headerPanel(object sender, PaintEventArgs e)
        {

        }

        // Together Culture Label
        private void togetherCultureLabel(object sender, EventArgs e)
        {

        }
        // Together Culture Logo
        private void togetherCultureLogoPictureBox(object sender, EventArgs e)
        {

        }

        // Header Panel buttons
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

        // Calendar Panel
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        // Calendar labels
        private void calendarLabel(object sender, EventArgs e)
        {

        }

        private void MonthLabel_Click(object sender, EventArgs e)
        {

        }
        // Days Label
        private void MondayLabel(object sender, EventArgs e)
        {

        }

        private void TuesdayLabel(object sender, EventArgs e)
        {

        }

        private void WednesdayLabel(object sender, EventArgs e)
        {

        }

        private void ThursdayLabel(object sender, EventArgs e)
        {

        }

        private void FridayLabel(object sender, EventArgs e)
        {

        }

        private void SaturdayLabel(object sender, EventArgs e)
        {

        }

        private void SundayLabel(object sender, EventArgs e)
        {

        }

        // filling days in calendar
        private void showDays(int month, int year)
        {
            flowLayoutPanel1.Controls.Clear();
            yearVar = year;
            monthVar = month;

            string monthName = new DateTimeFormatInfo().GetMonthName(month);
            monthLabel.Text = monthName.ToUpper() + " " + year;
            DateTime startOfTheMonth = new DateTime(year, month, 1);
            int day = DateTime.DaysInMonth(year, month);
            int week = Convert.ToInt32(startOfTheMonth.DayOfWeek.ToString("d"));
            for (int i = 1; i < week; i++)
            {
                ucDays uc = new ucDays("");
                flowLayoutPanel1.Controls.Add(uc);
            }
            for (int i = 1; i < day; i++)
            {
                ucDays uc = new ucDays(i + "");
                flowLayoutPanel1.Controls.Add(uc);
            }

        }

        // buttons for calendar
        private void nextBtn(object sender, EventArgs e)
        {
            monthVar += 1;
            if (monthVar > 12)
            {
                monthVar = 1;
                yearVar += 1;
            }
            showDays(monthVar, yearVar);
        }

        private void previousBtn(object sender, EventArgs e)
        {
            monthVar -= 1;
            if (monthVar < 1)
            {
                monthVar = 12;
                yearVar -= 1;
            }
            showDays(monthVar, yearVar);
        }

        // Upcoming events label
        private void upcomingEventsLabel(object sender, EventArgs e)
        {

        }
        // events list
        private void eventsListDataGridView(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void eventsListScrollBar(object sender, ScrollEventArgs e)
        {

        }

        // check events button
        private void checkEventsBtn(object sender, EventArgs e)
        {

        }
    }
}
