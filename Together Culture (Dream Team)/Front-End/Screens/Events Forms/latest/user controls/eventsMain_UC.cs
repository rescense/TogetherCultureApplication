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
using Together_Culture__Dream_Team_.Front_End.Src.Screens;

namespace Together_Culture__Dream_Team_.Front_End.Screens.Events_Forms
{
    public partial class eventsMain_UC : UserControl
    {
        public event EventHandler<eventsForm.EventDetails> EventSelected;
        public static int yearVar, monthVar;
        private ucDays currentlySelectedDay;
        public eventsMain_UC()
        {
            InitializeComponent();
            //if selected from calendar
            //LoadEvents();
        }
        private void eventsMain_UC_Load(object sender, EventArgs e)
        {
            showDays(DateTime.Now.Month, DateTime.Now.Year);
        }
        private void LoadEvents()
        {
            //load data for data gride view
        }

        private void btnSelectedEvent_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                // turn selected items into Event details
                var eventDetails = selectedRow.DataBoundItem as eventsForm.EventDetails;

                //raise event with eventDetails
                guna2Button1.Click += (s, e) => EventSelected?.Invoke(this, eventDetails);
                EventSelected?.Invoke(this, eventDetails);
            }
            else
            {
                MessageBox.Show("Please select one event");
            }
        }


        //  Calendar
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
            //blank days for allig,ent
            for (int i = 1; i < week; i++)
            {
                ucDays uc = new ucDays("");
                flowLayoutPanel1.Controls.Add(uc);
            }
            for (int i = 1; i < day; i++)
            {
                ucDays dayControl = new ucDays(i + "");
                dayControl.DateSelected += DayControl_DateSelected;
                flowLayoutPanel1.Controls.Add(dayControl);
            }
        }

        private void DayControl_DateSelected(object sender, string day)
        {
            if (currentlySelectedDay != null)
            {
                currentlySelectedDay.Deselect(); // Deselect the previously selected day
            }

            // Update the current selection
            currentlySelectedDay = sender as ucDays;

            // Combine selected day with current month and year
            string selectedDate = $"{yearVar}-{monthVar:D2}-{int.Parse(day):D2}";
            DateTime date = DateTime.Parse(selectedDate);

            // Load events for the selected date
            LoadEvents(date);
        }

        private void LoadEvents(DateTime selectedDate)
        {
            // Simulated data for demonstration purposes
            var events = new List<EventDetails>
            {
                new EventDetails { EventName = "Meeting", EventDate = DateTime.Today, EventDescription = "Team meeting" },
                new EventDetails { EventName = "Workshop", EventDate = DateTime.Today.AddDays(1), EventDescription = "Coding workshop" },
            };

            // Filter events based on the selected date
            var filteredEvents = events.Where(ev => ev.EventDate.Date == selectedDate.Date).ToList();
            dataGridView1.DataSource = filteredEvents;

            if (!filteredEvents.Any())
            {
                MessageBox.Show("No events found for the selected date.");
            }
        }

        // buttons for calendar
        // next btn
        private void guna2Button9_Click(object sender, EventArgs e)
        {
            monthVar += 1;
            if (monthVar > 12)
            {
                monthVar = 1;
                yearVar += 1;
            }
            showDays(monthVar, yearVar);
        }
        // previous btn
        private void guna2Button8_Click(object sender, EventArgs e)
        {
            monthVar -= 1;
            if (monthVar < 1)
            {
                monthVar = 12;
                yearVar -= 1;
            }
            showDays(monthVar, yearVar);
        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
