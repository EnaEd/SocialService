using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace SocialService.ServiceLogic
{
    public  class Startup
    {
        public static void Init(IServiceCollection services)
        {
            DataAccess.Startup.Init(services);
        }
    }

    
}
