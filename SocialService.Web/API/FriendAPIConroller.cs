using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SocialService.ServiceLogic.Services;
using SocialService.ServiceLogic.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SocialService.Web.API
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FriendAPIController : Controller
    {
        private FriendService _service;
        public FriendAPIController(IConfiguration configuration, IMapper mapper)
        {
            _service = new FriendService(configuration, mapper);
        }

        [HttpGet]
        public IEnumerable<FriendsView> Get()
        {

            string userId = User.Identity.Name;
            IEnumerable<FriendsView> result = _service.GetAll(userId);
            return result;
        }

        [HttpPost("CreateFriend")]
        public void Post([FromBody]FriendsView friend)
        {
            string userId = User.Identity.Name;
            if (!string.IsNullOrEmpty(friend.Email))
            {
                _service.Create(friend, userId);
            }
        }


        [HttpPost("EditFriend")]
        public void Put([FromBody]FriendsView friend)
        {
            string userId = User.Identity.Name;
            if (friend is null)
            {
                return;
            }
            if (!_service.GetAll(userId).Any(x => x.Id == friend.Id))
            {
                return;
            }
            _service.Update(friend);
        }

        [HttpPost("DeleteFriend/{id}")]
        public void Delete(int id)
        {
            string userId = User.Identity.Name;
            FriendsView friend = _service.GetAll(userId).FirstOrDefault(x => x.Id == id);
            if (friend != null)
            {
                _service.Delete(id, userId);
            }
        }
    }
}
