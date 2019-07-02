using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SocialService.DataAccess.EF;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using SocialService.DataAccess.Repositories;
using SocialService.DataAccess.Service;
using System;
using System.Text;

namespace SocialService.DataAccess
{
    public class Startup
    {
        public static void Init(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IRepository<Friend>, FriendRepository>();
            services.AddTransient<IDapperRepository<Friend>, FriendDapperRepository>();

            services.AddScoped<ApplicationContext, ApplicationContext>();


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.Cookie.Name = "YourAppCookieName";
                    options.Cookie.Expiration = TimeSpan.FromDays(2);
                })
               .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = configuration["AuthOption:Issuer"],

                        ValidateAudience = true,
                        ValidAudience = configuration["AuthOption:Audience"],
                        ValidateLifetime = true,

                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["AuthOption:Key"])),
                        ValidateIssuerSigningKey = true,
                    };
                });

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>();
        }
    }

}
