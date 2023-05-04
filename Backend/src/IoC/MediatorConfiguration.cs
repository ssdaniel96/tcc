using Application.Dtos;
using Microsoft.Extensions.DependencyInjection;

namespace IoC;

public static class MediatorConfiguration
{
    internal static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(EventDto).Assembly);
        });
        return services;
    }

}
