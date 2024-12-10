using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Together_Culture__Dream_Team_.Front_End.User_Controls;

namespace Together_Culture__Dream_Team_.Front_End.Src.User_Controls
{
    public partial class UserControlSecurity : UserControl
    {
        private static UserControlSecurity _instance;
        public static UserControlSecurity Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserControlSecurity();
                return _instance;

            }
        }
        public UserControlSecurity()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (!guna2CustomGradientPanel1.Controls.Contains(LoginAlertWindow.Instance))
            {
                guna2CustomGradientPanel1.Controls.Add(LoginAlertWindow.Instance);

                LoginAlertWindow.Instance.BringToFront();
            }
            else
                LoginAlertWindow.Instance.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!guna2CustomGradientPanel1.Controls.Contains(RecentEmailsWindow.Instance))
            {
                guna2CustomGradientPanel1.Controls.Add(RecentEmailsWindow.Instance);

                RecentEmailsWindow.Instance.BringToFront();
            }
            else
                RecentEmailsWindow.Instance.BringToFront();
        }
    }
}
