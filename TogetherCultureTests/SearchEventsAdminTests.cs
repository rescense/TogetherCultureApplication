using NUnit.Framework;
using Moq;
using System.Data;
using System.Windows.Forms;
using Together_Culture__Dream_Team_.Front_End.Src.User_Controls;
using Guna.UI2.WinForms;
using System.Linq;
using System.Data.SqlClient;
using Together_Culture__Dream_Team_.Back_End.Src.Main;
using Together_Culture__Dream_Team_.Front_End.Screens.Admin_Forms.User_Controls;
using Assert = NUnit.Framework.Assert;

namespace Together_Culture__Dream_Team_.Tests
{
    [TestFixture]
    public class SearchEventsAdminTests
    {
        private SearchEventsAdmin _searchEventsAdmin;
        private Mock<DatabaseConnect> _mockDatabaseConnect;
        private DataTable _mockEventDataTable;

        [SetUp]
        public void SetUp()
        {
            _mockDatabaseConnect = new Mock<DatabaseConnect>();
            _mockEventDataTable = new DataTable();

            // Mock the event data table
            _mockEventDataTable.Columns.Add("event_name");
            _mockEventDataTable.Columns.Add("date");
            _mockEventDataTable.Columns.Add("time");
            _mockEventDataTable.Columns.Add("location");

            _mockEventDataTable.Rows.Add("Event 1", "2024-12-01", "12:00", "Location 1");
            _mockEventDataTable.Rows.Add("Event 2", "2024-12-02", "14:00", "Location 2");

            _mockDatabaseConnect.Setup(m => m.Open()).Verifiable();
            _mockDatabaseConnect.Setup(m => m.Connection).Returns(new SqlConnection());
            _mockDatabaseConnect.Setup(m => m.ExecuteQuery(It.IsAny<string>())).Returns(_mockEventDataTable);

            // Initialize the SearchEventsAdmin control
            _searchEventsAdmin = new SearchEventsAdmin();
            _searchEventsAdmin.eventDataTable = _mockEventDataTable;
        }

        [TearDown]
        public void TearDown()
        {
            _mockDatabaseConnect = null;
            _searchEventsAdmin = null;
        }

        // Test Search Functionality
        [Test]
        public void SearchEventsTxtBx_TextChanged_ShouldFilterEvents()
        {
            // Arrange
            _searchEventsAdmin.searchEventsTxtBx.Text = "Event 1";

            // Act
            _searchEventsAdmin.SearchEventsTxtBx_TextChanged(this, EventArgs.Empty);
            var filteredData = ((DataView)_searchEventsAdmin.eventDataGridView.DataSource).ToTable();

            // Assert
            Assert.AreEqual(1, filteredData.Rows.Count);  // Only "Event 1" should be visible
        }

        // Test Filter Button
        [Test]
        public void FilterBtn_Click_ShouldToggleFilterPanelVisibility()
        {
            // Arrange
            var filterButton = _searchEventsAdmin.Controls.OfType<Button>().FirstOrDefault(b => b.Name == "FilterBtn");

            // Act
            _searchEventsAdmin.FilterBtn_Click(filterButton, EventArgs.Empty);

            // Assert
            Assert.IsTrue(_searchEventsAdmin.filterPanel.Visible);  // Filter panel should be visible now

            // Act again to hide it
            _searchEventsAdmin.FilterBtn_Click(filterButton, EventArgs.Empty);

            // Assert
            Assert.IsFalse(_searchEventsAdmin.filterPanel.Visible);  // Filter panel should be hidden now
        }

        // Test Placeholder Text Behavior in Search Box
        [Test]
        public void SearchEventsTxtBx_TextChanged_ShouldClearPlaceholderText()
        {
            // Arrange
            _searchEventsAdmin.searchEventsTxtBx.Text = "Search events...";

            // Act
            _searchEventsAdmin.SearchEventsTxtBx_MouseClic(this, null);

            // Assert
            Assert.AreEqual("", _searchEventsAdmin.searchEventsTxtBx.Text);  // Placeholder text should be cleared
        }

        // Test Search Events Text Box Leave Behavior
        [Test]
        public void SearchEventsTxtBxx_Leave_ShouldRestorePlaceholderTextIfEmpty()
        {
            // Arrange
            _searchEventsAdmin.searchEventsTxtBx.Text = "";

            // Act
            _searchEventsAdmin.SearchEventsTxtBxx_Leave(this, EventArgs.Empty);

            // Assert
            Assert.AreEqual("Search events...", _searchEventsAdmin.searchEventsTxtBx.Text);  // Placeholder should be restored
        }
    }
}
