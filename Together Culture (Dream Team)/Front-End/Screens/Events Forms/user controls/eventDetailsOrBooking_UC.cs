using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Together_Culture__Dream_Team_.Back_End.Src.Main;

namespace Together_Culture__Dream_Team_.Front_End.Screens.Events_Forms
{
    public partial class eventDetailsOrBooking_UC : UserControl
    {
        private readonly int _eventId;
        private readonly DatabaseConnect _dbConnect;

        public eventDetailsOrBooking_UC(int eventId)
        {
            InitializeComponent();
            _eventId = eventId;
            _dbConnect = new DatabaseConnect();
        }
        private void eventDetailsOrBooking_UC_Load(object sender, EventArgs e)
        {
            LoadEventDetails();
        }
        private void LoadEventDetails()
        {          
            string query = $"SELECT event_name, date, time, location, ticket_price FROM [event] WHERE event_id = {_eventId}";
            var eventDetails = _dbConnect.ExecuteQuery(query);

            if (eventDetails.Rows.Count > 0)
            {
                var row = eventDetails.Rows[0];
                label4.Text = row["event_name"].ToString() +
                    row["date"].ToString() + "\n\n\n" +
                    row["time"].ToString() + "\n\n\n" +
                    row["location"].ToString() +
                    row["ticket_price"].ToString();
            }
        }
        private void InitializeAttendeeSection()
        {
            // Populate ComboBox with attendee types
            comboBoxAttendeeType.Items.Add("member");
            comboBoxAttendeeType.Items.Add("concession");
            comboBoxAttendeeType.Items.Add("full_price");
            comboBoxAttendeeType.SelectedIndex = 0;
        }
        // Add attendee button click
        private void btnAddAttendee_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAttendeeName.Text) && comboBoxAttendeeType.SelectedIndex >= 0)
            {
                string attendeeName = txtAttendeeName.Text;
                string attendeeType = comboBoxAttendeeType.SelectedItem.ToString();
                //decimal ticketPrice = decimal.Parse(lblTicketPrice.Text);
                decimal ticketPrice = 10;

                // Add to DataGrid
                dataGridViewAttendees.Rows.Add(attendeeName, attendeeType, ticketPrice);

                // Calculate total price
                decimal totalPrice = dataGridViewAttendees.Rows.Cast<DataGridViewRow>()
                    .Sum(row => Convert.ToDecimal(row.Cells["TicketPrice"].Value));

                label6.Text = $"Total price: {totalPrice:C2}";

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
            if (dataGridViewAttendees.SelectedRows.Count > 0 && dataGridViewAttendees.SelectedRows.Count < 2)
            {
                var selectedRow = dataGridViewAttendees.SelectedRows[0];
                dataGridViewAttendees.Rows.Remove(selectedRow);
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
                if (dataGridViewAttendees.SelectedRows.Count == numAttendees)
                {                   
                    int totalTickets = dataGridViewAttendees.Rows.Count;
                    decimal totalAmount = decimal.Parse(label6.Text.Replace("Total price: ", "").Replace("₺", "").Trim());
                    int _userId = 0;
                    int newTicketId = 1, newEventOrderId = 1;
                    
                    // --- generate new ticket id for saving to database
                    string maxTicketIdQuery = "SELECT MAX(ticket_id) FROM event_ticket_booking";
                    DataTable result1 = _dbConnect.ExecuteQuery(maxTicketIdQuery);
                    if (result1.Rows.Count > 0 && result1.Rows[0][0] != DBNull.Value)
                    {
                        newTicketId = Convert.ToInt32(result1.Rows[0][0]) + 1; 
                    }
                    // --- generate new event order id for saving to database
                    string maxEventOrderIdQuery = "SELECT MAX(event_order_id) FROM event_orders";
                    DataTable result2 = _dbConnect.ExecuteQuery(maxTicketIdQuery);
                    if (result2.Rows.Count > 0 && result2.Rows[0][0] != DBNull.Value)
                    {
                        newEventOrderId = Convert.ToInt32(result2.Rows[0][0]) + 1;
                    }
                    // --- Get user Id

                    // ~~ Add order to the database
                    // all orders considered paid at the moment
                    string query = $"INSERT INTO [event_orders] (event_order_id, user_id, event_id, order_date, total_tickets, total_amount, booking_status) " +
                        $"VALUES ('{newEventOrderId}', '{_userId}','{_eventId}', '{DateTime.Now.Date}', {totalTickets}, {totalAmount}, 'paid')";
                    _dbConnect.ExecuteQuery(query);
                    
                    // Add ticket bookings
                    foreach (DataGridViewRow row in dataGridViewAttendees.Rows)
                    {
                        string attendeeName = row.Cells["AttendeeName"].Value.ToString();
                        string attendeeType = row.Cells["AttendeeType"].Value.ToString();
                        decimal ticketPrice = Convert.ToDecimal(row.Cells["TicketPrice"].Value);

                        string ticketQuery = $"INSERT INTO [event_ticket_booking] (ticket_id, event_order_id, attendee_name, attendee_type, ticket_price) " +
                            $"VALUES (SCOPE_IDENTITY(),'{newTicketId}', '{attendeeName}', '{attendeeType}', {ticketPrice})";
                        _dbConnect.ExecuteQuery(ticketQuery);
                    }
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

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
