namespace Play.Inventory.Dtos;

public class CatalogItemDto
{
    public CatalogItemDto(Guid id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
