using Dapper;
using Microsoft.Extensions.Configuration;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SocialService.DataAccess.Repositories
{
    public class UserDapperRepository : IDapperRepository<User>
    {
        private string _connectionString;
        private readonly IConfiguration _configuration;
        public UserDapperRepository()
        {
            _configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json")
           .Build();
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public void Create(User item)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Users(Email,Password) Values(@Email,@Password)";
                connection.Execute(query, item);
            }
        }

        public void Delete(int id, string userId)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Users WHERE Id=@id";
                connection.Execute(query, new { id });
            }
        }

        public User Get(int id, string userId)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Users WHERE Id=@id";
                return connection.Query<User>(query, new { id }).FirstOrDefault();
            }
        }

        public IEnumerable<User> GetAll(string userId)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Users";
                return connection.Query<User>(query);
            }
        }

        public void Update(User item)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Users SET Id = @Id, Email = @Email, Password = @Password WHERE Id = @Id";
                connection.Execute(query, item);
            }
        }
    }
}
