using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer.AuthServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResource()
        {
            return new List<ApiResource>()
            {
                new ApiResource("resource_api1") { Scopes = { "api1.read", "api1.write", "api1.update" },
                    ApiSecrets = new[] { new Secret("secretapi1".Sha256()) } },


                new ApiResource("resource_api2") { Scopes = { "api2.read", "api2.write", "api2.update" },
                    ApiSecrets = new[] { new Secret("secretapi2".Sha256()) } } };
        }


        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>()
            {
                new ApiScope("api1.read","API 1 için okuma izni"),
                new ApiScope("api1.write","API 1 için yazma izni"),
                new ApiScope("api1.update","API 1 için güncelleme izni"),

                new ApiScope("api2.read","API 1 için okuma izni"),
                new ApiScope("api2.write","API 1 için yazma izni"),
                new ApiScope("api2.update","API 1 için güncelleme izni"),


            };
        }


        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<TestUser> GetUsers()
        {
            return new List<TestUser>() {
                new TestUser{SubjectId ="1", Username="Berkancelik",Password= "password",Claims= new List<Claim>(){
                new Claim("given_name","Berkan"),
                new Claim("family_name","Çelik")
                }},
                  new TestUser{SubjectId ="2", Username="Ahmetselim",Password= "password",Claims= new List<Claim>(){
                new Claim("given_name","Ahmet"),
                new Claim("family_name","Selim")
                }}
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>(){
                new Client()
                {
                    ClientId = "Client1",
                    ClientName="Client 1 api uygulaması",
                    ClientSecrets = new[]{new Secret("secret".Sha256())},
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                AllowedScopes={"api1.read", "api1.update" }
                },
                new Client()
                {
                    ClientId = "Client2",
                    ClientName="Client 2 app uygulaması",
                    ClientSecrets = new[]{new Secret("secret".Sha256())},
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                AllowedScopes={"api1.read","api2.write", "api2.update" }
                },
                new Client
                {
                       ClientId = "Client1-Mvc",
                    ClientName="Client 1 Mvc app uygulaması",
                    ClientSecrets = new[]{new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.Hybrid,
              
                    RedirectUris = new List<string>{ "https://localhost:5006/sign-oidc" },
                    AllowedScopes = {IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,"api1.read"}
                }
            };
        }

    }

}



