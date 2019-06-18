using SocialService.DataAccess.Identity;
using System;
using System.Threading.Tasks;

namespace SocialService.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationRoleManager ApplicationRole { get; }
        ApplicationUserManager ApplicationUser { get; }
        IClientManager ClientProfile { get; }
        Task SaveAsync();
    }
}
