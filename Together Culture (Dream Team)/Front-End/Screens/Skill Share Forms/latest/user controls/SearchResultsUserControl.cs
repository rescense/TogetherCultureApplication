using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Together_Culture__Dream_Team_.Front_End.Screens.Skill_Share_Forms.latest.user_controls
{
    public partial class SearchResultsUserControl : UserControl
    {
        //public event EventHandler<EventDetails> ResultSelected;

        public SearchResultsUserControl()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            //var searchBox = new RichTextBox { PlaceholderText = "Search..." };
            var categoryFilter = new ComboBox { Items = { "Skills Offered", "Skills Requested" } };
            var searchButton = new Button { Text = "Search" };
            var resultsGrid = new DataGridView
            {
                ColumnCount = 3,
                Columns =
                {
                    [0] = { Name = "Service Title" },
                    [1] = { Name = "Time Required" },
                    [2] = { Name = "Category" }
                }
            };

            searchButton.Click += (s, e) =>
            {
                // Example data population
                resultsGrid.Rows.Add("Plumbing Help", "3 hours", "Request");
                resultsGrid.Rows.Add("Gardening Tips", "1 hour", "Offering");
            };

            resultsGrid.SelectionChanged += (s, e) =>
            {
                if (resultsGrid.SelectedRows.Count > 0)
                {
                    var selectedRow = resultsGrid.SelectedRows[0];
                    /*
                    var eventDetails = new EventDetails
                    {
                        ServiceTitle = selectedRow.Cells[0].Value.ToString(),
                        TimeRequired = int.Parse(selectedRow.Cells[1].Value.ToString()),
                        Category = selectedRow.Cells[2].Value.ToString()
                    };
                    ResultSelected?.Invoke(this, eventDetails);*/
                }
            };

            var layout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, AutoSize = true };
            //layout.Controls.Add(searchBox);
            layout.Controls.Add(categoryFilter);
            layout.Controls.Add(searchButton);
            layout.Controls.Add(resultsGrid);

            Controls.Add(layout);
        }
        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
