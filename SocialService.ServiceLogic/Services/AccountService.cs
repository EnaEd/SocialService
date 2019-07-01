using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using SocialService.ServiceLogic.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using SocialService.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using SocialService.ServiceLogic.ViewModels;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace SocialService.ServiceLogic.Services
{
    public class AccountService : IAccountService
    {
        private IConfiguration _configuration;
        private IMapper _mapper;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public AccountService(IConfiguration configuration, IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _configuration = configuration;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> OnLogin(LoginViewModel loginViewModel)
        {
            return false;
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

        public void OnLogout()
        {
        }
    }
}
