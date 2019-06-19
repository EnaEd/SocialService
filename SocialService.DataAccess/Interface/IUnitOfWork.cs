using SocialService.DataAccess.Entities;
using System;

namespace SocialService.DataAccess.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Friend> Friends { get; }
        void Save();
    }
}
