using Together_Culture__Dream_Team_.Front_End.User_Controls;

namespace Together_Culture__Dream_Team_.Front_End.Src.User_Controls
{
    public partial class UserControlSecurity : UserControl
    {

        public static Panel panel;
        public UserControlSecurity()
        {
            InitializeComponent();

            mainPanel.Visible = false;

            panel = this.mainPanel;
        }

        private void btnArrow1_Click(object sender, EventArgs e)
        {
            AuthenticationWindow authenticationWindow = new AuthenticationWindow();
            mainPanel.Visible = true;
            addUserControl(authenticationWindow);
        }

        private void btnArrow2_Click(object sender, EventArgs e)
        {
            LoginAlertWindow loginAlertWindow = new LoginAlertWindow();
            mainPanel.Visible = true;
            addUserControl(loginAlertWindow);
        }

        private void btnArrow3_Click(object sender, EventArgs e)
        {
            RecentEmailsWindow recentEmailsWindow = new RecentEmailsWindow();
            mainPanel.Visible = true;
            addUserControl(recentEmailsWindow);
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(userControl);
            userControl.BringToFront();
        }
    }
}
