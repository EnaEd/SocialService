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
        private List<Friend> _friends;

        public FriendService(IConfiguration configuration,IMapper mapper) : base(mapper)
        {
            _friendRepository = new FriendRepository(configuration);
            _friendDapperRepository = new FriendDapperRepository(configuration);
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
            return result;
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
