using Duende.IdentityServer.Models;

namespace HugAPet.Auth;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            // m2m client credentials flow client
            new Client
            {
                ClientId = "blazor.ui.client",
                ClientName = "HugAPet Blazor Client",
                AllowedGrantTypes = GrantTypes.Code,
                //ClientSecrets = { new Secret("vHWoriDBcbpHOgsWKtkWYQ==".Sha256()) },
                RequireClientSecret = false,
                RequirePkce = true,
                AllowAccessTokensViaBrowser = true,
                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile" },
                AllowedCorsOrigins = { "https://ui.local" },
                RedirectUris =  { "https://ui.local/authentication/login-callback" },
                PostLogoutRedirectUris = { "https://ui.local/authentication/logout-callback" },
            },

            // interactive client using code flow + pkce
            new Client
            {
                ClientId = "interactive",
                ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { "https://ui.local/signin-oidc" },
                FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "scope2" }
            },
        };
}
