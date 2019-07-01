using AutoMapper;
using Microsoft.Extensions.Configuration;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using SocialService.DataAccess.Repositories;
using SocialService.ServiceLogic.ViewModels;
using System.Collections.Generic;

namespace SocialService.ServiceLogic.Services
{
    public class FriendService : BaseService
    {
        private IRepository<Friend> _friendRepository;
        private IDapperRepository<Friend> _friendDapperRepository;

        public FriendService(IConfiguration configuration,IMapper mapper) : base(mapper)
        {
            _friendRepository = new FriendRepository(configuration);
            _friendDapperRepository = new FriendDapperRepository(configuration);
        }
        public void Delete(int id, string userId)
        {
            _friendRepository.Delete(id, userId);
        }

        public IEnumerable<FriendsView> GetAll(string userId)
        {
            //Use Dapper instead of EF
            IEnumerable<FriendsView> result = _mapper.Map<IEnumerable<FriendsView>>(_friendDapperRepository.GetAll(userId));
            return result;
        }

        public FriendsView Get(int id, string userId)
        {

            FriendsView friend = _mapper.Map<FriendsView>(_friendRepository.Get(id, userId));
            return friend;
        }

        public void Create(FriendsView item)
        {
            Friend friend = _mapper.Map<Friend>(item);
            _friendRepository.Create(friend);
        }

        public void Update(FriendsView item)
        {
            Friend friend = _mapper.Map<Friend>(item);
            _friendRepository.Update(friend);
        }
    }
}
