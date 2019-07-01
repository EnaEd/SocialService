using Microsoft.Extensions.Configuration;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SocialService.DataAccess.Repositories
{
    public class FriendRepository : BaseRepository<Friend>, IRepository<Friend>
    {
        public FriendRepository(IConfiguration configuration) : base(configuration)
        {

        }

        IEnumerable<Friend> IRepository<Friend>.GetAll(string userId)
        {
            return _dbSet.Where(x => x.UserId == userId).ToList();
        }

        Friend IRepository<Friend>.Get(int id, string userId)
        {
            Friend friend = _dbSet.FirstOrDefault(x => x.Id == id && x.UserId == userId);
            return _dbSet.Find(id);
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
        public void Delete(int id, string userId)
        {
            Friend friend = _dbSet.FirstOrDefault(x => x.Id == id && x.UserId == userId);
            if (friend != null)
            {
                _dbSet.Remove(friend);
                _context.SaveChanges();
            }
        }
    }
}
