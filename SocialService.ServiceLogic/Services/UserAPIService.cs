using AutoMapper;
using Microsoft.Extensions.Configuration;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using SocialService.ServiceLogic.ViewModels;
using System.Collections.Generic;

namespace SocialService.ServiceLogic.Services
{
    public class UserAPIService : BaseAPIService
    {
        private IDapperRepository<User> _userDapperRepository;
        public UserAPIService(IConfiguration configuration,IMapper mapper) : base(mapper)
        {
            _userDapperRepository = new UserDapperRepository(configuration);
        }

        public void Delete(int id, string userId)
        {
            _userDapperRepository.Delete(id, userId);
        }

        public IEnumerable<UserViewModel> GetAll(string userId)
        {
            //Use Dapper instead of EF
            IEnumerable<UserViewModel> result = _mapper.Map<IEnumerable<UserViewModel>>(_userDapperRepository.GetAll(userId));
            return result;
        }

        public UserViewModel Get(int id, string userId)
        {

            UserViewModel friend = _mapper.Map<UserViewModel>(_userDapperRepository.Get(id, userId));
            return friend;
        }

        public void Create(UserViewModel item)
        {
            User friend = _mapper.Map<User>(item);
            _userDapperRepository.Create(friend);
        }

        public void Update(UserViewModel item)
        {
            User friend = _mapper.Map<User>(item);
            _userDapperRepository.Update(friend);
        }
    }
}
