using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.AspNet.Identity;
using SocialService.ServiceLogic.Services;
using SocialService.ServiceLogic.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SocialService.Web;
using SocialService.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;

[assembly: OwinStartup(typeof(Startup))]
namespace SocialService.Web
{
    public class Startup
    {
        IServiceCreator serviceCreator = new ServiceCreator();

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>();

            services.AddMvc();
        }
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService("DefaultConnection");
        }
    }
}
