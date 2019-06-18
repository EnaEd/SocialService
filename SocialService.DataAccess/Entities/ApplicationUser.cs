using Microsoft.AspNet.Identity.EntityFramework;

namespace SocialService.DataAccess.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}
