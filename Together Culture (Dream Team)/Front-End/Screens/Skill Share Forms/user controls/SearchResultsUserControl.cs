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

namespace Together_Culture__Dream_Team_.Front_End.Screens.Skill_Share_Forms.latest.user_controls
{
    public partial class SearchResultsUserControl : UserControl
    {
        //public event EventHandler<skillShareForm.EventDetails> ResultSelected;
        private readonly DataTable _searchResults;
        private readonly DatabaseConnect _dbConnect;

        public SearchResultsUserControl(DataTable searchResults)
        {
            InitializeComponent();
            _searchResults = searchResults;
            BindData();
        }
        private void BindData()
        {
            dataGridView1.DataSource = _searchResults;
        }
        private void DgvResults_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select exactly one result.");
                return;
            }

            DataRowView selectedRow = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;

            if (selectedRow != null)
            {
                int skillShareId = Convert.ToInt32(selectedRow["skill_share_id"]);
                SelectedDetailsUserControl selectedDetailsUC = new SelectedDetailsUserControl(skillShareId);

                skillShareMain parentForm = this.Parent as skillShareMain;
                parentForm?.SwitchUserControls(this, selectedDetailsUC);
            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
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
        // tools
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
