using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialService.DataAccess.Entities;

namespace SocialService.DataAccess.EF
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Friend> Friends { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
