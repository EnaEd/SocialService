using SocialService.ServiceLogic.ViewModels;
using System.Collections.Generic;

namespace SocialService.ServiceLogic.Interfaces
{
    public interface IUserService
    {
        List<UserView> GetUsers();
    }
}
