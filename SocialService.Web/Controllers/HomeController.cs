using System.Diagnostics;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SocialService.ServiceLogic.Interfaces;
using SocialService.Web.Models;

namespace SocialService.Web.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userService;
        public HomeController(IMapper mapper, IConfiguration configuration,IUserService userService)
        {
            _userService = userService;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UserAccess()
        {
            var model = await _userService.GetUserModel(User);
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> FriendsOfFriends()
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
