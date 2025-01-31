using Microsoft.EntityFrameworkCore;

namespace CrudProduct.Data;

public static class DatabaseInitializer
{
    public static void ApplyMigrations(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        dbContext.Database.Migrate(); // Aplica as migrations automaticamente
    }
}
