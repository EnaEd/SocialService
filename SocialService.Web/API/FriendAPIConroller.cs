using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialService.ServiceLogic.API;
using SocialService.ServiceLogic.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SocialService.Web.API
{
    [Route("api/[controller]")]
    public class FriendAPIController : Controller
    {
        private FriendAPIService _service;
        public FriendAPIController(IMapper mapper)
        {
            _service = new FriendAPIService(mapper);
        }
        
        [HttpGet]
        public IEnumerable<FriendsViewModel> Get()
        {
            IEnumerable<FriendsViewModel> result = _service.GetAll();
            return result;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            FriendsViewModel result = _service.Get(id);
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
            if (!_service.GetAll().Any(x => x.Id == friend.Id))
            {
                return NotFound();
            }

            _service.Update(friend);
            _service.SaveChanges();
            return Ok(friend);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            FriendsViewModel friend = _service.GetAll().FirstOrDefault(x => x.Id == id);
            if (friend is null)
            {
                return NotFound();
            }
            _service.Delete(id);
            _service.SaveChanges();
            return Ok(friend);
        }
    }
}
