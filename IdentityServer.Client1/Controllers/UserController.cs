using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IdentityServer.Client1.Controllers
{
    public class UserController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            
            return View();
        }

        public async Task LogOut()
        {
            await HttpContext.SignOutAsync("Cookies");

            await HttpContext.SignOutAsync("oidc");
        }
    }
}
