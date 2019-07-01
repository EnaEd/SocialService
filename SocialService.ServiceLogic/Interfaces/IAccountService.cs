using Microsoft.AspNetCore.Identity;
using SocialService.ServiceLogic.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialService.ServiceLogic.Interfaces
{
    public interface IAccountService
    {
        Task<bool> OnLogin(LoginView loginViewModel);
        Task<bool> OnReigstration(RegisterView registerViewModel, List<IdentityError> errors);
        Task OnLogout();
    }
}
