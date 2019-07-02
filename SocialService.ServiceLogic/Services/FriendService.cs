using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using SocialService.DataAccess.Repositories;
using SocialService.ServiceLogic.Interfaces;
using SocialService.ServiceLogic.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace SocialService.ServiceLogic.Services
{
    public class FriendService : BaseService
    {
        private FriendRepository _friendRepository;
        private FriendDapperRepository _friendDapperRepository;
        private FriendsOfFriendsRepository _friendsOfFriendsrepository;
        public FriendService(IConfiguration configuration,IMapper mapper) : base(mapper)
        {
            _friendRepository = new FriendRepository(configuration);
            _friendDapperRepository = new FriendDapperRepository(configuration);
            _friendsOfFriendsrepository = new FriendsOfFriendsRepository(configuration);
        }
        public void Delete(int id, string userId)
        {
            Friend friend = _friendRepository.GetAll().FirstOrDefault(x=>x.Id==id);
            if (friend is null)
            {
                return;
            }
            _friendRepository.Delete(friend);
            List<FriendsOfFriends> friendsIdList= _friendsOfFriendsrepository.GetAll()
                                        .Where(x => x.FriendId == friend.Id).ToList();
            _friendsOfFriendsrepository.DeleteRange(friendsIdList);
        }

        public IEnumerable<FriendsView> GetAll(string userId)
        {
            //Use Dapper instead of EF
            //IEnumerable<FriendsView> result = _mapper.Map<IEnumerable<FriendsView>>(_friendDapperRepository.GetAll(userId));
            IEnumerable<FriendsView> result = _mapper.Map<List<FriendsView>>(_friendRepository.GetFriendByUser(userId));
            return result;
        }

        public void Create(FriendsView item,string userId)
        {
            Friend friend = _mapper.Map<Friend>(item);
            if (true)
            {

            }
            //TODO check if friend exist
            Friend friendEx=_friendRepository.GetAll().FirstOrDefault(x => x.Name == friend.Name && x.Phone == friend.Phone && x.Email == friend.Email);
            if (friendEx is null)
            {
                _friendRepository.Create(friend);
                _friendsOfFriendsrepository.Create(new FriendsOfFriends { FriendId = friend.Id, UserId = userId });
                return;
            }
            FriendsOfFriends friendOfFriend = _friendsOfFriendsrepository.GetAll().FirstOrDefault(x => x.FriendId == friendEx.Id && x.UserId == userId);
            if (friendOfFriend is null)
            {
                _friendsOfFriendsrepository.Create(new FriendsOfFriends { FriendId = friendEx.Id, UserId = userId });
            }
        }

        public void Update(FriendsView item)
        {
            Friend friend = _mapper.Map<Friend>(item);
            _friendRepository.Update(friend);
        }
    }
}
