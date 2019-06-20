﻿using AutoMapper;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using SocialService.DataAccess.Repositories;
using SocialService.ServiceLogic.ViewModels;
using System.Collections.Generic;

namespace SocialService.ServiceLogic.API
{
    public class FriendAPIService : BaseService
    {
        private readonly IMapper _mapper;
        public IRepository<Friend> Database { get; set; }

        public FriendAPIService(string connectionString, IMapper mapper) : base(connectionString)
        {
            Database = new FriendRepository(connectionString);
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
            Friend friend = new Friend { Name = item.Name, Email = item.Email, Phone = item.Phone };
            Database.Create(friend);
        }

        public void Update(FriendsViewModel item)
        {
            Friend friend = new Friend { Name = item.Name, Email = item.Email, Phone = item.Phone, Id = item.Id };
            Database.Update(friend);
        }
    }
}
