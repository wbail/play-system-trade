using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Play.Common.Entities;
using Play.Common.Repositories;

namespace Play.Common.Extensions;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepository<T>(this IServiceCollection services, string collectionName) where T : IEntity
    {
        services.AddSingleton<IRepository<T>>(serviceProvider =>
        {
            var database = serviceProvider.GetService<IMongoDatabase>();
            return new Repository<T>(database, collectionName);
        });

        return services;
    }
}
