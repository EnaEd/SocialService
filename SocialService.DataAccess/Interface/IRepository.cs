using System;
using System.Collections.Generic;

namespace SocialService.DataAccess.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string userId);
        T Get(int id, string userId);
        void Create(T item);
        void Update(T item);
        void Delete(int id, string userId);
    }
}
