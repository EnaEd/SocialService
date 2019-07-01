using Microsoft.Extensions.Configuration;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SocialService.DataAccess.Repositories
{
    public class FriendRepository : BaseRepository<Friend>
    {
        public FriendRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
