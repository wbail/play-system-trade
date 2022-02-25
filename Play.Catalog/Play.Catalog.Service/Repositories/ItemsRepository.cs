﻿using MongoDB.Driver;
using Play.Catalog.Service.Entities;

namespace Play.Catalog.Service.Repositories;

public class ItemsRepository : IItemsRepository
{
    private const string collectionName = "items";
    private readonly IMongoCollection<Item> dbCollection;
    private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;

    public ItemsRepository(IMongoDatabase mongoDatabase)
    {
        dbCollection = mongoDatabase.GetCollection<Item>(collectionName);
    }

    public async Task<IReadOnlyCollection<Item>> GetAllAsync()
    {
        return await dbCollection.Find(filterBuilder.Empty).ToListAsync();
    }

    public async Task<Item> GetAsync(Guid id)
    {
        FilterDefinition<Item> filter = filterBuilder.Eq(x => x.Id, id);

        return await dbCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(Item item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        await dbCollection.InsertOneAsync(item);
    }

    public async Task UpdateAsync(Item item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        FilterDefinition<Item> filter = filterBuilder.Eq(x => x.Id, item.Id);

        await dbCollection.ReplaceOneAsync(filter, item);
    }

    public async Task RemoveAsync(Guid id)
    {
        FilterDefinition<Item> filter = filterBuilder.Eq(x => x.Id, id);

        await dbCollection.DeleteOneAsync(filter);
    }
}
