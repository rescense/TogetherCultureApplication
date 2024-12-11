using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Together_Culture__Dream_Team_.Front_End.Src.Screens;

namespace Together_Culture__Dream_Team_.Front_End.Screens.Events_Forms
{
    public partial class eventsForm : Form
    {
        public eventsForm()
        {
            InitializeComponent();
            LoadEventMainUserControl();
        }
        private void eventsForm_Load(object sender, EventArgs e)
        {

        }

        // user controls
        private void LoadEventMainUserControl()
        {
            var eventsMainUC = new eventsMain_UC();
            eventsMainUC.Dock = DockStyle.Fill;

            // after database
            // eventsMainUC.EventSelected += eventsMain_UC_EventSelected;

            panel1.Controls.Clear();
            panel1.Controls.Add(eventsMainUC);

        }
        private void eventsMain_UC_EventSelected(object sender, EventDetails e) 
        {
            if (e.EventDate.Date <= DateTime.Today)
            {
                LoadEventFeedbackUC(e);
            }
            else 
            {
                LoadEventDetailsOrBookingUC(e);
            }
        }

        private void LoadEventFeedbackUC(EventDetails eventDetails) 
        {
            var eventFeedbackUC = new eventFeedback_UC(eventDetails);
            eventFeedbackUC.Dock = DockStyle.Fill;

            // back to main page
            // eventFeedbackUC.BackToEvents += (s, args) => LoadEventMainUserControl();

            panel1.Controls.Clear();
            panel1.Controls.Add(eventFeedbackUC);

        }
        private void LoadEventDetailsOrBookingUC( EventDetails eventDetails)
        {
            var eventBookingUC = new eventDetailsOrBooking_UC (eventDetails);
            eventBookingUC.Dock = DockStyle.Fill;

            // back to main page
            // eventBookingUC.BackToEvents += (s, args) => LoadEventMainUserControl();

            panel1.Controls.Clear();
            panel1.Controls.Add(eventBookingUC);
        }

        // rest

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }

        private void userControlPanel(object sender, PaintEventArgs e) // design name - panel1
        {

        }
        public class EventDetails
        {
            public string EventName { get; set; }
            public DateTime EventDate { get; set; }
            public string EventDescription { get; set; }
        }
    }
}
