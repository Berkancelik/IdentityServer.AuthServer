using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Client1.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
