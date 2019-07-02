using Microsoft.AspNetCore.Identity;
using SocialService.DataAccess.Entities;
using System.Collections.Generic;

namespace SocialService.ServiceLogic.ViewModels
{
    public class UserView
    {
        public UserView(User obj)
        {
            UserId = obj.Id;
            UserEmail = obj.Email;
            Name = obj.UserName;
        }
        public UserView()
        {
            AllRoles = new List<IdentityRole>();
            UserRoles = new List<string>();
        }
        public string Name { get; set; }
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public List<IdentityRole> AllRoles { get; set; }
        public IList<string> UserRoles { get; set; }
    }
}
