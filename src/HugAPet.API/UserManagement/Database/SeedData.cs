using Microsoft.EntityFrameworkCore;

namespace HugAPet.UserManagement.UserManagement.Database;

public class DatabaseInit
{
    public static void EnsureDatabaseSetup(WebApplication app)
    {
        using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            scope.ServiceProvider.GetRequiredService<UserManagementDbContext>().Database.Migrate();
        }
    }
}