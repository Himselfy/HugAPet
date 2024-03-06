using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace HugAPet.UserManagement.Shared;

public static class AuthenticationExtensions
{
    public static IHostApplicationBuilder AddAuthentication(this IHostApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                builder.Configuration.Bind("JwtSettings", options);
                options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
            });

        // builder.Services.AddClientCredentialsTokenManagement()
        //     .AddClient("auth.service.client", client =>
        //     {
        //         builder.Configuration.Bind("AuthSettings", client);
        //         client.Scope = "auth.service";
        //     });
        // builder.Services.AddClientCredentialsHttpClient("auth.service", "auth.service.client", client =>
        // {
        //     client.BaseAddress = new Uri(builder.Configuration["JwtSettings:Authority"] + "/api");
        // });

        return builder;
    }
}