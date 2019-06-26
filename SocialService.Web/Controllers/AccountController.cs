using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using SocialService.ServiceLogic.Interfaces;
using SocialService.ServiceLogic.ViewModels;

namespace SocialService.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private ITokenService _tokenService;
        public AccountController(IAccountService accountService, ITokenService tokenService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            bool isRegistrationSuccess = false;
            if (ModelState.IsValid)
            {
                isRegistrationSuccess = await _accountService.OnReigstration(model);
            }

            if (!isRegistrationSuccess)
            {
                return View(model);
            }
            return RedirectToAction("APIView", "API");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            bool isLogin = false;
            if (ModelState.IsValid)
            {
                isLogin = await _accountService.OnLogin(model);
            }
            if (!isLogin)
            {
                ModelState.AddModelError("", "Wrong login or password");
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task Token()
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            string token = _tokenService.GetToken(username, password);

            Response.ContentType = "application/json";
            await Response.WriteAsync(token);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            _accountService.OnLogout();
            return RedirectToAction("Index", "Home");
        }
    }
}
