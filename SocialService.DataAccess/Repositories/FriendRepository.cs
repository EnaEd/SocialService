using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialService.DataAccess.Repositories
{
    public class FriendRepository : BaseRepository<Friend>, IRepository<Friend>
    {
        public FriendRepository(string connectionString) : base(connectionString)
        {

        }
        public void Delete(int id)
        {
            Friend friend = _context.Friends.Find(id);
            if (friend != null)
            {
                _context.Friends.Remove(friend);
                _context.SaveChanges();
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
            _context.SaveChanges();
        }

        public void Update(Friend item)
        {

            Friend friend = _context.Friends.FirstOrDefault(x => x.Id == item.Id);
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
