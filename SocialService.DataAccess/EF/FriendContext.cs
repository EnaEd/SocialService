using Microsoft.EntityFrameworkCore;
using SocialService.DataAccess.Entities;

namespace SocialService.DataAccess.EF
{
    public class FriendContext : DbContext
    {
        private string _connectionString;
        public DbSet<Friend> Friends { get; set; }

        public FriendContext(string connectionString)
        {
            _connectionString = connectionString;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
