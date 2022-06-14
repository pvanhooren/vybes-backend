using Microsoft.EntityFrameworkCore;

namespace ProfileMicroservice.Data;

public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder applicationBuilder, bool isProd)
    {
        using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
        MigrateData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
    }

    private static void MigrateData(DbContext? context, bool isProd)
    {
        if (!isProd) return;
        try
        {
            context?.Database.Migrate();
            Console.WriteLine("--> The ProfileMicroservice database has been migrated...");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"--> Could not run migrations: {ex.Message}");
        }
    }
}
