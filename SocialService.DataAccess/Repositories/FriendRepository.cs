using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialService.DataAccess.Repositories
{
    public class FriendRepository : BaseRepository<Friend>, IRepository<Friend>
    {
        public FriendRepository() : base()
        {

        }
        public void Delete(int id)
        {
            Friend friend = _context.Friends.Find(id);
            if (friend != null)
            {
                _dbSet.Remove(friend);
                _context.SaveChanges();
            }
        }

        IEnumerable<Friend> IRepository<Friend>.GetAll()
        {
            return _dbSet;
        }

        Friend IRepository<Friend>.Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<Friend> Find(Func<Friend, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public void Create(Friend item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public void Update(Friend item)
        {

            Friend friend = _dbSet.FirstOrDefault(x => x.Id == item.Id);
            if (friend != null)
            {
                friend.Name = item.Name;
                friend.Email = item.Email;
                friend.Phone = item.Phone;
                _context.SaveChanges();
            }
        }
    }
}
