using Play.Inventory.Service.Dtos;
using Play.Inventory.Service.Entities;

namespace Play.Inventory.Service.Extensions;

public static class InventoryItemExtensions
{
    public static InventoryItemDto AdDto(this InventoryItem inventoryItem)
    {
        return new InventoryItemDto(inventoryItem.CatalogItemId, inventoryItem.Quantity, inventoryItem.AcquiredAt);
    }
}
