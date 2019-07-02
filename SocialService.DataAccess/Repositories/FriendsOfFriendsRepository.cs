using Microsoft.Extensions.Configuration;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using System.Collections.Generic;

namespace SocialService.DataAccess.Repositories
{
    public class FriendsOfFriendsRepository : BaseRepository<FriendsOfFriends>
    {
        //private IRepository<Friend> _friendRepository;
        public FriendsOfFriendsRepository(IConfiguration configuration) : base(configuration)
        {
            //_friendRepository = new FriendRepository(configuration);
        }
        public void DeleteRange(List<FriendsOfFriends> friendsIdList)
        {
            _dbSet.RemoveRange(friendsIdList);
            _context.SaveChanges();
        }

    }
}
