using System.ComponentModel.DataAnnotations;

namespace Play.Catalog.Service.Dtos;

public class CreateItemDto
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    public decimal Price { get; set; }
}
