using Microsoft.AspNetCore.Identity;
using SocialService.DataAccess.Entities;
using SocialService.ServiceLogic.Interfaces;

namespace SocialService.ServiceLogic.Services
{
    public class AccountService : IAccountService
    {
        //private readonly UserManager<User> _userManager;
        //private readonly SignInManager<User> _signInManager;

        public AccountService()
        {
            //_userManager = userManager;
            //_signInManager = signInManager;
        }

        //public UserManager<User> UserManager { get => _userManager; }
        //public SignInManager<User> SignInManager { get => _signInManager; }
    }
}
