using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Together_Culture__Dream_Team_.Front_End.User_Controls
{
    public partial class LoginAlertWindow : UserControl
    {

        private static LoginAlertWindow _instance;
        public static LoginAlertWindow Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LoginAlertWindow();
                return _instance;

            }
        }
        public LoginAlertWindow()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }
    }
}
