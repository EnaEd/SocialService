﻿using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public APIController(IAccountService accountService, IMapper mapper, UserManager<User> userManager)
        {
            _friends = new FriendAPIController(mapper);
            _accountService = accountService;
        }
        [HttpGet]
        public IActionResult APIView()
        {
            var id = _accountService.UserManager.GetUserId(this.User);
            return View(_friends.Get(id));
        }
        [HttpPost]
        public IActionResult APIView(string name, string email, string phone)
        {
            var id = _accountService.UserManager.GetUserId(this.User);
            FriendsViewModel friend = new FriendsViewModel { Name = name, Email = email, Phone = phone, UserId = id };
            _friends.Post(friend);
            return View(_friends.Get(id));
        }
        [HttpPost]
        public IActionResult DeleteFriend(string id)
        {
            var userId = _accountService.UserManager.GetUserId(this.User);
            _friends.Delete(int.Parse(id), userId);
            return RedirectToAction("APIView", "API");
        }

        public IActionResult EditFriend(string id)
        {
            var userId = _accountService.UserManager.GetUserId(this.User);
            FriendsViewModel friend = _friends.Get(userId).FirstOrDefault(x => x.Id == int.Parse(id));

            return PartialView(friend);
        }
        [HttpPost]
        public IActionResult EditFriend(string name, string email, string phone, string id)
        {
            var userId = _accountService.UserManager.GetUserId(this.User);
            FriendsViewModel friend = new FriendsViewModel { Name = name, Email = email, Phone = phone, Id = int.Parse(id), UserId = userId };
            _friends.Put(friend);

            return RedirectToAction("APIView", "API");
        }
    }
}
