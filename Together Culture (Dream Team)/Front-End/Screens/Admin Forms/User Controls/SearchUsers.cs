using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Together_Culture__Dream_Team_.Back_End.Src.Main;

namespace Together_Culture__Dream_Team_.Front_End.Src.User_Controls
{
    public partial class SearchUsers : UserControl
    {
        public SearchUsers()
        {
            InitializeComponent();
            LoadDataIntoDataGridView();
        }


        private void searchUsersTxtBx_MouseClic(object sender, MouseEventArgs e)
        {
            // Only clear the placeholder text if it's the default
            if (searchUsersTxtBx.Text == "Search users...")
            {
                searchUsersTxtBx.Text = "";
                searchUsersTxtBx.ForeColor = System.Drawing.Color.Black; // Change text color to black when editing
            }
        }

        private void searchUsersTxtBx_Leave(object sender, EventArgs e)
        {
            // Restore the placeholder text if the user has left it empty
            if (string.IsNullOrEmpty(searchUsersTxtBx.Text))
            {
                searchUsersTxtBx.Text = "Search users....";
                searchUsersTxtBx.ForeColor = System.Drawing.Color.Gray; // Change color back to gray
            }
        }

        private void selectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (selectAllCheckBox.Focused) // Ensure triggered by user action
            {
                // Get the state of the "Select All" checkbox
                bool selectAll = selectAllCheckBox.Checked;

                // Loop through all child controls recursively
                foreach (CheckBox checkBox in GetAllCheckBoxes(panel1))
                {
                    if (checkBox != selectAllCheckBox)
                    {
                        checkBox.CheckedChanged -= otherCheckBox_CheckedChanged; // Detach event
                        checkBox.Checked = selectAll; // Set state
                        checkBox.CheckedChanged += otherCheckBox_CheckedChanged; // Reattach event
                    }
                }

                UpdateSelectAllText();
            }
        }

        private void otherCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Determine if all or none are checked
            bool allChecked = true;
            bool noneChecked = true;

            foreach (CheckBox checkBox in GetAllCheckBoxes(panel1))
            {
                if (checkBox != selectAllCheckBox)
                {
                    if (checkBox.Checked)
                        noneChecked = false;
                    else
                        allChecked = false;
                }
            }

            // Update "Select All" checkbox state
            selectAllCheckBox.CheckedChanged -= selectAllCheckBox_CheckedChanged; // Detach event
            selectAllCheckBox.Checked = allChecked; // Update state
            selectAllCheckBox.CheckedChanged += selectAllCheckBox_CheckedChanged; // Reattach event

            UpdateSelectAllText();
        }

        private void UpdateSelectAllText()
        {
            // Check if none are checked
            bool noneChecked = true;

            foreach (CheckBox checkBox in GetAllCheckBoxes(panel1))
            {
                if (checkBox != selectAllCheckBox && checkBox.Checked)
                {
                    noneChecked = false;
                    break;
                }
            }

            selectAllCheckBox.Text = noneChecked ? "Select All" : "Deselect All";
        }

        // Helper function to get all checkboxes recursively
        private IEnumerable<CheckBox> GetAllCheckBoxes(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is CheckBox checkBox)
                    yield return checkBox;
                else if (control.HasChildren)
                {
                    foreach (var childCheckBox in GetAllCheckBoxes(control))
                        yield return childCheckBox;
                }
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadDataIntoDataGridView()
        {
            try
            {
                using (DatabaseConnect database = new DatabaseConnect())
                {
                    database.Open();

                    // Query to fetch all user data
                    string query = "SELECT user_id, username, first_name, last_name, email, phone_number, date_of_birth, date_joined FROM [user]";

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, database.Connection);

                    // Fill the DataTable with the retrieved data
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = dataTable;

                    // Adjust header height
                    dataGridView1.ColumnHeadersHeight = 40; // Set to a suitable value

                    // Optionally, customize DataGridView columns
                    dataGridView1.Columns["user_id"].HeaderText = "ID";
                    dataGridView1.Columns["username"].HeaderText = "Username";
                    dataGridView1.Columns["first_name"].HeaderText = "First Name";
                    dataGridView1.Columns["last_name"].HeaderText = "Last Name";
                    dataGridView1.Columns["email"].HeaderText = "Email";
                    dataGridView1.Columns["phone_number"].HeaderText = "Phone Number";
                    dataGridView1.Columns["date_of_birth"].HeaderText = "Date of Birth";
                    dataGridView1.Columns["date_joined"].HeaderText = "Date Joined";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
