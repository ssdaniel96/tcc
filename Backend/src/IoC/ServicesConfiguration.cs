using Domain.Repositories.Equipments;
using Domain.Repositories.Events;
using Domain.Repositories.Locations;
using Domain.Repositories.Sensors;
using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories.Equipments;
using Repository.Repositories.Events;
using Repository.Repositories.Locations;
using Repository.Repositories.Sensors;
using Repository.Seeders;
using Repository.Transactions;

namespace IoC;

internal static class ServicesConfiguration
{
    internal static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ISeeder, Seeder>()
                .AddScoped<ITransaction, Transaction>()
                .AddRepositores();

        return services;
    }

    private static IServiceCollection AddRepositores(this IServiceCollection services)
    {
        services.AddScoped<IEquipmentRepository, EquipmentRepository>()
            .AddScoped<ILocationRepository, LocationRepository>()
            .AddScoped<IEventRepository, EventRepository>()
            .AddScoped<IBuildingRepository, BuildingRepository>()
            .AddScoped<IAddressRepository, AddressRepository>()
            .AddScoped<ISensorRepository, SensorRepository>();
        
        return services;
    }
}
