﻿using Microsoft.AspNetCore.Identity;

namespace SocialService.DataAccess.Entities
{
    public class User 
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
