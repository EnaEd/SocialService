﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SocialService.DataAccess.Entities
{
    public class FriendsOfFriends
    {
        public int Id { get; set; }
        public int FriendId { get; set; }
        public string UserId { get; set; }
    }
}