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

namespace SocialService.ServiceLogic.Services
{
    public class AccountService : IAccountService
    {
        private HttpContext _context;
        private IConfiguration _configuration;
        private IDapperRepository<User> _userRepository;
        private IMapper _mapper;
        public AccountService(IHttpContextAccessor accessor, IConfiguration configuration, IMapper mapper)
        {
            _context = accessor.HttpContext;
            _configuration = configuration;
            _userRepository = new UserDapperRepository(_configuration);
            _mapper = mapper;
        }

        public async Task<bool> OnLogin(LoginViewModel loginViewModel)
        {
            User user = _userRepository.GetAll(null).FirstOrDefault(u => u.Email == loginViewModel.Email && u.Password == loginViewModel.Password);
            if (user != null)
            {
                await Authenticate(loginViewModel.Email);
                return true;
            }
            return false;
        }

        public async Task<bool> OnReigstration(RegisterViewModel registerViewModel)
        {
            User user = new User { Email = registerViewModel.Email, Password = registerViewModel.Password };
            if (user.Email != null && user.Password != null)
            {
                _userRepository.Create(user);
               await Authenticate(registerViewModel.Email);
                return true;
            }
            return false;
        }

        private async Task Authenticate(string userName)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await _context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public void OnLogout()
        {
            _context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
