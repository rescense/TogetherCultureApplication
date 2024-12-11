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
    public partial class SearchAndPostUserControl : UserControl
    {
        public event EventHandler SearchClicked;

        public SearchAndPostUserControl()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            var searchBox = new RichTextBox { PlaceholderText = "Search..." };
            var categoryFilter = new ComboBox { Items = { "Skills Offered", "Skills Requested" } };
            var searchButton = new Button { Text = "Search" };

            searchButton.Click += (s, e) => SearchClicked?.Invoke(this, EventArgs.Empty);

            var postTitle = new RichTextBox { PlaceholderText = "Service Title" };
            var postCategory = new ComboBox { Items = { "Request", "Offering" } };
            var postDescription = new RichTextBox { PlaceholderText = "Description" };
            var postTime = new TextBox { PlaceholderText = "Time Required (hours)" };
            var postContact = new TextBox { PlaceholderText = "Contact Preference" };
            var postButton = new Button { Text = "Post" };

            postButton.Click += (s, e) => PostService(postTitle.Text, postCategory.Text, postDescription.Text, postTime.Text, postContact.Text);

            var layout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, AutoSize = true };
            layout.Controls.Add(searchBox);
            layout.Controls.Add(categoryFilter);
            layout.Controls.Add(searchButton);
            layout.Controls.Add(postTitle);
            layout.Controls.Add(postCategory);
            layout.Controls.Add(postDescription);
            layout.Controls.Add(postTime);
            layout.Controls.Add(postContact);
            layout.Controls.Add(postButton);

            Controls.Add(layout);
        }

        private void PostService(string title, string category, string description, string time, string contact)
        {
            // Code to save service/skill in the database
            MessageBox.Show("Service posted successfully!");
        }
    }

    // User control for displaying time bank
    
}
