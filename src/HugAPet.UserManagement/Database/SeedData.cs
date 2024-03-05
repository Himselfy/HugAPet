using Microsoft.EntityFrameworkCore;

namespace HugAPet.UserManagement.Database;

public class SeedData
{
    public static void EnsureSeedData(WebApplication app)
    {
        using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            scope.ServiceProvider.GetRequiredService<UserManagementDbContext>().Database.Migrate();
        }
    }
}