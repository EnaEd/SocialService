﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialService.DataAccess.Entities;
using SocialService.ServiceLogic.Interfaces;
using SocialService.ServiceLogic.MappingProfiles;
using SocialService.ServiceLogic.Services;

namespace SocialService.ServiceLogic
{
    public  class Startup
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
