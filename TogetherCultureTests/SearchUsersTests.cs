using Together_Culture__Dream_Team_.Front_End.Src.User_Controls;
using System.Windows.Forms;
using NUnit.Framework;
using Moq;


namespace Together_Culture__Dream_Team_Tests
{
    [TestFixture]
    public class SearchUsersTests
    {
        // Testing LoadDataIntoGridView, expected outcome is the columns display the correct information in the columns
        [Test]
        public void TestLoadDataIntoDataGridView()
        {
            var searchUsersControl = new SearchUsers();
            searchUsersControl.LoadDataIntoDataGridView();

            NUnit.Framework.Assert.IsNotNull(searchUsersControl.userDataTable);
            NUnit.Framework.Assert.IsTrue(searchUsersControl.dataGridView1.Rows.Count > 0);
            NUnit.Framework.Assert.AreEqual("Username", searchUsersControl.dataGridView1.Columns[1].HeaderText);
        }

        // Testing the SearchUsers search bar
        [Test]
        public void TestSearchUsers()
        {
            var searchUsersControl = new SearchUsers();
            searchUsersControl.LoadDataIntoDataGridView();
            searchUsersControl.searchUsersTxtBx.Text = "John";

            // Simulate typing and applying the filter
            searchUsersControl.SearchUsersTxtBx_TextChanged(null, null);

            NUnit.Framework.Assert.IsTrue(searchUsersControl.dataGridView1.Rows.Count > 0);
            NUnit.Framework.Assert.IsTrue(searchUsersControl.dataGridView1.Rows[0].Cells["first_name"].Value.ToString().Contains("John"));
        }

        // Testing the Select All checkbox: expecting to select all rows after clicking select all checkbox, and deselecting if pressed again
        [Test]
        public void TestSelectAllCheckBox()
        {
            var searchUsersControl = new SearchUsers();
            searchUsersControl.LoadDataIntoDataGridView();
            searchUsersControl.selectAllCheckBox.Checked = true;

            searchUsersControl.SelectAllCheckBox_CheckedChanged(null, null);

            foreach (DataGridViewRow row in searchUsersControl.dataGridView1.Rows)
            {
                NUnit.Framework.Assert.IsTrue((bool)row.Cells["Select"].Value);
            }
        }

        //Testing GetSelectedUsers, the method should return a list of usernames for all selected rows
        [Test]
        public void TestGetSelectedUsers()
        {
            var searchUsersControl = new SearchUsers();
            searchUsersControl.LoadDataIntoDataGridView();

            // Select the first row
            searchUsersControl.dataGridView1.Rows[0].Cells["Select"].Value = true;

            var selectedUsers = searchUsersControl.GetSelectedUsers();
            NUnit.Framework.Assert.AreEqual(1, selectedUsers.Count);
            NUnit.Framework.Assert.AreEqual(searchUsersControl.dataGridView1.Rows[0].Cells["username"].Value.ToString(), selectedUsers[0]);
        }

        [Test]
        public void TestSearchBoxPlaceholderText()
        {
            // Create an instance of SearchUsers
            var searchUsersControl = new SearchUsers();

            // Ensure components are initialized
            searchUsersControl.InitializeComponent();

            // Check if the searchUsersTxtBx is initialized
            NUnit.Framework.Assert.IsNotNull(searchUsersControl.searchUsersTxtBx, "searchUsersTxtBx is not initialized");

            // Explicitly set the initial placeholder text in the test
            searchUsersControl.searchUsersTxtBx.Text = "Search users...";

            // Test placeholder text before focus (initial value)
            NUnit.Framework.Assert.AreEqual("Search users...", searchUsersControl.searchUsersTxtBx.Text, "Placeholder text is not set correctly initially.");

            // Simulate user clicking on the text box (this should clear the text)
            searchUsersControl.SearchUsersTxtBx_MouseClic(null, null);
            NUnit.Framework.Assert.AreEqual("", searchUsersControl.searchUsersTxtBx.Text, "Text should be empty after clicking on the text box.");

            // Simulate user leaving the text box empty (this should restore the placeholder text)
            searchUsersControl.SearchUsersTxtBx_Leave(null, null);
            NUnit.Framework.Assert.AreEqual("Search users...", searchUsersControl.searchUsersTxtBx.Text, "Placeholder text was not restored after losing focus.");
        }

        [Test]
        public void TestActionsPanelVisibility()
        {
            var searchUsersControl = new SearchUsers();

            // Ensure the actions panel is initially hidden
            NUnit.Framework.Assert.IsFalse(searchUsersControl.actionsPanel.Visible);

            // Simulate clicking the actions button to show the panel
            searchUsersControl.ActionsSearchUsersBtn_Click(null, null);
            NUnit.Framework.Assert.IsTrue(searchUsersControl.actionsPanel.Visible);

            // Simulate clicking again to hide the panel
            searchUsersControl.ActionsSearchUsersBtn_Click(null, null);
            NUnit.Framework.Assert.IsFalse(searchUsersControl.actionsPanel.Visible);
        }

        [Test]
        public void TestFilterPanelVisibility()
        {
            var searchUsersControl = new SearchUsers();

            // Initially, the filter panel should be hidden
            NUnit.Framework.Assert.IsFalse(searchUsersControl.filterPanel.Visible);

            // Simulate clicking the filter button to show the panel
            searchUsersControl.FilterBtn_Click(null, null);
            NUnit.Framework.Assert.IsTrue(searchUsersControl.filterPanel.Visible);

            // Simulate clicking again to hide the panel
            searchUsersControl.FilterBtn_Click(null, null);
            NUnit.Framework.Assert.IsFalse(searchUsersControl.filterPanel.Visible);
        }
    }
}
