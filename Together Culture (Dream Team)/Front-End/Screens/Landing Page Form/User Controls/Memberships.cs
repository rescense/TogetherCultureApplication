using System.Diagnostics;

namespace Together_Culture__Dream_Team_.Front_End.Src.User_Controls
{
    public partial class Memberships : UserControl
    {
        public Memberships()
        {
            InitializeComponent();
        }

        // Event triggered when Memberships UserControl is loaded
        private void Memberships_Load(object sender, EventArgs e)
        {
            // Any initialization code can be added here if required
        }

        // Opens the Community Membership page
        private void communityMemberButton_click(object sender, EventArgs e)
        {
            OpenUrl("https://www.togetherculture.com/community-membership");
        }

        // Opens the Creative Workspace Membership page
        private void creativeWorkspaceMember_click(object sender, EventArgs e)
        {
            OpenUrl("https://www.togetherculture.com/creative-workspace");
        }

        // Opens the Organization Membership page
        private void organizationMember_click(object sender, EventArgs e)
        {
            OpenUrl("https://www.togetherculture.com/business-unusual-membership");
        }

        // Reusable method to open a URL in the default browser
        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // Ensures compatibility with modern systems
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to open the link: {ex.Message}");
            }
        }
    }
}

