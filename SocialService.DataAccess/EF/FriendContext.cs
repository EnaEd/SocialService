using Microsoft.EntityFrameworkCore;
using SocialService.DataAccess.Entities;

namespace SocialService.DataAccess.EF
{
    public class FriendContext:DbContext
    {
        public DbSet<Friend> Friends { get; set; }

        public FriendContext()
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }
    }
}
