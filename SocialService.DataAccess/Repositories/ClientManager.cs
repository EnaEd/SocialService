using SocialService.DataAccess.Entities;
using SocialService.DataAccess.EntityFramework;
using SocialService.DataAccess.Interfaces;

namespace SocialService.DataAccess.Repositories
{
    public class ClientManager : IClientManager
    {
        ApplicationContext DataBase { get; set; }

        public ClientManager(ApplicationContext context)
        {
            DataBase = context;
        }
        public void Create(ClientProfile profile)
        {
            DataBase.ClientProfile.Add(profile);
            DataBase.SaveChanges();
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}
