using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Repositories;
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
        private FriendsOfFriendsRepository _friendsOfFriendsRepository;

        public UserService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _friendsOfFriendsRepository = new FriendsOfFriendsRepository(configuration);
        }

        public List<UserView> GetUsers()
        {
            List<UserView> users = _userManager.Users.Select(x => new UserView(x)).ToList();
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

        public async Task Delete(string id)
        {
            User user = await _userManager.FindByEmailAsync(id);
            if (user is null)
            {
                return;
            }
            List<FriendsOfFriends> friends = _friendsOfFriendsRepository.GetAll().Where(x => x.UserId == id).ToList();
            IdentityResult result = await _userManager.DeleteAsync(user);
            if (result.Errors?.Count() == default(int))
            {
                _friendsOfFriendsRepository.DeleteRange(friends);
            }
        }
        public async Task Edit(string id, List<string> roles)
        {
            User user = await _userManager.FindByEmailAsync(id);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                var addedRoles = roles.Except(userRoles);
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);

                await _userManager.RemoveFromRolesAsync(user, removedRoles);
            }

        }
    }
}
