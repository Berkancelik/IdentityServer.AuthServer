using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static IdentityServer4.IdentityServerConstants;

namespace IdentityServerIdentityAPI.AuthServer.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //clam base auth
    [Authorize(LocalApi.PolicyName)]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public IActionResult SignUp()
        {
            return Ok("signup çalıştı");
        }
    }
}
