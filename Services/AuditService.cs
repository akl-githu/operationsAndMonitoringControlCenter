using controlCenter.Models;
using MySql.Data.MySqlClient;

namespace controlCenter.Services
{
    public class AuditService
    {
        private readonly string _connectionString;

        public AuditService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")?? throw new ArgumentNullException(nameof(configuration));
        }

        public void RecordAction(string username, string action)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("INSERT INTO AuditLogs (Username, Action, Timestamp) VALUES (@Username, @Action, @Timestamp)", connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Action", action);
                command.Parameters.AddWithValue("@Timestamp", DateTime.UtcNow);
                command.ExecuteNonQuery();
            }
        }
    }
}