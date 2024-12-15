using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml.Linq;
using Together_Culture__Dream_Team_.Back_End.Src.Main;
using static Together_Culture__Dream_Team_.Front_End.Screens.Events_Forms.eventsMain_UC;

namespace Together_Culture__Dream_Team_.Front_End.Screens.Events_Forms
{
    public partial class eventFeedback_UC : UserControl
    {
        private readonly int _eventId;
        private readonly DatabaseConnect _dbConnect;

        public eventFeedback_UC(int eventId)
        {
            InitializeComponent();
            _eventId = eventId;
            _dbConnect = new DatabaseConnect();
        }
        private void eventFeedback_UC_Load(object sender, EventArgs e)
        {
            LoadEventDetails();
            LoadFeedback();
        }
        private void LoadEventDetails()
        {
            string query = $"SELECT event_name, date, time, location, ticket_price FROM [event] WHERE event_id = {_eventId}";
            var eventDetails = _dbConnect.ExecuteQuery(query);

            if (eventDetails.Rows.Count > 0)
            {
                var row = eventDetails.Rows[0];
                label4.Text = row["event_name"].ToString() + "\n\n\n" +
                row["date"].ToString() + "\n\n\n" +
                row["time"].ToString() + "\n\n\n" +
                row["location"].ToString() + "\n\n\n" +
                row["ticket_price"].ToString();
            }
        }

        // Load feedback into the DataGridView
        private void LoadFeedback()
        {
            string query = $"SELECT comment, feedback_date FROM [feedback] WHERE event_id = {_eventId}";
            var feedbackTable = _dbConnect.ExecuteQuery(query);            
            dataGridView2.DataSource = feedbackTable;

            // Show count of feedbacks
            label10.Text = $"{feedbackTable.Rows.Count} feedbacks received";
        }

        // Handle adding new feedback
        private void btnAddFeedback_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(richTextBox3.Text))
            {
                string comment = richTextBox3.Text;
                string query = $"INSERT INTO [feedback] (event_id, comment, feedback_date) " +
                    $"VALUES ({_eventId}, '{comment}', '{DateTime.Now.Date}')";
                
                _dbConnect.ExecuteQuery(query);

                richTextBox3.Clear();
            }
            else
            {
                MessageBox.Show("Please enter your feedback before submitting.");
            }

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
