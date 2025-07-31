using controlCenter.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace controlCenter.Services
{
    public class UserService
    {
        private readonly string _connectionString;

        public UserService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // Existing method to get a user by username and password
        public User GetUserByUsernameAndPassword(string username, string password)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash", connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@PasswordHash", password);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            Id = reader.GetInt32("Id"),
                            Username = reader.GetString("Username"),
                            PasswordHash = reader.GetString("PasswordHash"),
                            Role = reader.GetString("Role")
                        };
                    }
                }
            }
            return null;
        }

        // New method to retrieve all users
        public List<User> GetAllUsers()
        {
            var users = new List<User>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM Users", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Id = reader.GetInt32("Id"),
                            Username = reader.GetString("Username"),
                            PasswordHash = reader.GetString("PasswordHash"),
                            Role = reader.GetString("Role")
                        });
                    }
                }
            }

            return users;
        }

        // Add User method
        public void AddUser(string username, string password, string role)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("INSERT INTO Users (Username, PasswordHash, Role) VALUES (@Username, @PasswordHash, @Role)", connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@PasswordHash", password);
                command.Parameters.AddWithValue("@Role", role);

                command.ExecuteNonQuery();
            }
        }

        // Method to update user details
        public void UpdateUser(string username, string password, string role)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("UPDATE Users SET PasswordHash = @PasswordHash, Role = @Role WHERE Username = @Username", connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@PasswordHash", password);
                command.Parameters.AddWithValue("@Role", role);

                command.ExecuteNonQuery();
            }
        }

        // Method to delete a user based on Username and Role
        public void DeleteUser(string username, string role)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("DELETE FROM Users WHERE Username = @Username AND Role = @Role", connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Role", role);

                command.ExecuteNonQuery();
            }
        }
    }
}


/*
using controlCenter.Models;
using MySql.Data.MySqlClient;

namespace controlCenter.Services
{
    public class UserService
    {
        private readonly string _connectionString;

        public UserService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash", connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@PasswordHash", password);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            Id = reader.GetInt32("Id"),
                            Username = reader.GetString("Username"),
                            PasswordHash = reader.GetString("PasswordHash"),
                            Role = reader.GetString("Role") // Fetch the user's role
                        };
                    }
                }
            }
            return null;
        }
    }
}
*/