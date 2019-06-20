using AutoMapper;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using SocialService.DataAccess.Repositories;
using SocialService.ServiceLogic.DTO;
using SocialService.ServiceLogic.MappingProfiles;
using SocialService.ServiceLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialService.ServiceLogic.API
{
    public class FriendAPIService:BaseService
    {
        private readonly IMapper _mapper;
        public IRepository<Friend> Database { get; set; }

        public FriendAPIService(/*IRepository<Friend> repository*/IMapper mapper)
        {
            //Database = repository;
            Database = new FriendRepository();
           _mapper = mapper;
        }
        public void Delete(int id)
        {
            Database.Delete(id);
        }

        public IEnumerable<FriendsViewModel> GetAll()
        {
            IEnumerable<FriendsViewModel> result = _mapper.Map<IEnumerable<FriendsViewModel>>(Database.GetAll());
            return result;
        }

        public FriendsViewModel Get(int id)
        {

            FriendsViewModel friend = _mapper.Map<FriendsViewModel>(Database.Get(id));
            return friend;
        }


        public void Create(FriendsViewModel item)
        {
            Friend result = _mapper.Map<Friend>(item);
            Database.Create(result);
        }

        public void Update(FriendsViewModel item)
        {
            Friend result = _mapper.Map<Friend>(item);
            Database.Update(result);
        }
    }
}
