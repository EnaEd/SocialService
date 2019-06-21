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
    public class FriendAPIController : Controller
    {
        private FriendAPIService _service;
        private string _connectionString;
        public FriendAPIController(IConfiguration configuration, IMapper mapper)
        {
            _connectionString = configuration.GetConnectionString("FriendBaseConnection");
            _service = new FriendAPIService(mapper);
        }

        [HttpGet]
        public IEnumerable<FriendsViewModel> Get(string userId)
        {
            IEnumerable<FriendsViewModel> result = _service.GetAll(userId);
            return result;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id, string userId)
        {
            FriendsViewModel result = _service.Get(id,userId);
            if (result is null)
            {
                return NotFound();
            }
            return new ObjectResult(result);
        }

        // POST api/users
        [HttpPost]
        public IActionResult Post([FromBody]FriendsViewModel friend)
        {
            if (friend is null)
            {
                return BadRequest();
            }
            _service.Create(friend);

            return Ok(friend);
        }


        [HttpPut]
        public IActionResult Put([FromBody]FriendsViewModel friend)
        {
            if (friend is null)
            {
                return BadRequest();
            }
            if (!_service.GetAll(friend.UserId).Any(x => x.Id == friend.Id))
            {
                return NotFound();
            }

            _service.Update(friend);
            _service.SaveChanges();
            return Ok(friend);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, string userId)
        {
            FriendsViewModel friend = _service.GetAll(userId).FirstOrDefault(x => x.Id == id);
            if (friend is null)
            {
                return NotFound();
            }
            _service.Delete(id, userId);
            _service.SaveChanges();
            return Ok(friend);
        }
    }
}
