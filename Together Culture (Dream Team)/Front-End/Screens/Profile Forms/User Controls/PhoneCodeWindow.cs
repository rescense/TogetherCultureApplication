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
    public partial class PhoneCodeWindow : UserControl
    {
        private static PhoneCodeWindow _instance;
        public static PhoneCodeWindow Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PhoneCodeWindow();
                return _instance;

            }
        }
        public PhoneCodeWindow()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserControlSecurity.panel.Hide();
        }
    }
}
