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
    public partial class eventFeedback_UC : UserControl
    {
        private BindingList<Feedback> feedbackList;
        private eventsForm.EventDetails eventDetails;

        public eventFeedback_UC(eventsForm.EventDetails eventDetails)
        {
            InitializeComponent();
            this.eventDetails = eventDetails;
            feedbackList = new BindingList<Feedback>();

            if (eventDetails == null)
            {
                throw new ArgumentNullException(nameof(eventDetails), "Event details cannot be null.");
            }

            LoadEventDetails();
            LoadFeedback();
        }

        // Load event details into the appropriate panel
        private void LoadEventDetails()
        {
            //lblEventName.Text = $"Event Name: {currentEvent.EventName}";
            //lblEventDate.Text = $"Date: {currentEvent.EventDate.ToShortDateString()}";
            //lblEventDescription.Text = $"Description: {currentEvent.EventDescription}";
        }

        // Load feedback into the DataGridView
        private void LoadFeedback()
        {
            // Simulate fetching feedback from a database

            var sampleFeedback = new List<Feedback>
            {
            new Feedback { UserName = "Alice", Comment = "Great event!", Timestamp = DateTime.Now.AddDays(-1) },
            new Feedback { UserName = "Bob", Comment = "Very informative.", Timestamp = DateTime.Now.AddDays(-2) }
            };

            foreach (var feedback in sampleFeedback)
            {
                feedbackList.Add(feedback);
            }

            dataGridView2.DataSource = feedbackList;
            // feedback list - list of feedback related to the event.
        }

        // Handle adding new feedback
        private void btnAddFeedback_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(richTextBox3.Text))
            {
                // Add new feedback to the list
                // get user name from database assign to variable
                feedbackList.Add(new Feedback
                {
                    UserName = "variable here",
                    Comment = richTextBox3.Text.Trim(),
                    Timestamp = DateTime.Now
                });

                richTextBox3.Clear();
            }
            else
            {
                MessageBox.Show("Please enter your feedback before submitting.");
            }

        }

        // Feedback model for the DataGridView
        public class Feedback
        {
            public string UserName { get; set; }
            public string Comment { get; set; }
            public DateTime Timestamp { get; set; }
        }

        // tools
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
