using SocialService.DataAccess.EF;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SocialService.DataAccess.Repositories
{
    public class FriendRepository : IRepository<Friend>
    {
        private FriendContext _context;

        public FriendRepository()
        {
            _context = new FriendContext();
        }

        public void Delete(int id)
        {
            Friend friend = _context.Friends.Find(id);
            if (friend != null)
            {
                _context.Friends.Remove(friend);
            }
        }

        IEnumerable<Friend> IRepository<Friend>.GetAll()
        {
            return _context.Friends;
        }

        Friend IRepository<Friend>.Get(int id)
        {
            return _context.Friends.Find(id);
        }

        public IEnumerable<Friend> Find(Func<Friend, bool> predicate)
        {
            return _context.Friends.Where(predicate).ToList();
        }

        public void Create(Friend item)
        {
            _context.Friends.Add(item);
        }

        public void Update(Friend item)
        {
            _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
