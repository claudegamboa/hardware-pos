using hardware_pos.Application;
using hardware_pos.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace hardware_pos.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    private readonly ILogger<ItemController> _logger;
    private readonly ItemApplicationService _itemApplicationService;

    public ItemController(ILogger<ItemController> logger, ItemApplicationService itemApplicationService)
    {
        _logger = logger;
        _itemApplicationService = itemApplicationService;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateItem(CreateItemCommand createItemCommand)
    {
        await _itemApplicationService.CreateItem(createItemCommand);
        
        return Ok();
    }
}
