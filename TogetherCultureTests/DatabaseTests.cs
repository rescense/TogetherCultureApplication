using NUnit.Framework;
using System;
using System.Data.SqlClient;
using Together_Culture__Dream_Team_.Back_End.Src.Main; // Adjust the namespace if necessary

namespace TogetherCultureTests
{
    public class DatabaseTests : IDisposable
    {
        private DatabaseConnect _dbConnect;

        [SetUp]
        public void SetUp()
        {
            // Initialize the database connection before each test
            _dbConnect = new DatabaseConnect();
            _dbConnect.Open();
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up the connection after each test
            _dbConnect.Close();
        }

        [Test]
        public void TestPrimaryKeyUniqueness()
        {
            var query = "SELECT COUNT(*) AS NonUniqueUserIds FROM [user] GROUP BY [user_id] HAVING COUNT([user_id]) > 1";
            var command = new SqlCommand(query, _dbConnect.Connection);
            var result = command.ExecuteScalar();

            // Convert the result to an int, treating null as 0
            int resultCount = result == DBNull.Value ? 0 : Convert.ToInt32(result);

            // Assert that there are no duplicates (result should be 0)
            NUnit.Framework.Assert.AreEqual(0, resultCount, "Primary key uniqueness violated in [user] table");
        }


        [Test]
        public void TestForeignKeyConstraints()
        {
            // Test orphaned records in [payments]
            var query = "SELECT COUNT(*) FROM [payments] WHERE [user_id] NOT IN (SELECT [user_id] FROM [user])";
            var command = new SqlCommand(query, _dbConnect.Connection);
            var result = (int)command.ExecuteScalar();
            NUnit.Framework.Assert.AreEqual(result, 0, "Foreign key constraint violated in [payments] table");
        }

        [Test]
        public void TestCheckConstraints()
        {
            // Test for invalid user types in [user] table
            var query = "SELECT COUNT(*) FROM [user] WHERE [user_type] NOT IN ('non_member', 'member')";
            var command = new SqlCommand(query, _dbConnect.Connection);
            var result = (int)command.ExecuteScalar();
            NUnit.Framework.Assert.AreEqual(result, 0, "Check constraint violated in [user] table for [user_type]");
        }

        [Test]
        public void TestUniqueConstraints()
        {
            // Test for duplicate emails in [user] table
            var query = "SELECT [email], COUNT(*) AS EmailCount FROM [user] GROUP BY [email] HAVING COUNT(*) > 1";
            var command = new SqlCommand(query, _dbConnect.Connection);
            var reader = command.ExecuteReader();
            NUnit.Framework.Assert.IsFalse(reader.HasRows, "Duplicate email found in [user] table");
        }

        [Test]
        public void TestCascadingDelete()
        {
            // Test cascading delete in [user_memberships]
            var userIdToDelete = 1; // Choose an existing user_id to test
            var deleteQuery = $"DELETE FROM [user] WHERE [user_id] = {userIdToDelete}";
            var command = new SqlCommand(deleteQuery, _dbConnect.Connection);
            command.ExecuteNonQuery();

            var checkQuery = $"SELECT COUNT(*) FROM [user_memberships] WHERE [user_id] = {userIdToDelete}";
            command = new SqlCommand(checkQuery, _dbConnect.Connection);
            var result = (int)command.ExecuteScalar();
            NUnit.Framework.Assert.AreEqual(result, 0, "Cascade delete failed in [user_memberships] table");
        }

        public void Dispose()
        {
            // Dispose of the database connection after all tests
            _dbConnect?.Dispose();
        }
    }
}
