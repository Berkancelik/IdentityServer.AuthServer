using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using System.Linq;

namespace IdentityServer.AuthServer.Services.Seeds
{
    public static  class IdentityServerSeedData
    {
        /// <summary>
        /// Mirroring config method to database.
        /// </summary>
        /// <param name="context"></param>
        public static void Seed(ConfigurationDbContext context)
        {
            if (!context.Clients.Any())
            {
                foreach (var client in Config.GetClients())
                {
                    context.Clients.Add(client.ToEntity());
                }
            }

            if (!context.ApiResources.Any())
            {
                foreach (var apiResource in  Config.GetApiResources())
                {
                    context.ApiResources.Add(apiResource.ToEntity());
                }

            }

            if (!context.ApiScopes.Any())
            {
                Config.GetApiScopes().ToList().ForEach(apiscope =>
                {
                    context.ApiScopes.Add(apiscope.ToEntity());
                });

            }

            if (!context.IdentityResources.Any())
            {
                Config.GetIdentityResources().ToList().ForEach(apiscope =>
                {
                    context.IdentityResources.Add(apiscope.ToEntity());
                });

            }

            context.SaveChanges();
        }
    }
}
