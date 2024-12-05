using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Together_Culture__Dream_Team_.Front_End.Src.Screens;

namespace Together_Culture__Dream_Team_.Front_End.Src.User_Controls
{
    public partial class SideMenuBar : UserControl
    {
        public SideMenuBar()
        {
            InitializeComponent();
        }

        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.Show();

        }
    }
}
