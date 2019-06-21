using Microsoft.AspNetCore.Identity;
using SocialService.DataAccess.Entities;

namespace SocialService.ServiceLogic.Interfaces
{
    public interface IAccountService
    {
        UserManager<User> UserManager { get; }
        SignInManager<User> SignInManager { get; }
    }
}
