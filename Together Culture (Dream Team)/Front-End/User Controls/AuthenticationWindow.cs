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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!guna2CustomGradientPanel1.Controls.Contains(EmailCodeWindow.Instance))
            {
                guna2CustomGradientPanel1.Controls.Add(EmailCodeWindow.Instance);

                EmailCodeWindow.Instance.BringToFront();
            }
            else
                EmailCodeWindow.Instance.BringToFront();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (!guna2CustomGradientPanel1.Controls.Contains(PhoneCodeWindow.Instance))
            {
                guna2CustomGradientPanel1.Controls.Add(PhoneCodeWindow.Instance);

                PhoneCodeWindow.Instance.BringToFront();
            }
            else
                PhoneCodeWindow.Instance.BringToFront();
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
