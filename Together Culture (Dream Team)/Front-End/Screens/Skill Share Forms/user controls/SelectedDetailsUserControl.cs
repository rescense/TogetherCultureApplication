using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Together_Culture__Dream_Team_.Back_End.Src.Main;
using Together_Culture__Dream_Team_.Front_End.User_Controls;

namespace Together_Culture__Dream_Team_.Front_End.Screens.Skill_Share_Forms.latest.user_controls
{
    public partial class SelectedDetailsUserControl : UserControl
    {
        private readonly int _skillShareId;
        private readonly int _userId;
        public SelectedDetailsUserControl(int skillShareId)
        {
            InitializeComponent();
            _skillShareId = skillShareId;
            LoadDetails();
        }
        private void LoadDetails()
        {
            try
            {
                using (var dbConnect = new DatabaseConnect())
                {
                    dbConnect.Open();
                    string query = $@"
                    SELECT service_title, offering_or_requesting, description, time_required, contact
                    FROM skill_share
                    WHERE skill_share_id = {_skillShareId}";

                    DataTable result = dbConnect.ExecuteQuery(query);

                    if (result.Rows.Count > 0)
                    {
                        DataRow row = result.Rows[0];

                        var ServiceTitle = row["service_title"].ToString();
                        var Category = row["offering_or_requesting"].ToString();
                        var TimeRequired = row["time_required"].ToString();
                        var description = row["description"].ToString();
                        var contact = row["contact"].ToString();
                        var _userId = row["user_id"].ToString();

                        // get member name
                        string query2 = $@"SELECT first_name FROM user WHERE user_id = {_userId}";

                        DataTable result2 = dbConnect.ExecuteQuery(query2);
                        if (result2.Rows.Count == 1) 
                        {
                            DataRow row2 = result2.Rows[0];
                            var memberName = row2["first_name"].ToString();
                            label3.Text = $"{memberName}\n\nAssistance Type\n\n{Category}\n\n{TimeRequired}\n\n{description}\n\n\n{contact}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading details: {ex.Message}");
            }
        }

        private void guna2CustomGradientPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
