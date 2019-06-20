using System;
using System.Collections.Generic;

namespace SocialService.DataAccess.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(int userId);
        T Get(int id,int userId);
        void Create(T item);
        void Update(T item);
        void Delete(int id,int userId);
    }
}
