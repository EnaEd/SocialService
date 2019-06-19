using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialService.ServiceLogic.DependensyInjection;
using SocialService.ServiceLogic.Interfaces;
using SocialService.ServiceLogic.Services;
using SocialService.Web.EF;
using SocialService.Web.Models;
using System.Web.Mvc;

namespace SocialService.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>();

            services.AddTransient<IFriendService, FriendService>();
            Dependency.CreateDependecy(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //NinjectModule orderModule = new FriendModule();
            //NinjectModule serviceModule = new ServiceModule("DefaultConnection");
            //var kernel = new StandardKernel(orderModule, serviceModule);
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
