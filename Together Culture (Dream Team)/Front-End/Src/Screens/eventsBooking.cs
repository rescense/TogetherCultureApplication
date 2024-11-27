using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Together_Culture__Dream_Team_.Front_End.Src.Screens;
using Together_Culture__Dream_Team_.Front_End.Src.Screens.All_Users_Screen;

namespace togther_Culture
{
    public partial class eventsBooking : Form
    {
        public eventsBooking()
        {
            InitializeComponent();
        }

        private void eventsBooking_Load(object sender, EventArgs e)
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

        private void togetherCulturePictureBox(object sender, EventArgs e)
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
            eventsMain emEb = new eventsMain();
            emEb.Show();
        }

        private void skillShareBtn(object sender, EventArgs e)
        {
            skillShare skEb = new skillShare();
            skEb.Show();
        }

        private void myModulesBtn(object sender, EventArgs e)
        {

        }

        private void profileBtn(object sender, EventArgs e)
        {
            AccountSettingsPage aspEb = new AccountSettingsPage();
            aspEb.Show();
        }

        // Events Panel
        private void eventsPanel(object sender, PaintEventArgs e)
        {

        }
        // event details including title and etc
        private void eventTitle(object sender, EventArgs e)
        {

        }

        private void eventDescription(object sender, EventArgs e)
        {

        }
        // event details label
        private void eventDetailsLabel(object sender, EventArgs e)
        {

        }

        // Booking Panel
        private void bookingPanel(object sender, PaintEventArgs e)
        {

        }
        private void bookingCatchPhrasePanel(object sender, EventArgs e)
        {

        }

        private void detailsLabel(object sender, EventArgs e)
        {

        }

        private void numOfAttendeesTextBox(object sender, EventArgs e)
        {

        }

        private void nameOfAttendee(object sender, EventArgs e)
        {

        }

        private void typeOfAttendeeComboBox(object sender, EventArgs e)
        {

        }

        private void addAttendeeButton(object sender, EventArgs e)
        {

        }

        private void removeAttendeeButton(object sender, EventArgs e)
        {

        }
        private void payForOrderButton(object sender, EventArgs e)
        {
            Payment payment = new Payment();
            payment.Show();
        }

        private void attendeeListDataGrideView(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dtataGridViewScrollBar(object sender, ScrollEventArgs e)
        {

        }

        // FeedBack Panel
        private void feedBackPanel(object sender, PaintEventArgs e)
        {

        }

        // Labels
        private void catchPhraseLabel(object sender, EventArgs e)
        {

        }

        private void numOfFeedBacksLabel(object sender, EventArgs e)
        {

        }

        private void valueOfNumOfFeedBacks(object sender, EventArgs e)
        {

        }

        private void commentsAndRatingsLabel(object sender, EventArgs e)
        {

        }

        // Data Grid View and Scroll Bar
        private void commentsAndRatingsDataGridView(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void commentsAndRatingsScrollBar(object sender, ScrollEventArgs e)
        {

        }
    }
}
