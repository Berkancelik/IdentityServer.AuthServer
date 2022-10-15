using IdentityServer.Client1.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IdentityServer.Client1.Services
{
    public interface IApiResourceHttpClient
    {
        Task<HttpClient> GetHttpClient();
        Task<List<string>> SaveUserViewModel(UserSaveViewModel userSaveViewModel);

    }
}
