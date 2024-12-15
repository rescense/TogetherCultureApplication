using System.Diagnostics;
using Together_Culture__Dream_Team_.Front_End.Src.User_Controls;

namespace Together_Culture__Dream_Team_.Front_End.Src.Screens
{
    public partial class landingPage : Form
    {
        // User controls for different sections of the application
        SideMenuBar SideMenuBar = new SideMenuBar();
        AboutUs AboutUs = new AboutUs();
        Memberships Memberships = new Memberships();
        Shop Shop = new Shop();
        Blog Blog = new Blog();
        PlaceHire UserControlPlaceHire = new PlaceHire();

        // State variables to manage UI visibility and interaction
        private bool isSideMenuVisible = false;

        public landingPage()
        {
            InitializeComponent();
            InitializeDefaultView(); // Set the default view on initialization
        }

        // Sets the default view to the About Us section and hides the side menu
        private void InitializeDefaultView()
        {
            addUserControl(AboutUs);
            SideMenuPanel.Visible = false;
        }

        // Adds a user control to the main panel
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(userControl);
        }

        // Toggles the visibility of the side menu
        private void ToggleSideMenu()
        {
            isSideMenuVisible = !isSideMenuVisible;
            SideMenuPanel.Visible = isSideMenuVisible;

            if (isSideMenuVisible)
            {
                showSideMenu(SideMenuBar);
                PicSideMenuBar.BackColor = Color.Black;
            }
            else
            {
                SideMenuPanel.Controls.Clear();
                PicSideMenuBar.BackColor = Color.Transparent;
            }
        }

        // Displays a specific user control in the side menu panel
        private void showSideMenu(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            SideMenuPanel.Controls.Clear();
            SideMenuPanel.Controls.Add(userControl);
        }

        // Highlights the currently active label and resets others
        private void UpdateActiveLabelColor(Label activeLabel)
        {
            foreach (var control in MenuPanel.Controls)
            {
                if (control is Label label)
                {
                    label.BackColor = label == activeLabel ? Color.Black : Color.Transparent;
                }
            }
        }



        // Event handler for side menu bar click
        private void PicSideMenuBar_Click(object sender, EventArgs e)
        {
            ToggleSideMenu();
        }

        // Changes the background color when mouse enters the side menu icon
        private void PicSideMenuBar_MouseEnter(object sender, EventArgs e)
        {
            PicSideMenuBar.BackColor = Color.Black;
        }

        // Resets the background color when mouse leaves the side menu icon
        private void PicSideMenuBar_MouseLeave(object sender, EventArgs e)
        {
            if (!isSideMenuVisible)
            {
                PicSideMenuBar.BackColor = Color.Transparent;
            }
        }

        // Event handlers for navigation menu clicks
        private void aboutUsLabel_Click(object sender, EventArgs e)
        {
            addUserControl(AboutUs);
            UpdateActiveLabelColor(lblAboutUs);
        }

        private void membershipLabel_Click(object sender, EventArgs e)
        {
            addUserControl(Memberships);
            UpdateActiveLabelColor(lblMemberships);
        }

        private void shopLabel_Click(object sender, EventArgs e)
        {
            addUserControl(Shop);
            UpdateActiveLabelColor(lblShop);
        }

        private void blogLabel_Click(object sender, EventArgs e)
        {
            addUserControl(Blog);
            UpdateActiveLabelColor(lblBlog);
        }

        private void placeHireLabel_Click(object sender, EventArgs e)
        {
            addUserControl(UserControlPlaceHire);
            UpdateActiveLabelColor(lblPlaceHire);
        }

        // Opens a URL in the default web browser
        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to open the link: {ex.Message}");
            }
        }

        // Event handlers for footer links
        private void privacyPolicyLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrl("https://static1.squarespace.com/static/63bc104e8f7c476406bd6221/t/63eb86ae583c021a4fbf916b/1676379822886/Privacy+and+Data+Protection+Statement_Together+Culture+2023.pdf");
        }

        private void contactLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrl("https://www.togetherculture.com/contact");
        }

        private void termsOfServicesLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrl("https://static1.squarespace.com/static/63bc104e8f7c476406bd6221/t/63eb86ae583c021a4fbf916b/1676379822886/Privacy+and+Data+Protection+Statement_Together+Culture+2023.pdf");
        }

        // Opens the Sign Up form
        private void SignUpButton_Click(object sender, EventArgs e)
        {
            Sign_up sign_Up = new Sign_up();
            sign_Up.Show();
        }

        // Opens the Login form
        private void LoginButton_Click(object sender, EventArgs e)
        {
            Log_in log_In = new Log_in();
            log_In.Show();
        }
    }
}