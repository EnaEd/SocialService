using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SocialService.ServiceLogic.ViewModels;
using SocialService.Web.API;


namespace SocialService.Web.Controllers
{
    public class APIController : Controller
    {
        private FriendAPIController _friends;
        public APIController(IConfiguration configuration, IMapper mapper)
        {
            _friends = new FriendAPIController(configuration, mapper);
        }
        [HttpGet]
        public IActionResult APIView(int userId)
        {

            return View(_friends.Get(userId));
        }
        [HttpPost]
        public IActionResult APIView(string name, string email, string phone,string userId)
        {
            FriendsViewModel friend = new FriendsViewModel { Name = name, Email = email, Phone = phone };
            _friends.Post(friend);
            return View(_friends.Get(int.Parse(userId)));
        }
        [HttpPost]
        public IActionResult DeleteFriend(string id,string userId)
        {
            _friends.Delete(int.Parse(id),int.Parse(userId));
            return RedirectToAction("APIView", "API");
        }

        public IActionResult EditFriend(string id,string userId)
        {
            FriendsViewModel friend = _friends.Get(int.Parse(userId)).FirstOrDefault(x => x.Id == int.Parse(id));

            return PartialView(friend);
        }
        [HttpPost]
        public IActionResult EditFriend(string name, string email, string phone, string id)
        {
            FriendsViewModel friend = new FriendsViewModel { Name = name, Email = email, Phone = phone, Id = int.Parse(id) };
            _friends.Put(friend);

            return RedirectToAction("APIView", "API");
        }
    }
}
