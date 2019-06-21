using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SocialService.ServiceLogic.Services;
using SocialService.ServiceLogic.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SocialService.Web.API
{
    [Route("api/[controller]")]
    public class UserAPIConroller : Controller
    {
        private UserAPIService _service;
        public UserAPIConroller(IConfiguration configuration,IMapper mapper)
        {
            _service = new UserAPIService(configuration, mapper);
        }

        [HttpGet]
        public IEnumerable<UserViewModel> Get(string userId)
        {
            IEnumerable<UserViewModel> result = _service.GetAll(userId);
            return result;
        }

        [HttpGet("{id}")]
        public UserViewModel Get(int id, string userId)
        {
            UserViewModel result = _service.Get(id, userId);
            if (result is null)
            {
                return null;
            }
            return result;
        }

        // POST api/users
        [HttpPost]
        public void Post([FromBody]UserViewModel friend)
        {
            if (friend != null)
            {
                _service.Create(friend);
            }
        }


        [HttpPut]
        public void Put([FromBody]UserViewModel user)
        {
            if (user is null)
            {
                return ;
            }
            if (!_service.GetAll(user.Id).Any(x => x.Id == user.Id))
            {
                return ;
            }
            _service.Update(user);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public void Delete(int id, string userId)
        {
            UserViewModel user = _service.GetAll(userId).FirstOrDefault();
            if (user != null)
            {
                _service.Delete(id, userId);
            }
        }
    }
}
