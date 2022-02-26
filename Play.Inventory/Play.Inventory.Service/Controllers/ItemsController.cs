using Microsoft.AspNetCore.Mvc;
using Play.Common;
using Play.Inventory.Service.Dtos;
using Play.Inventory.Service.Entities;
using Play.Inventory.Service.Extensions;

namespace Play.Inventory.Service.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly IRepository<InventoryItem> _inventoryItemRepository;

    public ItemsController(IRepository<InventoryItem> inventoryItemRepository)
    {
        _inventoryItemRepository = inventoryItemRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<InventoryItemDto>>> GetAsync(Guid userId)
    {
        if (userId == Guid.Empty)
        {
            return BadRequest();
        }

        var items = (await _inventoryItemRepository.GetAllAsync(item => item.UserId == userId)).Select(item => item.AdDto());

        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<InventoryItemDto>> GetByIdAsync(Guid id)
    {
        var inventoryItem = await _inventoryItemRepository.GetAsync(id);

        if (inventoryItem == null)
        {
            return BadRequest();
        }

        return Ok(inventoryItem);
    }

    [HttpPost]
    public async Task<ActionResult> PostAsync(GrantItemsDto grantItemsDto)
    {
        var inventoryItem = await _inventoryItemRepository.GetAsync(item => item.UserId == grantItemsDto.UserId 
            && item.CatalogItemId == grantItemsDto.CatalogItemId);

        if (inventoryItem == null)
        {
            inventoryItem = new InventoryItem
            {
                CatalogItemId = grantItemsDto.CatalogItemId,
                UserId = grantItemsDto.UserId,
                Quantity = grantItemsDto.Quantity,
                AcquiredAt = DateTime.UtcNow
            };

            await _inventoryItemRepository.CreateAsync(inventoryItem);

            //return CreatedAtAction(nameof(GetByIdAsync), new { id = inventoryItem.Id }, inventoryItem);
            return Ok(inventoryItem);
        }
        else
        {
            inventoryItem.Quantity += grantItemsDto.Quantity;
            await _inventoryItemRepository.UpdateAsync(inventoryItem);
            return Ok(inventoryItem);
        }
    }
}
