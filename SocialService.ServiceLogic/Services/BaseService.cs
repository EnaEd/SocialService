using SocialService.DataAccess.EF;

namespace SocialService.ServiceLogic.Services
{
    public class BaseService
    {
        protected ApplicationContext _context;
        public BaseService()
        {
            _context = new ApplicationContext();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}