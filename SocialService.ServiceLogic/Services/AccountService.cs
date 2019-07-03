using SocialService.ServiceLogic.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialService.DataAccess.Entities;
using SocialService.ServiceLogic.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace SocialService.ServiceLogic.Services
{
    public class AccountService : IAccountService
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private IConfiguration _configuration;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager,IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<bool> OnLogin(LoginView loginViewModel)
        {
            SignInResult result =
            await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, false);
            return result.Succeeded;
        }

        public async Task<bool> OnReigstration(RegisterView registerViewModel, List<IdentityError> errors)
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
            await _userManager.AddToRoleAsync(user, _configuration["Roles:User"]);
            await _signInManager.SignInAsync(user, false);
            return true;
        }

        public async Task OnLogout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
