using Microsoft.Extensions.Configuration;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace SocialService.DataAccess.Repositories
{
    public class FriendDapperRepository : IDapperRepository<Friend>
    {
        private string _connectionString;
        private readonly IConfiguration _configuration;
        public FriendDapperRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public void Create(Friend item)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Friends(Name,Email,Phone,UserId) Values(@Name,@Email,@Phone,@UserId)";
                connection.Execute(query, item);
            }
        }

        public void Delete(int id, string userId)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Friends WHERE Id=@id AND UserId=@userId";
                connection.Execute(query, new { id, userId });
            }
        }

        public Friend Get(int id, string userId)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Friends WHERE Id=@id AND UserId=@userId";
                return connection.Query<Friend>(query, new { id, userId }).FirstOrDefault();
            }
        }

        public IEnumerable<Friend> GetAll(string userId)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Friends WHERE UserId=@userId";
                return connection.Query<Friend>(query, new { userId });
            }
        }

        public void Update(Friend item)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Friends SET Id = @Id, Name = @Name, Email = @Email, Phone = @Phone, UserId = @UserId WHERE Id = @Id AND UserId = @UserId";
                connection.Execute(query, item);
            }
        }
    }
}
