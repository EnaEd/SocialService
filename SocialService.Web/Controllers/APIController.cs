using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SocialService.DataAccess.Entities;
using SocialService.ServiceLogic.Interfaces;
using SocialService.ServiceLogic.ViewModels;
using SocialService.Web.API;


namespace SocialService.Web.Controllers
{
    public class APIController : Controller
    {
        private FriendAPIController _friends;
        private readonly IAccountService _accountService;
        public APIController(IConfiguration configuration,IAccountService accountService, IMapper mapper)
        {
            _friends = new FriendAPIController(configuration, mapper);
            _accountService = accountService;
        }
        [HttpGet]
        public IActionResult APIView()
        {
            string userId = User.Identity.Name;
            return View(_friends.Get(userId));
        }
        [HttpPost]
        public IActionResult APIView(string name, string email, string phone)
        {
            string userId = User.Identity.Name;
            FriendsViewModel friend = new FriendsViewModel { Name = name, Email = email, Phone = phone, UserId = userId };
            _friends.Post(friend);
            return View(_friends.Get(userId));
        }
        [HttpPost]
        public IActionResult DeleteFriend(string id)
        {
            string userId = User.Identity.Name;
            _friends.Delete(int.Parse(id), userId);
            return RedirectToAction("APIView", "API");
        }

        public IActionResult EditFriend(string id)
        {
            string userId = User.Identity.Name;
            FriendsViewModel friend = _friends.Get(userId).FirstOrDefault(x => x.Id == int.Parse(id));

            return PartialView(friend);
        }
        [HttpPost]
        public IActionResult EditFriend(string name, string email, string phone, string id)
        {
            string userId = User.Identity.Name;
            FriendsViewModel friend = new FriendsViewModel { Name = name, Email = email, Phone = phone, Id = int.Parse(id), UserId = userId };
            _friends.Put(friend);

            return RedirectToAction("APIView", "API");
        }
    }
}
