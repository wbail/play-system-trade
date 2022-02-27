namespace Play.Catalog.Contracts.Dtos;

public class CatalogItemUpdatedDto
{
    public Guid CatalogItemId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

