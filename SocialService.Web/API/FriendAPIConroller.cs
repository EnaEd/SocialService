using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SocialService.ServiceLogic.Services;
using SocialService.ServiceLogic.ViewModels;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace SocialService.Web.API
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FriendAPIController : Controller
    {
        private FriendAPIService _service;
        public FriendAPIController(IConfiguration configuration,IMapper mapper)
        {
            _service = new FriendAPIService(configuration, mapper);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IEnumerable<FriendsViewModel> Get(string userId)
        {
            IEnumerable<FriendsViewModel> result = _service.GetAll(userId);
            return result;
        }

        [HttpGet("{id}")]
        public FriendsViewModel Get(int id, string userId)
        {
            FriendsViewModel result = _service.Get(id, userId);
            if (result is null)
            {
                return null;
            }
            return result;
        }

        // POST api/users
        [HttpPost]
        public void Post([FromBody]FriendsViewModel friend)
        {
            if (friend != null)
            {
                _service.Create(friend);
            }
        }


        [HttpPut]
        public void Put([FromBody]FriendsViewModel friend)
        {
            if (friend is null)
            {
                return ;
            }
            if (!_service.GetAll(friend.UserId).Any(x => x.Id == friend.Id))
            {
                return ;
            }
            _service.Update(friend);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public void Delete(int id, string userId)
        {
            FriendsViewModel friend = _service.GetAll(userId).FirstOrDefault(x => x.Id == id);
            if (friend != null)
            {
                _service.Delete(id, userId);
            }
        }
    }
}
