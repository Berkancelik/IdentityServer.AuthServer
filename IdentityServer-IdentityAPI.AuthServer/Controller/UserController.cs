using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServerIdentityAPI.AuthServer.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //clam base auth
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public IActionResult SignUp()
        {
            return Ok("signup çalıştı");
        }
    }
}
