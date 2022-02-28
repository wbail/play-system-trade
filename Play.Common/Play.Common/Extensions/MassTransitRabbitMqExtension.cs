using MassTransit;
using MassTransit.Definition;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Play.Common.Settings;
using System.Reflection;

namespace Play.Common.Extensions;

public static class MassTransitRabbitMqExtension
{
    public static IServiceCollection AddMassTransitRabbitMqConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(configure =>
        {
            configure.AddConsumers(Assembly.GetEntryAssembly());

            configure.UsingRabbitMq((context, configurator) =>
            {
                var serviceSettings = configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

                var rabbitMqSettings = configuration.GetSection(nameof(RabbitMqSettings)).Get<RabbitMqSettings>();
                configurator.Host(rabbitMqSettings.Host);
                configurator.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter(serviceSettings.ServiceName, false));
            });
        });

        services.AddMassTransitHostedService();

        return services;
    }
}
