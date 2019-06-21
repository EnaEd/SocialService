using Microsoft.AspNetCore.Identity;
using SocialService.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialService.ServiceLogic.Interfaces
{
    public interface IAccountService
    {
        UserManager<User> UserManager { get; }
        SignInManager<User> SignInManager { get; }
    }
}
