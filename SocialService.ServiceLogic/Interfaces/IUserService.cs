using SocialService.ServiceLogic.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SocialService.ServiceLogic.Interfaces
{
    public interface IUserService
    {
        List<UserView> GetUsers();
        Task<UserView> GetUserModel(ClaimsPrincipal userCurrent);
        Task Delete(string id);
        Task Edit(string id, List<string> roles);
    }
}
