using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SocialService.DataAccess.EF;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using SocialService.DataAccess.Entities;
using Microsoft.Extensions.Configuration;

namespace SocialService.DataAccess.DependencyInjection
{
    public static class DependencyDAL
    {
        public static void CreateDependecy(IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDBContext>();
        }
    }
}
