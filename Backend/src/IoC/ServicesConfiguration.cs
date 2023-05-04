using Domain.Repositories.Equipments;
using Domain.Repositories.Events;
using Domain.Repositories.Locations;
using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories.Equipments;
using Repository.Repositories.Events;
using Repository.Repositories.Locations;
using Repository.Seeders;

namespace IoC;

internal static class ServicesConfiguration
{
    internal static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ISeeder, Seeder>()
                .AddRepositores();

        return services;
    }

    private static IServiceCollection AddRepositores(this IServiceCollection services)
    {
        services.AddScoped<IEquipmentRepository, EquipmentRepository>()
                .AddScoped<ILocationRepository, LocationRepository>()
                .AddScoped<IEventRepository, EventRepository>();

        return services;
    }
}
