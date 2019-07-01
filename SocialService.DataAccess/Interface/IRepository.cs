using System;
using System.Collections.Generic;

namespace SocialService.DataAccess.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Create(T item);
        void Update(T item);
        void Delete(T item);
    }
}
