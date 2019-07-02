using AutoMapper;
using Microsoft.Extensions.Configuration;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using SocialService.DataAccess.Repositories;
using SocialService.ServiceLogic.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SocialService.ServiceLogic.Services
{
    public class FriendService : BaseService
    {
        private IRepository<Friend> _friendRepository;
        private IDapperRepository<Friend> _friendDapperRepository;
        private IRepository<FriendsOfFriends> _friendsOfFriendsrepository;
        public FriendService(IConfiguration configuration,IMapper mapper) : base(mapper)
        {
            _friendRepository = new FriendRepository(configuration);
            _friendDapperRepository = new FriendDapperRepository(configuration);
            _friendsOfFriendsrepository = new FriendsOfFriendsRepository(configuration);
        }
        public void Delete(int id, string userId)
        {
            Friend friend = _friendRepository.GetAll().FirstOrDefault(x=>x.Id==id && x.UserId==userId);
            _friendRepository.Delete(friend);
        }

        public IEnumerable<FriendsView> GetAll(string userId)
        {
            //Use Dapper instead of EF
            IEnumerable<FriendsView> result = _mapper.Map<IEnumerable<FriendsView>>(_friendDapperRepository.GetAll(userId));
            //var result = _mapper.Map<IEnumerable<FriendsView>>(_friendRepository.GetAll());
            //List<Friend> resultFriend = new List<Friend>();
            //IList<int> ids = _friendsOfFriendsrepository.GetAll().Where(x => x.UserId == userId).Select(x => x.FriendId).ToList();
            //foreach (var item in ids)
            //{
            //    if (item != default(int))
            //    {
            //        resultFriend.Add(_friendRepository.GetById(item));
            //    }
            //}
            //IEnumerable<FriendsView> result = _mapper.Map<IEnumerable<FriendsView>>(resultFriend as IEnumerable<Friend>);
            return result;
        }

        public void Create(FriendsView item)
        {
            Friend friend = _mapper.Map<Friend>(item);
            //TODO check if friend exist
            Friend friendEx=_friendRepository.GetAll().FirstOrDefault(x => x.Name == friend.Name && x.Phone == friend.Phone && x.Email == friend.Email);
            if (friendEx is null)
            {
                _friendRepository.Create(friend);
                _friendsOfFriendsrepository.Create(new FriendsOfFriends { FriendId = friend.Id, UserId = friend.UserId });
                return;
            }
            if (friendEx.UserId!=friend.UserId)
            {
                _friendsOfFriendsrepository.Create(new FriendsOfFriends { FriendId = friendEx.Id, UserId = friend.UserId });
            }
        }

        public void Update(FriendsView item)
        {
            Friend friend = _mapper.Map<Friend>(item);
            _friendRepository.Update(friend);
        }
    }
}
