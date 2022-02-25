using System.ComponentModel.DataAnnotations;

namespace Play.Catalog.Service.Dtos;

public class UpdateItemDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public decimal Price { get; set; }
}
