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

        private DataTable userDataTable;

        public SearchUsers()
        {
            InitializeComponent();
            LoadDataIntoDataGridView();
            AddCheckBoxColumn();
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
            // Ensure DataGridView contains rows
            if (dataGridView1.Rows.Count > 0)
            {
                bool selectAll = selectAllCheckBox.Checked;

                // Iterate through rows and set checkbox state
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell checkBoxCell = row.Cells["Select"] as DataGridViewCheckBoxCell;
                    if (checkBoxCell != null)
                    {
                        checkBoxCell.Value = selectAll; // Check or Uncheck based on Select All state
                    }
                }
            }
        }

        private void AddCheckBoxColumn()
        {
            // Add a checkbox column if not already present
            if (!dataGridView1.Columns.Contains("Select"))
            {
                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "Select",
                    Name = "Select",
                    Width = 50
                };
                dataGridView1.Columns.Insert(0, checkBoxColumn);
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
            // Ensure the clicked column is the checkbox column
            if (e.ColumnIndex == dataGridView1.Columns["Select"].Index)
            {
                // Check if all rows are selected or not
                bool allChecked = true;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Select"].Value == null || !(bool)row.Cells["Select"].Value)
                    {
                        allChecked = false;
                        break;
                    }
                }

                // Update the "Select All" checkbox state
                selectAllCheckBox.CheckedChanged -= selectAllCheckBox_CheckedChanged; // Temporarily unsubscribe
                selectAllCheckBox.Checked = allChecked;
                selectAllCheckBox.CheckedChanged += selectAllCheckBox_CheckedChanged; // Re-subscribe
            }
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
                    userDataTable = new DataTable();
                    dataAdapter.Fill(userDataTable);

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = userDataTable;

                    // Set column headers
                    dataGridView1.Columns["user_id"].HeaderText = "ID";
                    dataGridView1.Columns["username"].HeaderText = "Username";
                    dataGridView1.Columns["first_name"].HeaderText = "First Name";
                    dataGridView1.Columns["last_name"].HeaderText = "Last Name";
                    dataGridView1.Columns["email"].HeaderText = "Email";
                    dataGridView1.Columns["phone_number"].HeaderText = "Phone Number";
                    dataGridView1.Columns["date_of_birth"].HeaderText = "Date of Birth";
                    dataGridView1.Columns["date_joined"].HeaderText = "Date Joined";

                    // Set default header height
                    dataGridView1.ColumnHeadersHeight = 40;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchUsersTxtBx_TextChanged(object sender, EventArgs e)
        {
            if (userDataTable != null)
            {
                string searchValue = searchUsersTxtBx.Text.Trim();

                // Use DataView to filter the DataTable
                DataView dv = userDataTable.DefaultView;

                // Filter rows where any relevant column contains the search value
                dv.RowFilter = $"username LIKE '%{searchValue}%' OR " +
                               $"first_name LIKE '%{searchValue}%' OR " +
                               $"last_name LIKE '%{searchValue}%' OR " +
                               $"email LIKE '%{searchValue}%' OR " +
                               $"phone_number LIKE '%{searchValue}%'";

                // Update DataGridView with the filtered view
                dataGridView1.DataSource = dv;
            }
        }
    }
}
