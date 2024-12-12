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
    public partial class EmailCodeWindow : UserControl
    {
        private static EmailCodeWindow _instance;
        public static EmailCodeWindow Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EmailCodeWindow();
                return _instance;

            }
        }
        public EmailCodeWindow()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
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
