using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Security.Duende.Identity.Server.Razor;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };


    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope("api1", "My API")
        };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            // machine to machine client
            new Client
            {
                ClientId = "client",
                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                // scopes that client has access to
                AllowedScopes = { "api1" }
            },
                
            // interactive ASP.NET Core Web App
            new Client
            {
                ClientId = "web",
                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedGrantTypes = GrantTypes.CodeAndClientCredentials ,
                    
                // where to redirect to after login
                RedirectUris = { "https://localhost:4200", "http://localhost:4200", "http://localhost", "https://localhost:4200/signin-oidc", "http://localhost:4200/signin-oidc" },

                // where to redirect to after logout
                PostLogoutRedirectUris = { "https://localhost:4200/signout-callback-oidc"},

                AllowOfflineAccess = true,

                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "api1"
                },

                Enabled = true,
                AllowedCorsOrigins = { "https://localhost:4200", "http://localhost:4200", "https://localhost" },
                AllowAccessTokensViaBrowser= true
            }
        };
}