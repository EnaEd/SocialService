using Microsoft.EntityFrameworkCore;
using SocialService.DataAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialService.DataAccess.Repositories
{
    public class BaseRepository<T> where T : class
    {
        protected ApplicationContext _context;
        protected DbSet<T> _dbSet;
        protected bool _disposed = false;


        public BaseRepository()
        {
            _context = new ApplicationContext();
            _dbSet = _context.Set<T>();
        }
    }
}
