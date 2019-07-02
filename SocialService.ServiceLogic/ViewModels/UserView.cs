using SocialService.DataAccess.Entities;

namespace SocialService.ServiceLogic.ViewModels
{
    public class UserView
    {
        public UserView(User obj)
        {
            Id = obj.Id;
            Email = obj.Email;
            Name = obj.UserName;
        }
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
