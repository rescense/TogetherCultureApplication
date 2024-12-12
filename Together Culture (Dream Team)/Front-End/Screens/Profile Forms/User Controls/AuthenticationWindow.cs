using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Together_Culture__Dream_Team_.Front_End.Src.User_Controls;

namespace Together_Culture__Dream_Team_.Front_End.User_Controls
{
    public partial class AuthenticationWindow : UserControl
    {
        private static AuthenticationWindow _instance;
        public static AuthenticationWindow Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AuthenticationWindow();
                return _instance;

            }
        }
        public AuthenticationWindow()
        {
            InitializeComponent();
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            guna2CustomGradientPanel1.Controls.Clear();
            guna2CustomGradientPanel1.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserControlSecurity.panel.Hide();

        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            EmailCodeWindow emailCodeWindow = new EmailCodeWindow();
            addUserControl(emailCodeWindow);
        }

        private void btnPhoneNo_Click(object sender, EventArgs e)
        {
            PhoneCodeWindow phoneCodeWindow = new PhoneCodeWindow();
            addUserControl(phoneCodeWindow);
        }
    }
}
