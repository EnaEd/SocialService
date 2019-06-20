using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialService.DataAccess.EF;
using SocialService.DataAccess.Entities;

namespace SocialService.DataAccess
{
    public class Startup
    {
        public static void Init(IServiceCollection services, IConfiguration configuration )
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>();
        }
    }

}
