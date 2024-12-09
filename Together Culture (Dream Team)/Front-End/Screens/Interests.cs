using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Together_Culture__Dream_Team_.Front_End.Src.Screens
{
    public partial class Interests : Form
    {
        public Interests()
        {
            InitializeComponent();
        }

        private bool isExperiencingSelected = false;

        private void btnExperiencing_Click(object sender, EventArgs e)
        {
            // Toggle the selection state
            isExperiencingSelected = !isExperiencingSelected;

            // Show the appropriate message
            if (isExperiencingSelected)
            {
                MessageBox.Show("Experiencing selected!");
            }
            else
            {
                MessageBox.Show("Experiencing unselected!");
            }
        }

        private bool isCreatingSelected = false;
        private void btnCreating_Click(object sender, EventArgs e)
        {
            // Toggle the selection state
            isCreatingSelected = !isCreatingSelected;

            // Show the appropriate message
            if (isCreatingSelected)
            {
                MessageBox.Show("Creating selected!");
            }
            else
            {
                MessageBox.Show("Creating unselected!");
            }
        }

        private bool isSharingSelected = false;
        private void btnSharing_Click(object sender, EventArgs e)
        {
            // Toggle the selection state
            isSharingSelected = !isSharingSelected;

            // Show the appropriate message
            if (isSharingSelected)
            {
                MessageBox.Show("Sharing selected!");
            }
            else
            {
                MessageBox.Show("Sharing unselected!");
            }
        }

        private bool isCaringSelected = false;

        private void btnCaring_Click(object sender, EventArgs e)
        {
            // Toggle the selection state
            isCaringSelected = !isCaringSelected;

            // Show the appropriate message
            if (isCaringSelected)
            {
                MessageBox.Show("Caring selected!");
            }
            else
            {
                MessageBox.Show("Caring unselected!");
            }
        }

        private bool isWorkingSelected = false; 

        private void btnWorking_Click(object sender, EventArgs e)
        {
            // Toggle the selection state
            isWorkingSelected = !isWorkingSelected;

            // Show the appropriate message
            if (isWorkingSelected)
            {
                MessageBox.Show("Working selected!");
            }
            else
            {
                MessageBox.Show("Working unselected!");
            }
        }
    }
}
