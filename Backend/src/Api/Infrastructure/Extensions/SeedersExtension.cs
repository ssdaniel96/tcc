using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Seeders;

namespace Api.Infrastructure.Extensions;

public static class SeedersExtension
{
    public static async Task ExecuteSeeders(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var context = scope.ServiceProvider.GetService<ApplicationDbContext>() 
                      ?? throw new ArgumentNullException("Database cant be null!");
    
        await context.Database.MigrateAsync();
    
        var service = scope.ServiceProvider.GetService<ISeeder>()
                      ?? throw new ArgumentException("Service cant be null");

        await service.SeedAsync();
    }
}