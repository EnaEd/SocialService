using System;
using Microsoft.Extensions.DependencyInjection;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using SocialService.DataAccess.Repositories;

namespace SocialService.ServiceLogic.DependensyInjection
{
    public static class Dependency
    {
        
        public static void CreateDependecy(IServiceCollection services)
        {
            services.AddTransient<IRepository<Friend>, FriendRepository>();
        }
    }
}
