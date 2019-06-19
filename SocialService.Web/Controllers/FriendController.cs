using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialService.ServiceLogic.DTO;
using SocialService.ServiceLogic.Interfaces;
using SocialService.ServiceLogic.Services;
using SocialService.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialService.Web.Controllers
{
    public class FriendController : Controller
    {
        private IFriendService _friendService;
        public FriendController(IFriendService service)
        {
            _friendService = service;
            
        }
        public ActionResult FriendView()
        {
            IEnumerable<FriendDTO> friendDTOs = _friendService.GetFriends();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FriendDTO, FriendsViewModel>()).CreateMapper();
            var friends = mapper.Map<IEnumerable<FriendDTO>, List<FriendsViewModel>>(friendDTOs);
            return View(friends);
        }
        
        protected override void Dispose(bool disposing)
        {
            _friendService.Dispose();
            base.Dispose(disposing);
        }
    }
}
