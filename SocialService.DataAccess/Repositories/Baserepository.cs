using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SocialService.DataAccess.EF;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;

namespace SocialService.DataAccess.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected ApplicationContext _context;
        protected DbSet<T> _dbSet;
        protected bool _disposed = false;


        public BaseRepository(IConfiguration configuration)
        {
            _context = new ApplicationContext(configuration);
            _dbSet = _context.Set<T>();
        }

        public virtual void Create(T item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public virtual void Delete(T item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public T GetById(int Id)
        {
            var t= _dbSet.Find(Id);
            return t;
        }
        public virtual void Update(T item)
        {
            _dbSet.Update(item);
            _context.SaveChanges();
        }
    }
}
