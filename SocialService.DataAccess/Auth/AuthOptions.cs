﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialService.DataAccess.Auth
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; 
        public const string AUDIENCE = "http://localhost:44396/"; 
        const string KEY = "mysupersecret_secretkey!123";  
        public const int LIFETIME = 1; 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}