using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Together_Culture__Dream_Team_.Front_End.Screens.Skill_Share_Forms.latest;
using Together_Culture__Dream_Team_.Front_End.Src.Screens;

namespace Together_Culture__Dream_Team_.Front_End.Screens.Events_Forms
{
    public partial class eventsMain : Form
    {
        public eventsMain()
        {
            InitializeComponent();
        }
        private void eventsForm_Load(object sender, EventArgs e)
        {

        }

        // user controls
        // load main page
        private void LoadEventMainUserControl()
        {
            var eventsMainUC = new eventsMain_UC();
            eventsMainUC.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(eventsMainUC);

        }

        // tools

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }

        private void userControlPanel(object sender, PaintEventArgs e) // design name - panel1
        {

        }

        // header panel buttons
        private void chatSpaceBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("  Coming Soon....  ");
        }

        private void timeBankBtn_Click(object sender, EventArgs e)
        {
            skillShareMain ssk = new skillShareMain();
            ssk.Show();

            this.Hide();
            this.Dispose();
        }

        private void eventsBtn_Click(object sender, EventArgs e)
        {
            eventsMain ef = new eventsMain();
            ef.Show();
            
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
