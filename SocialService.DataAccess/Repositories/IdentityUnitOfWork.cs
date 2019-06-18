using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using SocialService.DataAccess.EntityFramework;
using SocialService.DataAccess.Identity;
using SocialService.DataAccess.Interfaces;

namespace SocialService.DataAccess.Repositories
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        private ApplicationContext _context;
        private ApplicationRoleManager _roleManager;
        private ApplicationUserManager _userManager;
        private IClientManager _clientManager;
        private bool _disposed;

        public IdentityUnitOfWork(string connectionString)
        {
            _context = new ApplicationContext(connectionString);
            _roleManager = new ApplicationRoleManager(new RoleStore<Entities.ApplicationRole>(_context));
            _userManager = new ApplicationUserManager(new UserStore<Entities.ApplicationUser>(_context));
            _clientManager = new ClientManager(_context);
            _disposed = false;
        }

        public ApplicationRoleManager ApplicationRole => _roleManager;

        public ApplicationUserManager ApplicationUser => _userManager;

        public IClientManager ClientProfile => _clientManager;

        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            if (disposing)
            {
                _userManager.Dispose();
                _roleManager.Dispose();
                _clientManager.Dispose();
            }
            _disposed = true;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
