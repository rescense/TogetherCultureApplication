using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Together_Culture__Dream_Team_.Back_End.Src.Main;
using Together_Culture__Dream_Team_.Front_End.Screens.Profile_Forms;
using Together_Culture__Dream_Team_.Front_End.Src.Screens;

namespace Together_Culture__Dream_Team_.Front_End.Screens
{
    public partial class MemberAreaOnly : Form
    {
        public MemberAreaOnly()
        {
            InitializeComponent();
        }
        private void MemberAreaOnly_Load(object sender, EventArgs e)
        {
            // Fetch the upcoming events
            DataTable upcomingEvents = GetUpcomingEvents();

            // Bind the data to the DataGridView
            if (upcomingEvents.Rows.Count > 0)
            {
                DataGridView.DataSource = upcomingEvents;

                // Set default header height
                DataGridView.ColumnHeadersHeight = 30;

                // Optionally customize column headers
                DataGridView.Columns["event_name"].HeaderText = "Event Name";
                DataGridView.Columns["date"].HeaderText = "Date";
                DataGridView.Columns["time"].HeaderText = "Time";
            }
            else
            {
                MessageBox.Show("No upcoming events found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private DataTable GetUpcomingEvents()
        {
            DataTable eventsTable = new DataTable();

            try
            {
                string query = "SELECT event_name, date, time FROM [event] WHERE date >= @CurrentDate ORDER BY date, time";

                using (var db = new DatabaseConnect())
                {
                    db.Open();

                    using (var command = new SqlCommand(query, db.Connection))
                    {
                        command.Parameters.AddWithValue("@CurrentDate", DateTime.Now);

                        using (var adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(eventsTable);
                        }
                    }

                    db.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching events: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return eventsTable;
        }

        private void btnProfileSettings_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Close();
        }
    }
}
