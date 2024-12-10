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
    public partial class ForgotPasswordWindow : UserControl
    {
        private static ForgotPasswordWindow _instance;
        public static ForgotPasswordWindow Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ForgotPasswordWindow();
                return _instance;

            }
        }
        public ForgotPasswordWindow()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
