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
            new ApiScope("user.management", "User management API"),
            new ApiScope("auth.service", "Auth service API"),
        };


    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client
            {
                ClientId = "blazor.ui.client",
                ClientName = "HugAPet Blazor Client",
                AllowedGrantTypes = GrantTypes.Code,
                RequireClientSecret = false,
                RequirePkce = true,
                AllowAccessTokensViaBrowser = true,
                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "user.management" },
                AllowedCorsOrigins = { "https://ui.local" },
                RedirectUris =  { "https://ui.local/authentication/login-callback" },
                PostLogoutRedirectUris = { "https://ui.local/authentication/logout-callback" },
            },
            new Client
            {
                ClientId = "user.management.client",
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "auth.service" }
            },
        };
}
