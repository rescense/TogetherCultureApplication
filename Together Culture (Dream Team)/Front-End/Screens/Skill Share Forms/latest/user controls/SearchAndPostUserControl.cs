using Guna.UI2.WinForms.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Together_Culture__Dream_Team_.Front_End.Screens.Skill_Share_Forms.latest.user_controls
{
    public partial class SearchAndPostUserControl : UserControl
    {
        public event EventHandler SearchEventClicked;

        public SearchAndPostUserControl()
        {
            InitializeComponent();
            guna2Button8.Click += (s, e) => SearchEventClicked?.Invoke(this, EventArgs.Empty);  // Raise event when search is clicked
        }

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
