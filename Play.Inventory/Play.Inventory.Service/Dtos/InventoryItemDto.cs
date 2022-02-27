namespace Play.Inventory.Service.Dtos;

public class InventoryItemDto
{
    public InventoryItemDto(Guid catalogItemId, string name, string description, int quantity, DateTime acquiredAt)
    {
        CatalogItemId = catalogItemId;
        Name = name;
        Description = description;
        Quantity = quantity;
        AcquiredAt = acquiredAt;
    }

    public Guid CatalogItemId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public DateTime AcquiredAt { get; set; }
}
