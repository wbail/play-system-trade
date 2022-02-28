namespace Play.Catalog.Contracts.Dtos;

public class CatalogItemDeletedDto
{
    public CatalogItemDeletedDto(Guid catalogItemId)
    {
        CatalogItemId = catalogItemId;
    }

    public Guid CatalogItemId { get; set; }
}
