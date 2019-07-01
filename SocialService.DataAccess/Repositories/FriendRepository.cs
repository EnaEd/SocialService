using Microsoft.Extensions.Configuration;
using SocialService.DataAccess.Entities;

namespace SocialService.DataAccess.Repositories
{
    public class FriendRepository : BaseRepository<Friend>
    {
        public FriendRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
