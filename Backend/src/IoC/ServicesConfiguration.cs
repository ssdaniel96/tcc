using Microsoft.Extensions.DependencyInjection;
using Repository.Seeders;

namespace IoC;

internal static class ServicesConfiguration
{
    internal static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ISeeder, Seeder>();

        return services;
    }
}
