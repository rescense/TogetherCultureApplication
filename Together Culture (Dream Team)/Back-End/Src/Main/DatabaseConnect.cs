using System;
using System.Data.SqlClient;
using System.IO;

namespace Together_Culture__Dream_Team_.Back_End.Src.Main
{
    internal class DatabaseConnect : IDisposable
    {
        private readonly SqlConnection _connection;

        public DatabaseConnect()
        {
            // Construct the connection string dynamically
            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Development\Latest Clone\2\Together Culture (Dream Team)\Database\db_TogetherCulture.mdf"";Integrated Security=True;Connect Timeout=30";

            // Initialize the connection
            _connection = new SqlConnection(connectionString);
        }

        public SqlConnection Connection => _connection;

        // Open the connection
        public void Open()
        {
            try
            {
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error opening the connection: {ex.Message}");
                throw;
            }
        }

        // Close the connection
        public void Close()
        {
            try
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error closing the connection: {ex.Message}");
                throw;
            }
        }

        // Dispose method to release resources
        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
