using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Together_Culture__Dream_Team_.Front_End.Src.User_Controls;

namespace Together_Culture__Dream_Team_.Front_End.Screens.Profile_Forms
{
    public partial class Profilepage : Form
    {
        public Profilepage()
        {
            InitializeComponent();
        }

        private void btnBackToProfile_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            UserControlChPassword changePassword = new UserControlChPassword();
            addUserControl(changePassword);
        }

        private void personalInfo_Click(object sender, EventArgs e)
        {
            UserControlPI personalInfo = new UserControlPI();
            addUserControl(personalInfo);
        }

        private void btnSecurity_Click(object sender, EventArgs e)
        {
            UserControlSecurity userControlSecurity = new UserControlSecurity();
            addUserControl(userControlSecurity);
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
