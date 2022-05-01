﻿using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.AuthServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResource()
        {
            return new List<ApiResource>()
            {
                new ApiResource("resource_api1"){ Scopes={"api1.read","api1.write","api1.update"} },
                new ApiResource("resource_api2"){ Scopes={"api2.read","api2.write","api2.update"} }
            };
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

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>(){
                new Client()
                {
                    ClientId = "Client1",//Sha256 : hashlenmiş bir şekidle tutmamız gerekmektedir.
                    ClientName="Client 1 api uygulaması",
                    ClientSecrets = new[]{new Secret("secret".Sha256())},
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                AllowedScopes={"api1.read" }
                },
                new Client()
                {
                    ClientId = "Client2",//Sha256 : hashlenmiş bir şekidle tutmamız gerekmektedir.
                    ClientName="Client 2 app uygulaması",
                    ClientSecrets = new[]{new Secret("secret".Sha256())},
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                AllowedScopes={"api1.read","api2.write", "api2.update" }
                }
            };
        }
    }

}
