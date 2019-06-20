using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SocialService.DataAccess.DependencyInjection;
using SocialService.DataAccess.EF;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using SocialService.DataAccess.Repositories;
using SocialService.ServiceLogic.ViewModels;

namespace SocialService.ServiceLogic.DependensyInjection
{
    public static class Dependency
    {
        
        public static void CreateDependecy(IServiceCollection services)
        {
            services.AddTransient<IRepository<Friend>, FriendRepository>();
            DependencyDAL.CreateDependecy(services);
        }
    }
}
