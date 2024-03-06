using Wolverine;

namespace HugAPet.UserManagement.Shared;

public static class MessagingExtensions
{
    public static WebApplicationBuilder AddMessaging(this WebApplicationBuilder builder)
    {
        builder.Host.UseWolverine();
        builder.Services.Scan(x => x.FromAssembliesOf(typeof(IEndpoint))
            .AddClasses()
            .AsImplementedInterfaces()
            .WithTransientLifetime());
        return builder;
    }
    public static WebApplication UseMessaging(this WebApplication app)
    {
        app.UseRouting();
        app.UseEndpoints(x =>
        {
            var endpoints = app.Services.GetServices<IEndpoint>();
            foreach (var endpoint in endpoints)
            {
                endpoint.Register(x);
            }
        });
        return app;
    }
}