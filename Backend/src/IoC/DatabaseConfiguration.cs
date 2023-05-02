using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IoC;

internal static class DatabaseConfiguration
{
    internal static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(
                opt => opt.UseSqlServer(configuration.GetConnectionString("Default"),
                            sqlServerOptions => sqlServerOptions.CommandTimeout(120))
                    .EnableSensitiveDataLogging()
                    .LogTo(Console.WriteLine, LogLevel.Information));

        return services;
    }
}
