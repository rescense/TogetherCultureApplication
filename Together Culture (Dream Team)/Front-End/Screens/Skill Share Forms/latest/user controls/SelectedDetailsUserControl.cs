using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Together_Culture__Dream_Team_.Front_End.Screens.Skill_Share_Forms.latest.user_controls
{
    public partial class SelectedDetailsUserControl : UserControl
    {
        public SelectedDetailsUserControl(skillShareForm.EventDetails eventDetails = null)
        {
            InitializeComponent();
            InitializeComponents(eventDetails);
        }

        private void InitializeComponents(skillShareForm.EventDetails eventDetails)
        {
            if (eventDetails != null)
            {
                var ServiceTitle = eventDetails.ServiceTitle ?? "Service Title";
                var Category = eventDetails.Category ?? "Category";
                var TimeRequired = eventDetails.TimeRequired.ToString() + " hours";
                var description = eventDetails.Description ?? "Description";
                var contact = eventDetails.ContactPreference ?? "Contact Preference";
                var memberName = eventDetails.MemberName ?? "Member Name";

                label3.Text = $"{memberName}\n\nAssistance Type\n\n{Category}\n\n{TimeRequired}\n\n{description}\n\n\n{contact}";
            }

            guna2Button9.Click += (s, e) =>
            {
                // Code to log interest in the database
                MessageBox.Show("Interest shown successfully!");
            };
        }

        private void guna2CustomGradientPanel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
