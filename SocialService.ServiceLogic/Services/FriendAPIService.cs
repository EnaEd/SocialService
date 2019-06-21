using AutoMapper;
using Microsoft.Extensions.Configuration;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using SocialService.DataAccess.Repositories;
using SocialService.ServiceLogic.ViewModels;
using System.Collections.Generic;

namespace SocialService.ServiceLogic.Services
{
    public class FriendAPIService : BaseAPIService
    {
        private IRepository<Friend> _friendRepository;
        private IDapperRepository<Friend> _friendDapperRepository;

        public FriendAPIService(IConfiguration configuration,IMapper mapper) : base(mapper)
        {
            _friendRepository = new FriendRepository(configuration);
            _friendDapperRepository = new FriendDapperRepository(configuration);
        }
        public void Delete(int id, string userId)
        {
            _friendRepository.Delete(id, userId);
        }

        public IEnumerable<FriendsViewModel> GetAll(string userId)
        {
            //Use Dapper instead of EF
            IEnumerable<FriendsViewModel> result = _mapper.Map<IEnumerable<FriendsViewModel>>(_friendDapperRepository.GetAll(userId));
            return result;
        }

        public FriendsViewModel Get(int id, string userId)
        {

            FriendsViewModel friend = _mapper.Map<FriendsViewModel>(_friendRepository.Get(id, userId));
            return friend;
        }

        public void Create(FriendsViewModel item)
        {
            Friend friend = _mapper.Map<Friend>(item);
            _friendRepository.Create(friend);
        }

        public void Update(FriendsViewModel item)
        {
            Friend friend = _mapper.Map<Friend>(item);
            _friendRepository.Update(friend);
        }
    }
}
