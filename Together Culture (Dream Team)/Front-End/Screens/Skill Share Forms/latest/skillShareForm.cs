using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Together_Culture__Dream_Team_.Front_End.Screens.Events_Forms;
using Together_Culture__Dream_Team_.Front_End.Screens.Skill_Share_Forms.latest.user_controls;
using Together_Culture__Dream_Team_.Front_End.Src.Screens;
using static Guna.UI2.WinForms.Suite.Descriptions;

namespace Together_Culture__Dream_Team_.Front_End.Screens.Skill_Share_Forms.latest
{
    public partial class skillShareForm : Form
    {
        public skillShareForm()
        {
            InitializeComponent();
            LoadInitialUserControls();
        }

        // Load the initial state with Search and Post user control in Panel1 and Time Bank in Panel2
        private void LoadInitialUserControls()
        {
            var searchAndPostUC = new SearchAndPostUserControl();
            searchAndPostUC.Dock = DockStyle.Fill;


            panel1.Controls.Clear();
            panel1.Controls.Add(searchAndPostUC);

            var timeBankUC = new TimeBankUserControl();
            timeBankUC.Dock = DockStyle.Fill;

            panel2.Controls.Clear();
            panel2.Controls.Add(timeBankUC);

            searchAndPostUC.SearchEventClicked += SearchAndPostUC_SearchClicked; // Hook up the event for search
        }

        // Event handler for when the search button is clicked
        private void SearchAndPostUC_SearchClicked(object sender, EventArgs e)
        {
            // When search is clicked, load the search results in both panels
            LoadSearchResultUserControls();
        }

        // Load search result user controls in Panel1 and Panel2
        private void LoadSearchResultUserControls()
        {
            var searchResultsUC = new SearchResultsUserControl();
            searchResultsUC.Dock = DockStyle.Fill;
            searchResultsUC.ResultSelected += SearchResultsUC_ResultSelected;  // Hook up event for result selection

            panel1.Controls.Clear();
            panel1.Controls.Add(searchResultsUC);

            var selectedDetailsUC = new SelectedDetailsUserControl();
            selectedDetailsUC.Dock = DockStyle.Fill;

            panel2.Controls.Clear();
            panel2.Controls.Add(selectedDetailsUC);
        }

        // Event handler for when a result is selected in SearchResultsUserControl
        private void SearchResultsUC_ResultSelected(object sender, skillShareForm.EventDetails eventDetails)
        {
            // Load selected event details into the details user control
            var selectedDetailsUC = new SelectedDetailsUserControl(eventDetails);
            selectedDetailsUC.Dock = DockStyle.Fill;

            panel2.Controls.Clear();
            panel2.Controls.Add(selectedDetailsUC);
        }

        // Event details class to store event data
        public class EventDetails
        {
            public string ServiceTitle { get; set; }
            public string Category { get; set; }
            public string Description { get; set; }
            public string ContactPreference { get; set; }
            public string MemberName { get; set; }
            public int TimeRequired { get; set; }
        }

        // buttons on header panel
        private void chatSpace_Click(object sender, EventArgs e)
        {
            MessageBox.Show("  Coming Soon....  ");
        }

        private void eventsBtn_Click(object sender, EventArgs e)
        {
            eventsForm ef = new eventsForm();
            ef.Show();
            this.Close();
        }

        private void timeBankBtn_Click(object sender, EventArgs e)
        {
            skillShareForm ssk = new skillShareForm();
            ssk.Show();
            this.Close();
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            Profile pf = new Profile();
            pf.Show();
            this.Close();
        }
    }

}



