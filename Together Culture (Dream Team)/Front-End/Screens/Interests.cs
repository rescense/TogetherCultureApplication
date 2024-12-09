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

namespace Together_Culture__Dream_Team_.Front_End.Src.Screens
{
    public partial class Interests : Form
    {
        // Declare a field to store the userId
        private int userId;
        private string firstName;
        private string lastName;
        private string userType;

        // Fields to track interest selection
        private bool isExperiencingSelected = false;
        private bool isCreatingSelected = false;
        private bool isSharingSelected = false;
        private bool isCaringSelected = false;
        private bool isWorkingSelected = false;

        // Keep track of selected interests
        private HashSet<string> selectedInterests = new HashSet<string>(); 

        // Modify the constructor to accept the parameters
        public Interests(int userId, string firstName, string lastName, string userType)
        {
            InitializeComponent();
            this.userId = userId; // Store the userId
            this.firstName = firstName; // Store the firstName
            this.lastName = lastName; // Store the lastName
            this.userType = userType; // Store the userType

            // Load existing interests when the form loads
            LoadUserInterests();
        }

        private void LoadUserInterests()
        {
            using (DatabaseConnect database = new DatabaseConnect())
            {
                try
                {
                    database.Open();
                    string query = "SELECT interest FROM interests WHERE user_id = @userId";
                    using (SqlCommand command = new SqlCommand(query, database.Connection))
                    {
                        command.Parameters.Add("@userId", SqlDbType.Int).Value = userId;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string interest = reader["interest"].ToString();
                                selectedInterests.Add(interest);

                                // Pre-select corresponding buttons based on existing interests
                                if (interest == "experiencing") isExperiencingSelected = true;
                                if (interest == "creating") isCreatingSelected = true;
                                if (interest == "sharing") isSharingSelected = true;
                                if (interest == "caring") isCaringSelected = true;
                                if (interest == "working") isWorkingSelected = true;
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error loading interests: {ex.Message}");
                }
                finally
                {
                    database.Close();
                }
            }

            // Update UI buttons based on the loaded interests
               UpdateButtonStates();

        }

        private void UpdateButtonStates()
        {
            // Update the button states to reflect the selected interests
            btnExperiencing.BackColor = isExperiencingSelected ? Color.LightBlue : Color.Transparent;
            btnCreating.BackColor = isCreatingSelected ? Color.LightBlue : Color.Transparent;
            btnSharing.BackColor = isSharingSelected ? Color.LightBlue : Color.Transparent;
            btnCaring.BackColor = isCaringSelected ? Color.LightBlue : Color.Transparent;
            btnWorking.BackColor = isWorkingSelected ? Color.LightBlue : Color.Transparent;
        }

        // a method to be used for every button to select or unselect
        private void ToggleInterest(string interest, ref bool isSelected)
        {
            isSelected = !isSelected;

            if (isSelected)
            {
                selectedInterests.Add(interest);
                MessageBox.Show($"{interest} selected!");
                AddInterest(interest);
                // Update UI buttons based on the loaded interests
                UpdateButtonStates();
            }
            else
            {
                selectedInterests.Remove(interest);
                MessageBox.Show($"{interest} unselected!");
                RemoveInterest(interest);
                // Update UI buttons based on the loaded interests
                UpdateButtonStates();
            }
        }

        // each button using the method 

        private void btnExperiencing_Click(object sender, EventArgs e)
        {
            ToggleInterest("experiencing", ref isExperiencingSelected);
        }

        private void btnCreating_Click(object sender, EventArgs e)
        {
            ToggleInterest("creating", ref isCreatingSelected);
        }

        private void btnSharing_Click(object sender, EventArgs e)
        {
            ToggleInterest("sharing", ref isSharingSelected);
        }

        private void btnCaring_Click(object sender, EventArgs e)
        {
            ToggleInterest("caring", ref isCaringSelected);
        }

        private void btnWorking_Click(object sender, EventArgs e)
        {
            ToggleInterest("working", ref isWorkingSelected);
        }

        // Method to add an interest to the database
        private void AddInterest(string interest)
        {
            using (DatabaseConnect database = new DatabaseConnect())
            {
                try
                {
                    database.Open();
                    string query = "INSERT INTO interests (user_id, interest) VALUES (@userId, @interest)";
                    using (SqlCommand command = new SqlCommand(query, database.Connection))
                    {
                        command.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
                        command.Parameters.Add("@interest", SqlDbType.NVarChar).Value = interest;

                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show($"{interest} added to your interests.");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error adding interest: {ex.Message}");
                }
                finally
                {
                    database.Close();
                }
            }
        }

        // Method to remove an interest from the database
        private void RemoveInterest(string interest)
        {
            using (DatabaseConnect database = new DatabaseConnect())
            {
                try
                {
                    database.Open();
                    string query = "DELETE FROM interests WHERE user_id = @userId AND interest = @interest";
                    using (SqlCommand command = new SqlCommand(query, database.Connection))
                    {
                        command.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
                        command.Parameters.Add("@interest", SqlDbType.NVarChar).Value = interest;

                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show($"{interest} removed from your interests.");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error removing interest: {ex.Message}");
                }
                finally
                {
                    database.Close();
                }
            }
        }

        
        private void btnProceed_Click_1(object sender, EventArgs e)
        {
            // Check if at least one interest is selected
            if (isExperiencingSelected || isCreatingSelected || isSharingSelected || isCaringSelected || isWorkingSelected)
            {
                // Redirect to the Profile page
                Profile profile = new Profile(userId, firstName, lastName, userType); // Ensure firstName, lastName, userType are accessible
                profile.Show();
                this.Hide();
            }
            else
            {
                // Notify the user to select at least one interest
                MessageBox.Show("Please select at least one interest before proceeding.", "Select Interest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
