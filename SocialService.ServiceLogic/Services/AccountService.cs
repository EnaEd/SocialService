using SocialService.ServiceLogic.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialService.DataAccess.Entities;
using SocialService.ServiceLogic.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace SocialService.ServiceLogic.Services
{
    public class AccountService : IAccountService
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> OnLogin(LoginViewModel loginViewModel)
        {
            SignInResult result =
            await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, false);
            if (!result.Succeeded)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> OnReigstration(RegisterViewModel registerViewModel, List<IdentityError> errors)
        {
            User user = new User { Email = registerViewModel.Email, UserName = registerViewModel.Email };
            var result = await _userManager.CreateAsync(user, registerViewModel.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    errors.Add(item);
                }
                return false;
            }

            await _signInManager.SignInAsync(user, false);
            return true;
        }

        public async Task OnLogout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
