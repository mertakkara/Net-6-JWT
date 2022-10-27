using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using net_6_jwt.Models;
using net_6_jwt.Services;

namespace net_6_jwt.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;    
        }
        [HttpPost("authenticate")]   
       public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new {message = "Username or password is incorrect" });    
            return Ok(response);    

        }
        [Helpers.Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}
