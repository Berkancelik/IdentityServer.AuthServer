using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace IdentityServer.Client1.Controllers
{
    public class ProdcutsController : Controller
    {
        private readonly IConfiguration _configuration;

        public ProdcutsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            HttpClient httpClient = new HttpClient();

            var disco = await httpClient.GetDiscoveryDocumentAsync("https://localhost:5001");

            if (disco.IsError)
            {
                //log
            }
            ClientCredentialsTokenRequest clientCredentialsTokenRequest = new ClientCredentialsTokenRequest();

            clientCredentialsTokenRequest.ClientId = _configuration["Client:ClientId"];
            clientCredentialsTokenRequest.ClientSecret = _configuration["Client:ClientSecret"];
            // adres discovery üzerinden gelecek
            clientCredentialsTokenRequest.Address = disco.TokenEndpoint;

            var token = await httpClient.RequestClientCredentialsTokenAsync(clientCredentialsTokenRequest);
            if (disco.IsError)
            {
                //log
            }
            // sen bana token ver ben onu ilgili isteğin header'ına ekleyeceğim anlamını taşımaktadır.
            httpClient.SetBearerToken(token.AccessToken);

            var response = await httpClient.GetAsync("https://localhost:5016/api/products/getproducts");

            if (response.IsSuccessStatusCode)
            {
                var contet = await response.Content.ReadAsStringAsync();
            }
            else
            {
                //log
            }

            return View();
        }
    }
}
