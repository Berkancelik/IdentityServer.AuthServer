using IdentityServer_IdentityAPI.AuthServer.Models;
using IdentityServerIdentityAPI.AuthServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerIdentityAPI.AuthServer.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //clam base auth
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;


    public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]

        public async Task<IActionResult> SignUp(UserSaveViewModel userSaveViewModel)
        {

            ApplicationUser applicationUser = new ApplicationUser();

            applicationUser.UserName = userSaveViewModel.UserName;
            applicationUser.Email = userSaveViewModel.Email;
            applicationUser.City = userSaveViewModel.City;

            var result = await _userManager.CreateAsync(applicationUser, userSaveViewModel.Password);

            if (result.Succeeded)
            {
                return BadRequest(result.Errors.Select(x => x.Description));
            }

            return Ok("Üye başarıla kaydedildi");
                

        }
    }
}
