using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SocialService.DataAccess.Entities;

using System;

namespace SocialService.DataAccess.EF
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        private string _connectionString;
        public DbSet<Friend> Friends { get; set; }
        public ApplicationContext()
        {

            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            var str = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(ConfigurationExtensions.GetConnectionString(configuration, "DefaultConnection"));
        }
    }
}
