using SocialService.DataAccess.EF;

namespace SocialService.ServiceLogic.API
{
    public class BaseService
    {
        protected FriendContext _context;
        public BaseService()
        {
            _context = new FriendContext();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}