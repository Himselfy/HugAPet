using HugAPet.UserManagement.UserManagement.Database;
using Microsoft.EntityFrameworkCore;

namespace HugAPet.UserManagement.UserManagement;

public static class UserManagementExtensions
{
    public static IHostApplicationBuilder AddUserManagement(this IHostApplicationBuilder builder)
    {
        builder.Services.AddDbContext<UserManagementDbContext>(o =>
        {
            o.UseNpgsql(builder.Configuration.GetConnectionString("UserManagementDatabase"));
        });
        return builder;
    }
    
    public static WebApplication UseUserManagement(this WebApplication app)
    {
        DatabaseInit.EnsureDatabaseSetup(app);
        return app;
    }
}