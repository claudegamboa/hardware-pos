using hardware_pos.Application;
using hardware_pos.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace hardware_pos.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UnitOfMeasureController : ControllerBase
{
    private readonly UnitOfMeasureApplicationService _unitOfMeasureApplicationService;

    public UnitOfMeasureController(UnitOfMeasureApplicationService unitOfMeasureApplicationService)
    {
        _unitOfMeasureApplicationService = unitOfMeasureApplicationService;
    }
    
    [HttpPost("")]
    public async Task<IActionResult> CreateUnitOfMeasure(CreateUnitOfMeasureCommand createUnitOfMeasureCommand)
    {
        await _unitOfMeasureApplicationService.CreateUnitOfMeasure(createUnitOfMeasureCommand);
        
        return Ok();
    }
}