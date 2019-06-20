using SocialService.DataAccess.EF;

namespace SocialService.ServiceLogic.API
{
    public class BaseService
    {
        protected FriendContext _context;
        public BaseService(string connectionString)
        {
            _context = new FriendContext(connectionString);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}