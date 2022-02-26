namespace Play.Inventory.Service.Dtos;

public class InventoryItemDto
{
    public InventoryItemDto(Guid catalogItemId, int quantity, DateTime acquiredAt)
    {
        CatalogItemId = catalogItemId;
        Quantity = quantity;
        AcquiredAt = acquiredAt;
    }

    public Guid CatalogItemId { get; set; }
    public int Quantity { get; set; }
    public DateTime AcquiredAt { get; set; }
}
