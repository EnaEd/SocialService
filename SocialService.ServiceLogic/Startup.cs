using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SocialService.ServiceLogic
{
    public  class Startup
    {
        public static void Init(IServiceCollection services,IConfiguration configuration)
        {
            DataAccess.Startup.Init(services,configuration);
        }
    }

    
}
