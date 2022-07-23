using IdentityServer.Client1.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Client1
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IApiResourceHttpClient, ApiResourceHttpClient>();



            services.AddAuthentication(opts =>
            {
                opts.DefaultScheme = "Cookies";
                opts.DefaultChallengeScheme = "oidc";
            }).AddCookie("Cookies", opts =>
            {
                opts.AccessDeniedPath = "/Home/AccessDenied";
            }).AddOpenIdConnect("oidc", opts =>
            {
                opts.SignInScheme = "Cookies";
                opts.Authority = "https://localhost:5001";
                opts.ClientId = "Client1-Mvc";
                opts.ClientSecret = "secret";
                opts.ResponseType = "code id_token";
                opts.GetClaimsFromUserInfoEndpoint = true;
                opts.SaveTokens = true;
                opts.Scope.Add("api1.read");
                opts.Scope.Add("offline_access");
                opts.Scope.Add("CountryAndCity");
                opts.Scope.Add("Roles");
                opts.ClaimActions.MapUniqueJsonKey("country", "country");
                opts.ClaimActions.MapUniqueJsonKey("city", "city");
                opts.ClaimActions.MapUniqueJsonKey("role", "role");

                opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    RoleClaimType = "role"
                };
            });

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
