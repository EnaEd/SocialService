using Microsoft.AspNet.Identity.EntityFramework;
using SocialService.DataAccess.Entities;
using System.Data.Entity;

namespace SocialService.DataAccess.EntityFramework
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<ClientProfile> ClientProfile { get; set; }

    }
}
