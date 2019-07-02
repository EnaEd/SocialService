using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SocialService.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SocialService.DataAccess.Repositories
{
    public class FriendRepository : BaseRepository<Friend>
    {
        public FriendRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public List<Friend> GetFriendByUser(string userId)
        {
            //_context.Friends.Fro
            var temp = _dbSet.FromSql("SELECT Friends.Id,Friends.Name,Friends.Phone,Friends.Email, Friends.UserId "+
                                       "FROM FriendsOfFriends JOIN Friends "+
                                       "ON FriendsOfFriends.FriendId = Friends.Id").ToList();
            return temp;

        }
    }
}
