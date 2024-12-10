using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Together_Culture__Dream_Team_.Front_End.Screens.Profile_Forms;
using Together_Culture__Dream_Team_.Front_End.User_Controls;

namespace Together_Culture__Dream_Team_.Front_End.Src.User_Controls
{
    public partial class UserControlChPassword : UserControl
    {
        private static UserControlChPassword _instance;
        public static UserControlChPassword Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserControlChPassword();
                return _instance;

            }
        }
        public UserControlChPassword()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!guna2CustomGradientPanel2.Controls.Contains(ForgotPasswordWindow.Instance))
            {
                guna2CustomGradientPanel2.Controls.Add(ForgotPasswordWindow.Instance);
              
                ForgotPasswordWindow.Instance.BringToFront();
            }
            else
                ForgotPasswordWindow.Instance.BringToFront();

        }
    }
}
