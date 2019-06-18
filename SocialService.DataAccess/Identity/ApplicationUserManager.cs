using Microsoft.AspNet.Identity;
using SocialService.DataAccess.Entities;

namespace SocialService.DataAccess.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {

        }
    }
}
