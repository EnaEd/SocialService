using SocialService.DataAccess.Entities;
using System;

namespace SocialService.DataAccess.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile profile);
    }
}
