using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SocialService.DataAccess.Entities;

namespace SocialService.DataAccess.EF
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        private IConfiguration _configuration;
        public DbSet<Friend> Friends { get; set; }
        public ApplicationContext(IConfiguration configuration)
        {
            _configuration = configuration;
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
