﻿using Guna.UI2.WinForms.Internal;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Together_Culture__Dream_Team_.Front_End.Screens.Skill_Share_Forms.latest.user_controls
{
    public partial class SearchAndPostUserControl : UserControl
    {
        private readonly DatabaseConnect _dbConnect;

        public SearchAndPostUserControl()
        {
            InitializeComponent();
            _dbConnect = new DatabaseConnect();
        }

        private void PostButton_Click(object sender, EventArgs e)
        {
            try
            {
                string serviceTitle = textBox2.Text.Trim();
                string description = textBox3.Text.Trim();
                string contact = textBox5.Text.Trim();
                string offeringOrRequesting = comboBox2.SelectedItem?.ToString();
                TimeSpan timeRequired;

                if (string.IsNullOrEmpty(serviceTitle) || string.IsNullOrEmpty(description) ||
                    string.IsNullOrEmpty(contact) || string.IsNullOrEmpty(offeringOrRequesting) ||
                    !TimeSpan.TryParse(textBox4.Text, out timeRequired))
                {
                    MessageBox.Show("Please fill all the fields correctly.");
                    return;
                }

                string query = $@"
                INSERT INTO skill_share (user_id, service_title, offering_or_requesting, description, time_required, contact)
                VALUES (1, '{serviceTitle}', '{offeringOrRequesting}', '{description}', '{timeRequired}', '{contact}')";

                _dbConnect.Open();
                _dbConnect.ExecuteQuery(query);
                MessageBox.Show("Skill posted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error posting skill: {ex.Message}");
            }
            finally
            {
                _dbConnect.Close();
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();
            string filter = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(filter))
            {
                MessageBox.Show("Please select a filter to search.");
                return;
            }

            string query = $@"
            SELECT skill_share_id, service_title, time_required
            FROM skill_share
            WHERE offering_or_requesting = '{filter}' 
            AND service_title LIKE '%{searchText}%'";

            try
            {
                _dbConnect.Open();
                DataTable results = _dbConnect.ExecuteQuery(query);

                if (results.Rows.Count == 0)
                {
                    MessageBox.Show("No results found.");
                    return;
                }
                else
                {
                    DataRow row = results.Rows[0];
                    int skillShareId = Convert.ToInt32(row["skill_share_id"]);

                    SearchResultsUserControl searchResultUC = new SearchResultsUserControl(results);
                    SelectedDetailsUserControl selectedDetailsUC = new SelectedDetailsUserControl(skillShareId);

                    // Switch UserControls on SkillShareForm
                    skillShareMain parentForm = this.Parent as skillShareMain;
                    parentForm?.SwitchUserControls(searchResultUC, selectedDetailsUC);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error performing search: {ex.Message}");
            }
            finally
            {
                _dbConnect.Close();
            }
        }
        // functions

        // Tools
        private void PostService()
        {
            // Gather the values entered by the user in the form
            string title = textBox2.Text;
            string category = comboBox2.SelectedItem.ToString();
            string description = textBox3.Text;
            string time = textBox4.Text;
            string contact = textBox5.Text;

            // Code to save service/skill in the database (you would add actual database code here)
            MessageBox.Show("Service posted successfully!");
        }

        // tools

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // search box
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // combo box for filtering search
        }
        private void guna2Button8_Click(object sender, EventArgs e)
        {
            // search button
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //service title 
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // offering or requesting combo box
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // offering or request
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // time required
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            // contact preference
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            // post button
        }

        private void search_Click(object sender, EventArgs e)
        {

        }
    }
}
