using SocialService.DataAccess.EF;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialService.DataAccess.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private FriendContext _context;
        private FriendRepository _friendRepository;
        private bool _disposed;
        private string _connectionString;
        public EFUnitOfWork()
        {
            _context = new FriendContext();
            _disposed = false;
        }
        public IRepository<Friend> Friends
        {
            get
            {
                if (_friendRepository is null)
                {
                    _friendRepository = new FriendRepository(_context);
                }
                return _friendRepository;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
