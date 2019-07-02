using Microsoft.AspNetCore.Identity;
using SocialService.DataAccess.Entities;
using SocialService.ServiceLogic.Interfaces;
using SocialService.ServiceLogic.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SocialService.ServiceLogic.Services
{
    public class UserService : IUserService
    {
        private UserManager<User> _userManager;
        //private RoleManager<User> _roleManager;

        public UserService(UserManager<User> userManager/*, RoleManager<User> roleManager*/)
        {
            _userManager = userManager;
            //_roleManager = roleManager;
        }

        public List<UserView> GetUsers()
        {
            List<UserView> users =_userManager.Users.Select(x => new UserView(x)).ToList();
            return users;
        }
    }
}
