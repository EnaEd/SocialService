using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using SocialService.DataAccess.Repositories;
using SocialService.ServiceLogic.Interfaces;
using SocialService.ServiceLogic.MappingProfiles;
using SocialService.ServiceLogic.Services;

namespace SocialService.ServiceLogic
{
    public class Startup
    {
        public static void Init(IServiceCollection services,IConfiguration configuration)
        {
            DataAccess.Startup.Init(services, configuration);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new FriendsMappingProfile());
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            services.AddTransient<IAccountService, AccountService>();
            services.AddHttpContextAccessor();
        }
    }


}
