using MassTransit;
using Play.Catalog.Contracts.Dtos;
using Play.Common.Repositories;
using Play.Inventory.Service.Entities;

namespace Play.Inventory.Service.Consumers;

public class CatalogItemDeletedConsumer : IConsumer<CatalogItemDeletedDto>
{
    private readonly IRepository<CatalogItem> _repositoryCatalogItem;

    public CatalogItemDeletedConsumer(IRepository<CatalogItem> repositoryCatalogItem)
    {
        _repositoryCatalogItem = repositoryCatalogItem;
    }

    public async Task Consume(ConsumeContext<CatalogItemDeletedDto> context)
    {
        var message = context.Message;

        var item = await _repositoryCatalogItem.GetAsync(message.CatalogItemId);

        if (item == null)
        {
            return;
        }

        await _repositoryCatalogItem.RemoveAsync(message.CatalogItemId);
    }
}
