using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Together_Culture__Dream_Team_.Front_End.Src.User_Controls
{
    public partial class Memberships : UserControl
    {
        public Memberships()
        {
            InitializeComponent();
        }

        private void Memberships_Load(object sender, EventArgs e)
        {

        }

        private void communityMemberButton_click(object sender, EventArgs e)
        {
            String url = "https://www.togetherculture.com/community-membership";
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

        private void creativeWorkspaceMember_click(object sender, EventArgs e)
        {
            String url = "https://www.togetherculture.com/creative-workspace";
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

        private void organizationMember_click(object sender, EventArgs e)
        {
            String url = "https://www.togetherculture.com/business-unusual-membership";
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
