using Application.UseCases.Events.Dtos;
using Microsoft.Extensions.DependencyInjection;

namespace IoC;

internal static class AutoMapperConfiguration
{
    internal static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(EventDto).Assembly);

        return services;
    }
}
