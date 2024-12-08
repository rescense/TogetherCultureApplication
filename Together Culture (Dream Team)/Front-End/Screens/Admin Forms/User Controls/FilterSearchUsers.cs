using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Together_Culture__Dream_Team_.Front_End.Screens.Admin_Forms.User_Controls
{
    public partial class FilterSearchUsers : UserControl
    {
        public event EventHandler FilterApplied;

        public FilterSearchUsers()
        {
            InitializeComponent();

            // Initialize the radio button event handlers
            nameAscRadioBtn.CheckedChanged += RadioButton_CheckedChanged;
            nameDescRadioBtn.CheckedChanged += RadioButton_CheckedChanged;
        }

        // Event handler for radio button change
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Fire the FilterApplied event to notify parent form to apply the filter
            FilterApplied?.Invoke(this, EventArgs.Empty);
        }

        // Add methods for your filtering logic (this could be for sorting users, etc.)
        public bool IsAscending => nameAscRadioBtn.Checked;
    }
}

