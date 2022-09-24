using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer-IdentityAPI.AuthServer
{
    [Route("api/[controller]/[action]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost ]
    public IActionResult SignUp()
    {
        return Ok("signup çalıştı");
    }
}
}
