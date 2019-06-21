using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SocialService.ServiceLogic.Interfaces;
using SocialService.ServiceLogic.MappingProfiles;
using SocialService.ServiceLogic.Services;

namespace SocialService.ServiceLogic
{
    public class Startup
    {
        public static void Init(IServiceCollection services)
        {
            DataAccess.Startup.Init(services);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new FriendsMappingProfile());
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            services.AddTransient<IAccountService, AccountService>();
        }
    }


}
