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

        IEnumerable<Friend> IRepository<Friend>.GetAll(int userId)
        {
            return _context.Friends.Select(x=>x).Where(x=>x.UserId==userId);
        }

        Friend IRepository<Friend>.Get(int id,int userId)
        {
            return _context.Friends.Where(x => x.UserId == userId && x.Id == id).FirstOrDefault();
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
        public void Delete(int id,int userId)
        {
            Friend friend = _context.Friends.Where(x=>x.Id==id&&x.UserId==userId).FirstOrDefault();
            if (friend != null)
            {
                _context.Friends.Remove(friend);
                _context.SaveChanges();
            }
        }
        
    }
}
