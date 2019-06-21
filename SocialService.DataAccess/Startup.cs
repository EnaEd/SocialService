﻿using Microsoft.AspNetCore.Identity;
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

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>();
        }
    }

}