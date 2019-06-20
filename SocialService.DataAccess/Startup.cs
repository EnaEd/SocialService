using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialService.DataAccess.EF;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using SocialService.DataAccess.Repositories;

namespace SocialService.DataAccess
{
    public class Startup
    {
        public static void Init(IServiceCollection services, IConfiguration configuration )
        {
            services.AddTransient<IRepository<Friend>, FriendRepository>();
            services.AddScoped<ApplicationContext, ApplicationContext>();
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>();
        }
    }

}
