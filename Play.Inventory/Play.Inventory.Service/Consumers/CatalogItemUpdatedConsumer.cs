using MassTransit;
using Play.Catalog.Contracts.Dtos;
using Play.Common.Repositories;
using Play.Inventory.Service.Entities;

namespace Play.Inventory.Service.Consumers;

public class CatalogItemUpdatedConsumer : IConsumer<CatalogItemCreatedDto>
{
    private readonly IRepository<CatalogItem> _repositoryCatalogItem;

    public CatalogItemUpdatedConsumer(IRepository<CatalogItem> repositoryCatalogItem)
    {
        _repositoryCatalogItem = repositoryCatalogItem;
    }

    public async Task Consume(ConsumeContext<CatalogItemCreatedDto> context)
    {
        var message = context.Message;

        var item = await _repositoryCatalogItem.GetAsync(message.CatalogItemId);

        if (item == null)
        {
            item = new CatalogItem
            {
                Id = message.CatalogItemId,
                Name = message.Name,
                Description = message.Description,
            };

            await _repositoryCatalogItem.CreateAsync(item);
        }
        else
        {
            item.Name = message.Name;
            item.Description = message.Description;

            await _repositoryCatalogItem.UpdateAsync(item);
        }
    }
}
