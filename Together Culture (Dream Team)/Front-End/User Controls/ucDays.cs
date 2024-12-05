using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Together_Culture__Dream_Team_.Front_End.Src.Screens
{
    public partial class ucDays : UserControl
    {
        string dayVar, dateVar, weekDaysVar;
        public ucDays(string day)
        {
            InitializeComponent();
            dayVar = day;
            label1.Text = day;
            checkBox1.Hide();
        }

        private void ucDays_Load(object sender, EventArgs e)
        {

        }

        private void panel_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                checkBox1.Checked = true;
                this.BackColor = Color.Yellow;
            }
            else
            {
                checkBox1.Checked = false;
                this.BackColor = Color.White;
            }



        }
    }
}
