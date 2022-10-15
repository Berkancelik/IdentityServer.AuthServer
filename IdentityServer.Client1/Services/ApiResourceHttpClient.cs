using IdentityModel.Client;
using IdentityServer.Client1.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Client1.Services
{
    public class ApiResourceHttpClient : IApiResourceHttpClient

    {
        private HttpClient _client;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public ApiResourceHttpClient(HttpClient client, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _client = client;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public async Task<HttpClient> GetHttpClient()
        {
            var accesstoken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            _client.SetBearerToken(accesstoken);

            return _client;

        }

        public async Task<List<string>> SaveUserViewModel(UserSaveViewModel userSaveViewModel)
        {
            var disco = await _client.GetDiscoveryDocumentAsync(_configuration["AuthSeverUrl"]);
            if (disco.IsError)
            {
                //log
            }

            var clienCredentialsTokenRequest = new ClientCredentialsTokenRequest();
            clienCredentialsTokenRequest.ClientId = _configuration["ClientResourceOwner:ClientId"];
            clienCredentialsTokenRequest.ClientSecret = _configuration["ClientResourceOwner:ClientId"];
            clienCredentialsTokenRequest.Address = disco.TokenEndpoint;
            var token = await _client.RequestClientCredentialsTokenAsync(clienCredentialsTokenRequest);

            if (token.IsError)
            {
                //log
            }

            var stringContent = new StringContent(JsonConvert.SerializeObject(userSaveViewModel),Encoding.UTF8,"application/json");

            _client.SetBearerToken(token.AccessToken);

            var response = await  _client.PostAsync("https://localhost:5001/api/user/signup",stringContent);

            if (!response.IsSuccessStatusCode)
            {
                var errorList = JsonConvert.DeserializeObject<List<string>>( await response.Content.ReadAsStringAsync());

                return errorList;
            }
            return null;
                
        }

    }
}
