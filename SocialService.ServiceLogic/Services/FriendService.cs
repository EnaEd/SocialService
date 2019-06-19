using AutoMapper;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using SocialService.ServiceLogic.DTO;
using SocialService.ServiceLogic.Helpers;
using SocialService.ServiceLogic.Interfaces;
using System.Collections.Generic;

namespace SocialService.ServiceLogic.Services
{
    public class FriendService : IFriendService
    {
        IUnitOfWork Database { get; set; }

        public FriendService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }
        public IEnumerable<FriendDTO> GetFriends()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Friend, FriendDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Friend>, List<FriendDTO>>(Database.Friends.GetAll());
        }

        public FriendDTO GetFriend(int? id)
        {
            if (id is null)
            {
                throw new ValidationException("Id not found",string.Empty);
            }
            Friend friend = Database.Friends.Get(id.Value);
            if (friend is null)
            {
                throw new ValidationException("Friend not found",string.Empty);
            }
            return new FriendDTO { Email = friend.Email, Id = friend.Id, Name = friend.Name, Phone = friend.Phone };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
