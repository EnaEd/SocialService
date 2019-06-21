using Microsoft.AspNetCore.Identity;
using SocialService.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialService.ServiceLogic.Services
{
    public class AccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountService()
        {

        }
    }
}
