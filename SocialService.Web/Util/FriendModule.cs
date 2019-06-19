using Ninject.Modules;
using SocialService.ServiceLogic.Interfaces;
using SocialService.ServiceLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialService.Web.Util
{
    public class FriendModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IFriendService>().To<FriendService>();
        }
    }
}
