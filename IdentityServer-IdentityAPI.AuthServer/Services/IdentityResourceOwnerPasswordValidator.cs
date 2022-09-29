using IdentityServer_IdentityAPI.AuthServer.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace IdentityServerIdentityAPI.AuthServer.Services
{
    public class IdentityResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityResourceOwnerPasswordValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var existUser = await _userManager.FindByEmailAsync(context.UserName);

            if (existUser == null) return;
            var passwordCheck = await _userManager.CheckPasswordAsync(existUser, context.Password);

            if (passwordCheck == false) return;
            

           
           
        }
    }
}
