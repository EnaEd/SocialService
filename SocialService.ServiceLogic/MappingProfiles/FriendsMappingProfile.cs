using AutoMapper;
using SocialService.DataAccess.Entities;
using SocialService.ServiceLogic.ViewModels;

namespace SocialService.ServiceLogic.MappingProfiles
{
    public class FriendsMappingProfile : Profile
    {
        public FriendsMappingProfile() : base()
        {
            CreateMap<Friend, FriendsView>();
            CreateMap<FriendsView, Friend>();
        }
    }
}
