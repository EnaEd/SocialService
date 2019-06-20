using Microsoft.EntityFrameworkCore;
using SocialService.DataAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialService.DataAccess.Repositories
{
    public class BaseRepository<T> where T : class
    {
        protected FriendContext _context;
        protected DbSet<T> _dbSet;
        protected bool _disposed = false;


        public BaseRepository(string connectionString)
        {
            _context = new FriendContext(connectionString);
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> GetItems()
        {
            return _dbSet;
        }

        public T FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(T item)
        {
            _dbSet.Add(item);
            SaveChanges();
        }
        public void Insert(List<T> item)
        {
            _dbSet.AddRange(item);
            SaveChanges();
        }
        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            SaveChanges();
        }
        public void Remove(T item)
        {
            _dbSet.Remove(item);
            SaveChanges();
        }
        public void Remove(List<T> item)
        {
            _dbSet.RemoveRange(item);
            SaveChanges();
        }
        public void Remove(int id)
        {
            var entity = FindById(id);
            Remove(entity);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
