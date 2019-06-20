using AutoMapper;
using SocialService.DataAccess.Entities;
using SocialService.ServiceLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialService.ServiceLogic.MappingProfiles
{
    class UserMappingProfile:Profile
    {
        public UserMappingProfile() : base()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}
