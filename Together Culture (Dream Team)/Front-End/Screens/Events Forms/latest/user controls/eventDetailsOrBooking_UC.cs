using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Together_Culture__Dream_Team_.Front_End.Screens.Events_Forms
{
    public partial class eventDetailsOrBooking_UC : UserControl
    {
                private BindingList<Attendee> attendeeList; // List of attendees
        private eventsForm.EventDetails eventDetails;

        public eventDetailsOrBooking_UC(eventsForm.EventDetails eventDetails)
        {
            InitializeComponent();

            this.eventDetails = eventDetails;
            attendeeList = new BindingList<Attendee>();

            LoadEventDetails();
            InitializeAttendeeSection();
        }

        // Load event details into the appropriate panel
        private void LoadEventDetails()
        {
            //lblEventName.Text = $"Event Name: {currentEvent.EventName}";
            //lblEventDate.Text = $"Date: {currentEvent.EventDate.ToShortDateString()}";
            //lblEventDescription.Text = $"Description: {currentEvent.EventDescription}";
        }

        // Initialize attendee section
        private void InitializeAttendeeSection()
        {
            dataGridViewAttendees.DataSource = attendeeList;

            // Populate ComboBox with attendee types
            comboBoxAttendeeType.Items.Add("Member");
            comboBoxAttendeeType.Items.Add("Guest");
            comboBoxAttendeeType.SelectedIndex = 0;
        }
        // Add attendee button click
        private void btnAddAttendee_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAttendeeName.Text) && comboBoxAttendeeType.SelectedIndex >= 0)
            {
                // Add attendee to the list
                attendeeList.Add(new Attendee
                {
                    Name = txtAttendeeName.Text.Trim(),
                    Type = comboBoxAttendeeType.SelectedItem.ToString()
                });

                txtAttendeeName.Clear();
            }
            else
            {
                MessageBox.Show("Please provide an attendee name and type.");
            }
        }
        // Remove attendee button click
        private void btnRemoveAttendee_Click(object sender, EventArgs e)
        {
            if (dataGridViewAttendees.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewAttendees.SelectedRows[0];
                var attendee = selectedRow.DataBoundItem as Attendee;

                if (attendee != null)
                {
                    attendeeList.Remove(attendee);
                }
            }
            else
            {
                MessageBox.Show("Please select an attendee to remove.");
            }
        }
        // Payment button click
        private void btnProcessPayment_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNumAttendees.Text.Trim(), out int numAttendees) && numAttendees > 0)
            {
                if (numAttendees == attendeeList.Count)
                {
                    // Add data to the database
                    SaveAttendeesToDatabase();
                    MessageBox.Show("Payment processed successfully and attendees saved!");
                }
                else
                {
                    MessageBox.Show("Number of attendees does not match the list of attendees provided.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number of attendees.");
            }
        }
        // Simulate saving attendees to a database
        private void SaveAttendeesToDatabase()
        {
            foreach (var attendee in attendeeList)
            {
                // Save logic here (e.g., insert into database)
                //Console.WriteLine($"Saving {attendee.Name} ({attendee.Type}) to database.");
            }
        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    // Attendee model for the DataGridView
    public class Attendee
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
    public class EventDetails
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string EventDescription { get; set; }
    }
}
