using System.Data;
using System.Data.SqlClient;

namespace Together_Culture__Dream_Team_.Back_End.Src.Main
{
    public class DatabaseConnect : IDisposable
    {
        private readonly SqlConnection _connection;

        public DatabaseConnect()
        {
            // Construct the connection string dynamically
            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\manas\OneDrive\Documents\seema\New folder (5)\Together Culture (Dream Team)\Database\db_TogetherCulture.mdf"";Integrated Security=True;Connect Timeout=30";

            // Initialize the connection
            _connection = new SqlConnection(connectionString);
        }

        public virtual SqlConnection Connection => _connection;

        // Open the connection
        public virtual void Open()
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

        // Execute a query and return a DataTable
        public virtual DataTable ExecuteQuery(string query)
        {
            var dataTable = new DataTable();

            try
            {
                using (var command = new SqlCommand(query, _connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing query: {ex.Message}");
                throw; // Re-throw the exception after logging
            }

            return dataTable;
        }
    }
}
