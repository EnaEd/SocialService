using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialService.DataAccess.Entities;


namespace SocialService.DataAccess.EF
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {
        private string _connectionString;
        public DbSet<Friend> Friends { get; set; }

        public ApplicationDBContext(string connectionString)
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
