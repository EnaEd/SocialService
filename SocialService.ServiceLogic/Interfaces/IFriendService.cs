using SocialService.ServiceLogic.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialService.ServiceLogic.Interfaces
{
    public interface IFriendService
    {
        FriendDTO GetFriend(int? id);
        IEnumerable<FriendDTO> GetFriends();
        void Dispose();
    }
}
