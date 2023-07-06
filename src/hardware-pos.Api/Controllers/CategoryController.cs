using hardware_pos.Application;
using hardware_pos.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace hardware_pos.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly CategoryApplicationService _categoryApplicationService;

    public CategoryController(CategoryApplicationService categoryApplicationService)
    {
        _categoryApplicationService = categoryApplicationService;
    }
    
    [HttpPost("")]
    public async Task<IActionResult> CreateCategory(CreateCategoryCommand createCategoryCommand)
    {
        await _categoryApplicationService.CreateCategory(createCategoryCommand);
        
        return Ok();
    }
}