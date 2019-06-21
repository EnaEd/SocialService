using AutoMapper;
using SocialService.DataAccess.Entities;
using SocialService.ServiceLogic.ViewModels;

namespace SocialService.ServiceLogic.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile() : base()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
        }
    }
}
