using IdentityModel.Client;
using IdentityServer.Client1.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IdentityServer.Client1.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IConfiguration _configuration;

        public ProductsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> products = new List<Product>();
            HttpClient httpClient = new HttpClient();

            var accesstoken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);


            httpClient.SetBearerToken(accesstoken);

            var response = await httpClient.GetAsync("https://localhost:5016/api/products/getproducts");

            if (response.IsSuccessStatusCode)
            {
                var contet = await response.Content.ReadAsStringAsync();

                 products = JsonConvert.DeserializeObject<List<Product>>(contet);
            }
            else
            {
                //log
            }

            return View(products);
        }
    }
}
