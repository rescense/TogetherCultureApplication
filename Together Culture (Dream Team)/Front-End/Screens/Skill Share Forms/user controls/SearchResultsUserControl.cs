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
        //public event EventHandler<skillShareForm.EventDetails> ResultSelected;
        private readonly DataTable _searchResults;

        public SearchResultsUserControl(DataTable searchResults)
        {
            InitializeComponent();
            _searchResults = searchResults;
            BindData();
            //LoadResult();
        }
        // new
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
