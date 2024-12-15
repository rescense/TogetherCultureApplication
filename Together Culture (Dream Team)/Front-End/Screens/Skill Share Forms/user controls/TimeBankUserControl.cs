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

namespace Together_Culture__Dream_Team_.Front_End.Screens.Skill_Share_Forms.latest.user_controls
{
    public partial class TimeBankUserControl : UserControl
    {
        public TimeBankUserControl(int userId)
        {
            InitializeComponent();
            var _user_id = userId;
            InitializeTimeBankInfo(_user_id);
        }

        private void InitializeTimeBankInfo(int _user_id)
        {
            try 
            {
                using (var dbConnect = new DatabaseConnect()) 
                {
                    dbConnect.Open();
                    string query = $@"
                    SELECT time_offered, time_requested, time_balance
                    FROM time_bank
                    WHERE user_id = {_user_id}";

                    DataTable result = dbConnect.ExecuteQuery(query);

                    if (result.Rows.Count > 0)
                    {
                        DataRow row = result.Rows[0];

                        var time_offered = row["time_offered"].ToString();
                        var time_requested = row["time_requested"].ToString();
                        var time_balance = row["time_balance"].ToString();

                        label5.Text = $"{time_offered}";
                        label6.Text = $"{time_requested}";
                        label8.Text = $"You have {time_balance} hours left in your\r\nTime Bank.";  
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading details: {ex.Message}");
            }
        }
        private void guna2CustomGradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}