using AutoMapper;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using SocialService.DataAccess.Repositories;
using SocialService.ServiceLogic.ViewModels;
using System.Collections.Generic;

namespace SocialService.ServiceLogic.Services
{
    public class FriendAPIService 
    {
        private readonly IMapper _mapper;
        public IRepository<Friend> Database { get; set; }

        public FriendAPIService(string connectionString, IMapper mapper) 
        {
            Database = new FriendRepository(connectionString);
            _mapper = mapper;
        }
        public void Delete(int id,int userId)
        {
            Database.Delete(id, userId);
        }

        public IEnumerable<FriendsViewModel> GetAll(int userId)
        {
            IEnumerable<FriendsViewModel> result = _mapper.Map<IEnumerable<FriendsViewModel>>(Database.GetAll(userId));
            return result;
        }

        public FriendsViewModel Get(int id, int userId)
        {

            FriendsViewModel friend = _mapper.Map<FriendsViewModel>(Database.Get(id,userId));
            return friend;
        }


        public void Create(FriendsViewModel item)
        {
            Friend friend = new Friend { Name = item.Name, Email = item.Email, Phone = item.Phone,UserId=item.UserId };
            Database.Create(friend);
        }

        public void Update(FriendsViewModel item)
        {
            Friend friend = new Friend { Name = item.Name, Email = item.Email, Phone = item.Phone, Id = item.Id,UserId=item.UserId };
            Database.Update(friend);
        }
    }
}
