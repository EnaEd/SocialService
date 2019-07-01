﻿using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SocialService.Web.API;
using SocialService.Web.Models;

namespace SocialService.Web.Controllers
{
    public class HomeController : Controller
    {
        private FriendAPIController _friends;
        public HomeController(IMapper mapper, IConfiguration configuration)
        {
            _friends = new FriendAPIController(configuration, mapper);
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
