using Microsoft.AspNetCore.Identity;
using SocialService.DataAccess.Entities;
using SocialService.ServiceLogic.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialService.ServiceLogic.Interfaces
{
    public interface IAccountService
    {
        Task<bool> OnLogin(LoginViewModel loginViewModel);
        Task<bool> OnReigstration(RegisterViewModel registerViewModel, List<IdentityError> errors);
        void OnLogout();
    }
}
