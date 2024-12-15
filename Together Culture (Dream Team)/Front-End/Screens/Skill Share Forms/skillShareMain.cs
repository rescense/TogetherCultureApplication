using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using Together_Culture__Dream_Team_.Back_End.Src.Main;
using Together_Culture__Dream_Team_.Front_End.Screens.Events_Forms;
using Together_Culture__Dream_Team_.Front_End.Screens.Skill_Share_Forms.latest.user_controls;
using Together_Culture__Dream_Team_.Front_End.Src.Screens;
using static Guna.UI2.WinForms.Suite.Descriptions;

namespace Together_Culture__Dream_Team_.Front_End.Screens.Skill_Share_Forms.latest
{
    public partial class skillShareMain : Form
    {
        private readonly DatabaseConnect _dbConnect;
        private readonly int userid;

        public skillShareMain(int user_id)
        {
            InitializeComponent();
            _dbConnect = new DatabaseConnect();
            userid = user_id;
            LoadInitialUserControls();
        }

        private void LoadInitialUserControls()
        {
            // Load initial User Controls
            SearchAndPostUserControl searchAndPostUC = new SearchAndPostUserControl();
            TimeBankUserControl timeBankUC = new TimeBankUserControl(userid);

            // Add controls to panels
            panel1.Controls.Clear();
            panel1.Controls.Add(searchAndPostUC);

            panel2.Controls.Clear();
            panel2.Controls.Add(timeBankUC);
        }

        public void SwitchUserControls(UserControl panel1UC, UserControl panel2UC)
        {
            // Switch user controls in the respective panels
            panel1.Controls.Clear();
            panel1.Controls.Add(panel1UC);

            panel2.Controls.Clear();
            panel2.Controls.Add(panel2UC);
        }

        private void SkillShareForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _dbConnect?.Dispose(); // Ensure database connection is closed on form close
        }

        // buttons on header panel
        private void chatSpace_Click(object sender, EventArgs e)
        {
            MessageBox.Show("  Coming Soon....  ");
        }

        private void eventsBtn_Click(object sender, EventArgs e)
        {
            eventsMain ef = new eventsMain(userid);
            ef.Show();
            this.Hide();
            this.Dispose();
        }

        private void timeBankBtn_Click(object sender, EventArgs e)
        {
            skillShareMain ssk = new skillShareMain(userid);
            ssk.Show();

            this.Hide();
            this.Dispose();
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            Profile pf = new Profile();
            pf.Show();
            
            this.Hide();
            this.Dispose();
        }
    }

}



