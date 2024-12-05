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
    public partial class skillShare : Form
    {
        public skillShare()
        {
            InitializeComponent();
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
        private void logoPictureBox(object sender, EventArgs e)
        {

        }
        // Buttons on header Panel
        private void chatSpaceBtn(object sender, EventArgs e)
        {
            
        }

        private void forYouBtn(object sender, EventArgs e)
        {

        }

        private void eventsBtn(object sender, EventArgs e)
        {
            eventsMain emSsm = new eventsMain();
            emSsm.Show();
        }

        private void skillShareBtn(object sender, EventArgs e)
        {
            skillShare skSsm = new skillShare();
            skSsm.Show();
        }

        private void myModulesBtn(object sender, EventArgs e)
        {

        }

        private void profileBtn(object sender, EventArgs e)
        {
            AccountSettingsPage aspSsm = new AccountSettingsPage();
            aspSsm.Show();
        }

        // Search Panel
        private void searchPanel(object sender, PaintEventArgs e)
        {

        }

        private void searchBoxTextBox(object sender, EventArgs e)
        {

        }

        private void filteringSearchComboBox(object sender, EventArgs e)
        {

        }

        private void searchBtn(object sender, EventArgs e)
        {
            SkillShareResults sskSsm = new SkillShareResults();
            sskSsm.Show();
        }

        // post a service panel
        private void postServicePanel(object sender, PaintEventArgs e)
        {

        }

        private void postServiceLabel(object sender, EventArgs e)
        {

        }

        private void detailsForPostLabel(object sender, EventArgs e)
        {

        }

        private void serviceTitleTextBox(object sender, EventArgs e)
        {

        }

        private void offerRequestCombobox(object sender, EventArgs e)
        {

        }

        private void descriptionTextBox(object sender, EventArgs e)
        {

        }

        private void timeRequiredTextBox(object sender, EventArgs e)
        {

        }

        private void contactPreferenceTextBox(object sender, EventArgs e)
        {

        }

        private void postBtn(object sender, EventArgs e)
        {

        }


        // Timebank Panel
        private void timeBankPanel(object sender, PaintEventArgs e)
        {

        }

        // header label
        private void timeBankHeaderLabel(object sender, EventArgs e)
        {

        }

        // text label
        private void timeBankDescriptionLabel(object sender, EventArgs e)
        {

        }

        // text panel for offer/request
        private void offerRequestPanel(object sender, PaintEventArgs e)
        {

        }

        // text label for offer/request
        private void requestLabel(object sender, EventArgs e)
        {

        }

        private void offerLabel(object sender, EventArgs e)
        {

        }

        // value panel for offer or request
        private void valueOfferPanel(object sender, PaintEventArgs e)
        {

        }

        private void valueRequestPanel(object sender, PaintEventArgs e)
        {

        }

        // value label for offer or request
        private void valueRequestLabel(object sender, EventArgs e)
        {

        }

        private void valueOfferLabel(object sender, EventArgs e)
        {

        }
    }
}
