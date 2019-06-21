using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SocialService.DataAccess.EF;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using SocialService.DataAccess.Repositories;

namespace SocialService.DataAccess
{
    public class Startup
    {
        public static void Init(IServiceCollection services)
        {
            services.AddTransient<IRepository<Friend>, FriendRepository>();
            services.AddTransient<IDapperRepository<Friend>, FriendDapperRepository>();

            services.AddScoped<ApplicationContext, ApplicationContext>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options => 
                {
                   options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
               });
        }
    }

}
