using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Together_Culture__Dream_Team_.Front_End.Src.Screens.All_Users_Screen;

namespace Together_Culture__Dream_Team_.Front_End.Src.Screens
{
    public partial class SkillShareResults : Form
    {
        public SkillShareResults()
        {
            InitializeComponent();
        }

        private void skillShareResult_Load(object sender, EventArgs e)
        {

        }
        // ~~~~~  Header Panel  ~~~~~
        private void headerPanel(object sender, PaintEventArgs e)
        {

        }
        // together culture label on header panel
        private void togetherCultureLabel(object sender, EventArgs e)
        {

        }
        // together culture logo on header panel
        private void logoOnHeaderPanel(object sender, EventArgs e)
        {

        }
        // Buttons on header Panel
        private void chatSpace(object sender, EventArgs e)
        {

        }
        private void forYou(object sender, EventArgs e)
        {

        }

        private void eventsBtn(object sender, EventArgs e)
        {
            eventsMain emSsr = new eventsMain();
            emSsr.Show();
        }

        private void skillShareBtn(object sender, EventArgs e)
        {
            skillShare skSsr = new skillShare();
            skSsr.Show();
        }
        private void myModulesBtn(object sender, EventArgs e)
        {

        }

        private void profileBtn(object sender, EventArgs e)
        {
            AccountSettingsPage aspSsr = new AccountSettingsPage();
            aspSsr.Show();
        }

        // Search Panel
        private void searchPanel(object sender, PaintEventArgs e)
        {

        }
        private void searchTextBox(object sender, EventArgs e)
        {

        }

        private void filterComboBox(object sender, EventArgs e)
        {

        }

        private void searchBtn(object sender, EventArgs e)
        {
            SkillShareResults ssk2 = new SkillShareResults();
        }
        // Results Panel
        private void resultDataGrideViewCell(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void resultDataScrollBar(object sender, ScrollEventArgs e)
        {

        }

        // selected result panel
        private void selectedResultPanel(object sender, PaintEventArgs e)
        {

        }

        private void profilePictureBox(object sender, EventArgs e)
        {

        }

        private void detailsLabel(object sender, EventArgs e)
        {

        }
        private void detailsFetchedFromResultLabel(object sender, EventArgs e)
        {

        }
        private void showInterestBtn(object sender, EventArgs e)
        {

        }
    }
}
