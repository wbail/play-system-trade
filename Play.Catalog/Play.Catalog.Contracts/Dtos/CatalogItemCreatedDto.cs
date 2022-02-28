﻿namespace Play.Catalog.Contracts.Dtos;

public class CatalogItemCreatedDto
{
    public CatalogItemCreatedDto(Guid catalogItemId, string name, string description)
    {
        CatalogItemId = catalogItemId;
        Name = name;
        Description = description;
    }

    public Guid CatalogItemId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
