using AutoMapper;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using SocialService.DataAccess.Repositories;
using SocialService.ServiceLogic.ViewModels;
using System.Collections.Generic;

namespace SocialService.ServiceLogic.Services
{
    public class FriendAPIService : BaseService
    {
        private readonly IMapper _mapper;
        public IRepository<Friend> Database { get; set; }

        public FriendAPIService( IMapper mapper) : base()
        {
            Database = new FriendRepository();
            _mapper = mapper;
        }
        public void Delete(int id,string userId)
        {
            Database.Delete(id,userId);
        }

        public IEnumerable<FriendsViewModel> GetAll(string userId)
        {
            IEnumerable<FriendsViewModel> result = _mapper.Map<IEnumerable<FriendsViewModel>>(Database.GetAll(userId));
            return result;
        }

        public FriendsViewModel Get(int id, string userId)
        {

            FriendsViewModel friend = _mapper.Map<FriendsViewModel>(Database.Get(id,userId));
            return friend;
        }


        public void Create(FriendsViewModel item)
        {
            Friend friend = _mapper.Map<Friend>(item);
            Database.Create(friend);
        }

        public void Update(FriendsViewModel item)
        {
            Friend friend = _mapper.Map<Friend>(item);
            Database.Update(friend);
        }
    }
}
