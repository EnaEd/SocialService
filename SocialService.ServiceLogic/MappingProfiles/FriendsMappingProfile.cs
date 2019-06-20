using AutoMapper;
using SocialService.DataAccess.Entities;
using SocialService.ServiceLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialService.ServiceLogic.MappingProfiles
{
    public class FriendsMappingProfile : Profile
    {
        public FriendsMappingProfile() : base()
        {
            CreateMap<Friend, FriendsViewModel>();
        }
    }
}
