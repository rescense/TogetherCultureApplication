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
        public event EventHandler<string> DateSelected;
        public event EventHandler<string> DateDeselected;
        string dayVar, dateVar, weekDaysVar;
        public bool IsSelected { get; private set; } = false;
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
            if (!string.IsNullOrEmpty(dayVar))
            {
                if (!IsSelected)
                {
                    IsSelected = true;
                    this.BackColor = Color.Yellow;
                    DateSelected?.Invoke(this, dayVar);
                }
                else
                {
                    IsSelected = false;
                    this.BackColor = Color.White;
                    DateDeselected?.Invoke(this, dayVar);
                }
            }



        }

        public void Deselect() 
        {
            IsSelected = false;
            this.BackColor = Color.White;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
