﻿using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using System;
using System.Collections.Generic;

namespace SocialService.DataAccess.Repositories
{
    public class FriendDapperRepository : IRepository<Friend>
    {

        public void Create(Friend item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Friend> Find(Func<Friend, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Friend Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Friend> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Friend item)
        {
            throw new NotImplementedException();
        }
    }
}
