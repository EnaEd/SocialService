using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SocialService.ServiceLogic.Interfaces;
using SocialService.ServiceLogic.ViewModels;

namespace SocialService.Web.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : Controller
    {
        private IUserService _userService;
        private IMapper _mapper;
        public UserController(IConfiguration configuration,IUserService userService,IMapper mapper)
        {
            _userService =userService;
            _mapper = mapper;
        }
        
        [HttpGet("GetUsers")]
        public IEnumerable<UserView> Get()
        {
            
            return _userService.GetUsers();
        }

        [HttpPost("DeleteUser/{id}")]
        public async Task Delete(string id)
        {
            await _userService.Delete(id);
        }
    }
}
