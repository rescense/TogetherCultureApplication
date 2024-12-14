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
using Together_Culture__Dream_Team_.Front_End.Src.Screens;

namespace Together_Culture__Dream_Team_.Front_End.Screens.Events_Forms
{
    public partial class eventsForm : Form
    {
        public eventsForm()
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
    }
}
