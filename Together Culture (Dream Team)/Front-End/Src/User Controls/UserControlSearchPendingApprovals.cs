using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Together_Culture__Dream_Team_.Front_End.Src.User_Controls
{
    public partial class UserControlSearchPendingApprovals : UserControl
    {
        public UserControlSearchPendingApprovals()
        {
            InitializeComponent();
        }

        private void UserControlSearchPendingApprovals_Load(object sender, EventArgs e)
        {

        }

        private void searchBarPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CustomGradientPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void searchPendingApprovals_MouseClic(object sender, MouseEventArgs e)
        {
            // Only clear the placeholder text if it's the default
            if (searchPendingApprovalsTxtBx.Text == "Search pending approvals...")
            {
                searchPendingApprovalsTxtBx.Text = "";
                searchPendingApprovalsTxtBx.ForeColor = System.Drawing.Color.Black; // Change text color to black when editing
            }
        }

        private void searchPendingApprovalsTxtBx_Leave(object sender, EventArgs e)
        {
            // Restore the placeholder text if the user has left it empty
            if (string.IsNullOrEmpty(searchPendingApprovalsTxtBx.Text))
            {
                searchPendingApprovalsTxtBx.Text = "Search pending approvals...";
                searchPendingApprovalsTxtBx.ForeColor = System.Drawing.Color.Gray; // Change color back to gray
            }
        }

        private void selectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (selectAllCheckBox.Focused) // Ensure triggered by user action
            {
                // Get the state of the "Select All" checkbox
                bool selectAll = selectAllCheckBox.Checked;

                // Loop through all child controls recursively
                foreach (CheckBox checkBox in GetAllCheckBoxes(panel1))
                {
                    if (checkBox != selectAllCheckBox)
                    {
                        checkBox.CheckedChanged -= otherCheckBox_CheckedChanged; // Detach event
                        checkBox.Checked = selectAll; // Set state
                        checkBox.CheckedChanged += otherCheckBox_CheckedChanged; // Reattach event
                    }
                }

                UpdateSelectAllText();
            }
        }

        private void otherCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Determine if all or none are checked
            bool allChecked = true;
            bool noneChecked = true;

            foreach (CheckBox checkBox in GetAllCheckBoxes(panel1))
            {
                if (checkBox != selectAllCheckBox)
                {
                    if (checkBox.Checked)
                        noneChecked = false;
                    else
                        allChecked = false;
                }
            }

            // Update "Select All" checkbox state
            selectAllCheckBox.CheckedChanged -= selectAllCheckBox_CheckedChanged; // Detach event
            selectAllCheckBox.Checked = allChecked; // Update state
            selectAllCheckBox.CheckedChanged += selectAllCheckBox_CheckedChanged; // Reattach event

            UpdateSelectAllText();
        }

        private void UpdateSelectAllText()
        {
            // Check if none are checked
            bool noneChecked = true;

            foreach (CheckBox checkBox in GetAllCheckBoxes(panel1))
            {
                if (checkBox != selectAllCheckBox && checkBox.Checked)
                {
                    noneChecked = false;
                    break;
                }
            }

            selectAllCheckBox.Text = noneChecked ? "Select All" : "Deselect All";
        }

        // Helper function to get all checkboxes recursively
        private IEnumerable<CheckBox> GetAllCheckBoxes(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is CheckBox checkBox)
                    yield return checkBox;
                else if (control.HasChildren)
                {
                    foreach (var childCheckBox in GetAllCheckBoxes(control))
                        yield return childCheckBox;
                }
            }
        }
    }
}
