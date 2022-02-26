namespace Play.Inventory.Service.Dtos;

public class GrantItemsDto
{
    public Guid UserId { get; set; }
    public Guid CatalogItemId { get; set; }
    public int Quantity { get; set; }
}
