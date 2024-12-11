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
        public event EventHandler<skillShareForm.EventDetails> ResultSelected;

        public SearchResultsUserControl()
        {
            InitializeComponent();
            LoadResult();
        }

        private void LoadResult()
        {
            // Populate the DataGridView with sample results
            DataGridViewTextBoxColumn ServiceColumn = new DataGridViewTextBoxColumn();
            ServiceColumn.Name = "ServiceColumn";
            ServiceColumn.HeaderText = "Service";
            ServiceColumn.Width = 400;

            DataGridViewTextBoxColumn timeColumn = new DataGridViewTextBoxColumn();
            timeColumn.Name = "timeColumn";
            timeColumn.HeaderText = "Time";
            timeColumn.Width = 160;

            DataGridViewTextBoxColumn categoryColumn = new DataGridViewTextBoxColumn();
            categoryColumn.Name = "categoryColumn";
            categoryColumn.HeaderText = "Category";
            categoryColumn.Width = 170;

            dataGridView1.Columns.Add(ServiceColumn);
            dataGridView1.Columns.Add(timeColumn);
            dataGridView1.Columns.Add(categoryColumn);

            // Add sample rows
            dataGridView1.Rows.Add("Plumbing Help", "3 hours", "Request");
            dataGridView1.Rows.Add("Gardening Tips", "1 hour", "Offering");

            // When selection is changed, raise the ResultSelected event
            dataGridView1.SelectionChanged += (s, e) =>
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var selectedRow = dataGridView1.SelectedRows[0];

                    var eventDetails = new skillShareForm.EventDetails
                    {
                        ServiceTitle = selectedRow.Cells[0].Value.ToString(),
                        TimeRequired = int.Parse(selectedRow.Cells[1].Value.ToString().Split(' ')[0]),  // Remove "hours" and parse integer
                        Category = selectedRow.Cells[2].Value.ToString()
                    };
                    ResultSelected?.Invoke(this, eventDetails);  // Trigger the ResultSelected event
                } 
            };
        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
