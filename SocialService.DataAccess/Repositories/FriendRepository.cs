using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SocialService.DataAccess.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            string command = "SELECT Friends.Id,Friends.Name,Friends.Phone,Friends.Email " +
                                       "FROM FriendsOfFriends JOIN Friends " +
                                       "ON FriendsOfFriends.FriendId = Friends.Id " +
                                       "WHERE FriendsOfFriends.UserId=@userId";
            SqlParameter parameterS = new SqlParameter("@userId", userId);
            var temp = _dbSet.FromSql(command, parameterS).ToList();
            return temp;

        }
        public override void Update(Friend item)
        {
            Friend friend = _dbSet.FirstOrDefault(x => x.Id == item.Id);
            if (friend != null)
            {
                friend.Name = item.Name;
                friend.Email = item.Email;
                friend.Phone = item.Phone;
                base.Update(friend);
            }
        }
    }
}
