using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SocialService.DataAccess.Entities;

using System;

namespace SocialService.DataAccess.EF
{
    public class ApplicationContext : DbContext
    {
        private IConfiguration _configuration;
        public DbSet<Friend> Friends { get; set; }
        public DbSet<User> Users { get; set; }
        public ApplicationContext(IConfiguration configuration)
        {
            _configuration = configuration;
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //IConfiguration configuration = new ConfigurationBuilder()
            //.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            //.AddJsonFile("appsettings.json")
            //.Build();
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
