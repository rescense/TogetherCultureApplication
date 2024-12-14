using Microsoft.VisualBasic.ApplicationServices;
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
using Together_Culture__Dream_Team_.Back_End.Src.Main;
using Together_Culture__Dream_Team_.Front_End.Src.Screens;

namespace Together_Culture__Dream_Team_.Front_End.Screens.Events_Forms
{
    public partial class eventsMain_UC : UserControl
    {
        private readonly DatabaseConnect _dbConnect;
        public static int yearVar, monthVar;
        private ucDays currentlySelectedDay;
        public eventsMain_UC()
        {
            InitializeComponent();
            _dbConnect = new DatabaseConnect();
        }
        private void eventsMain_UC_Load(object sender, EventArgs e)
        {
            showDays(DateTime.Now.Month, DateTime.Now.Year);
        }

        // ~~~~~~~~~~~~~~~~~   Calendar   ~~~~~~~~~~~~~~~~~
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
                currentlySelectedDay.Deselect();
            }

            // Update the current selection
            currentlySelectedDay = sender as ucDays;

            // Combine selected day with current month and year
            string selectedDate = $"{yearVar}-{monthVar:D2}-{int.Parse(day):D2}";
            DateTime date = DateTime.Parse(selectedDate);

            // Load events for the selected date
            LoadEvents(date);
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

        // ~~~~~~~~~~~~~~~~~~~~  event selection ~~~~~~~~~~~~~~~~~~~~~~~~~

        private void LoadEvents(DateTime selectedDate)
        {
            //load data for data gride view
            string query = "SELECT event_id, event_name, date, time, location, ticket_price FROM [event]";
            var eventsTable = _dbConnect.ExecuteQuery(query);
            List<Event> events = ConvertDataTableToList(eventsTable);

            // Filter events based on the selected date
            var filteredDataTableEvents = eventsTable.AsEnumerable()
                .Where(ev => ev.Field<DateTime>("Date").Date == selectedDate.Date)
                .CopyToDataTable();
            var filteredEvents = events.Where(ev => ev.Date.Date == selectedDate.Date).ToList();

            dataGridView1.DataSource = filteredDataTableEvents;

            if (!filteredEvents.Any())
            {
                MessageBox.Show("No events found for the selected date.");
            }
        }
        private void eventSelectedBtn_Click(object sender, EventArgs e)
        {
            // Check if there is a selected row
            if (dataGridView1.SelectedRows.Count == 1)
            {
                // Simulate DataGridViewCellEventArgs
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                var cellEventArgs = new DataGridViewCellEventArgs(0, rowIndex);

                // Call the existing method
                eventSelectedBtn(sender, cellEventArgs);
            }
            else
            {
                MessageBox.Show("Please select one event.");
            }
        }
        private void eventSelectedBtn(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dataGridView1.Rows[e.RowIndex];
                int eventId = Convert.ToInt32(selectedRow.Cells["event_id"].Value);
                DateTime eventDate = Convert.ToDateTime(selectedRow.Cells["date"].Value);
                eventsForm parentForm = this.Parent as eventsForm;

                // Check if the event is in the future or past
                if (eventDate.Date < DateTime.Now.Date)
                {
                    LoadEventFeedbackUC(eventId); // Load Feedback for past events
                }
                else
                {
                    LoadEventDetailsOrBookingUC(eventId); // Load Booking for future events
                }
            }
        }
        // ~~~~~~~~~~~~~~~~~ new pages for selected events ~~~~~~~~~~~~~~~~~
        // load feeedback page of event feed back and event bookings
        private void LoadEventFeedbackUC(int eventId)
        {
            var eventFeedbackUC = new eventFeedback_UC(eventId);
            eventFeedbackUC.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(eventFeedbackUC);

        }
        private void LoadEventDetailsOrBookingUC(int eventId)
        {
            var eventBookingUC = new eventDetailsOrBooking_UC(eventId);
            eventBookingUC.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(eventBookingUC);
        }


        // for conversion of data table to list
        public class Event
        {
            public int EventId { get; set; }
            public string EventName { get; set; }
            public DateTime Date { get; set; }
            public TimeSpan Time { get; set; }
            public string Location { get; set; }
            public decimal TicketPrice { get; set; }
            public int MaximumOccupancy { get; set; }
        }
        public List<Event> ConvertDataTableToList(DataTable dataTable)
        {
            List<Event> eventsList = new List<Event>();

            foreach (DataRow row in dataTable.Rows)
            {
                Event eventObj = new Event()
                {
                    EventId = Convert.ToInt32(row["event_id"]),
                    EventName = row["event_name"].ToString(),
                    Date = Convert.ToDateTime(row["date"]),
                    Time = Convert.ToDateTime(row["time"]).TimeOfDay,
                    Location = row["location"].ToString(),
                    TicketPrice = Convert.ToDecimal(row["ticket_price"]),
                    MaximumOccupancy = Convert.ToInt32(row["maximum_occupancy"])
                };

                eventsList.Add(eventObj);
            }

            return eventsList;
        }
        // ~~~~~~~~~~~~~~~ tools ~~~~~~~~~~~~~~~
        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
