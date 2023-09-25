using Application.UseCases.Events.Dtos;
using Microsoft.Extensions.DependencyInjection;

namespace IoC;

public static class MediatorConfiguration
{
    internal static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(EventHistoryDto).Assembly);
        });
        return services;
    }

}
