using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Together_Culture__Dream_Team_.Front_End.Screens.Skill_Share_Forms.latest.user_controls
{
    public partial class SelectedDetailsUserControl : UserControl
    {
        public SelectedDetailsUserControl(/*EventDetails eventDetails = null*/)
        {
            InitializeComponents(/*eventDetails*/);
        }

        private void InitializeComponents(/*EventDetails eventDetails*/)
        {
            /*
            var description = new Label { Text = eventDetails?.Description ?? "Description" };
            var contact = new Label { Text = eventDetails?.ContactPreference ?? "Contact Preference" };
            var memberName = new Label { Text = eventDetails?.MemberName ?? "Member Name" };
            var showInterestButton = new Button { Text = "Show Interest" };
            

            showInterestButton.Click += (s, e) =>
            {
                // Code to log interest in the database
                MessageBox.Show("Interest shown successfully!");
            };

            var layout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, AutoSize = true };
            layout.Controls.Add(description);
            layout.Controls.Add(contact);
            layout.Controls.Add(memberName);
            layout.Controls.Add(showInterestButton);

            Controls.Add(layout);*/
        }
        private void guna2CustomGradientPanel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
