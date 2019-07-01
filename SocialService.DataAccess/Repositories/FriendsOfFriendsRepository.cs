using Microsoft.Extensions.Configuration;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;

namespace SocialService.DataAccess.Repositories
{
    public class FriendsOfFriendsRepository : BaseRepository<FriendsOfFriendsRepository>
    {
        private IRepository<Friend> _friendRepository;
        public FriendsOfFriendsRepository(IConfiguration configuration) : base(configuration)
        {
            _friendRepository = new FriendRepository(configuration);
        }

    }
}
