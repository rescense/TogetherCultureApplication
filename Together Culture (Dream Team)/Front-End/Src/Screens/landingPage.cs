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
    public partial class landingPage : Form
    {
        public landingPage()
        {
            InitializeComponent();
        }

        usrCntrl_AboutUs usrCntrl_AboutUs = new usrCntrl_AboutUs();
        usrCntrl_Memberships usrCntrl_Memberships = new usrCntrl_Memberships();

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            usrCntrl_AboutUs usrCntrl_AboutUs = new usrCntrl_AboutUs();
            addUserControl(usrCntrl_AboutUs);
        }
        private void guna2ButtonMembership_Click(object sender, EventArgs e)
        {
            addUserControl(usrCntrl_Memberships);
        }

        private void addUserControl(UserControl userControl)
        {
            guna2CustomGradientPanel4.Controls.Clear();
            guna2CustomGradientPanel4.Controls.Add(userControl);
            userControl.BringToFront();
        }



        private void landingPage_Load(object sender, EventArgs e)
        {

        }

        private void usrCntrl_AboutUs1_Load(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
