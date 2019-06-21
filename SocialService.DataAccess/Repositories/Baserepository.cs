using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SocialService.DataAccess.EF;

namespace SocialService.DataAccess.Repositories
{
    public class BaseRepository<T> where T : class
    {
        protected ApplicationContext _context;
        protected DbSet<T> _dbSet;
        protected bool _disposed = false;


        public BaseRepository(IConfiguration configuration)
        {
            _context = new ApplicationContext(configuration );
            _dbSet = _context.Set<T>();
        }
    }
}
