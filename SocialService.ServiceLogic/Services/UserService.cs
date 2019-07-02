using Microsoft.AspNetCore.Identity;
using SocialService.DataAccess.Entities;
using SocialService.ServiceLogic.Interfaces;
using SocialService.ServiceLogic.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SocialService.ServiceLogic.Services
{
    public class UserService : IUserService
    {
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public UserService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public List<UserView> GetUsers()
        {
            List<UserView> users =_userManager.Users.Select(x => new UserView(x)).ToList();
            return users;
        }
        public async Task<UserView> GetUserModel(ClaimsPrincipal userCurrent)
        {
            User user = await _userManager.FindByEmailAsync(userCurrent.Identity.Name);
            var userRoles = await _userManager.GetRolesAsync(user);
            var allRoles = _roleManager.Roles.ToList();
            UserView model = new UserView
            {
                UserId = user.Id,
                UserEmail = user.Email,
                UserRoles = userRoles,
                AllRoles = allRoles
            };
            return model;
        }
    }
}
