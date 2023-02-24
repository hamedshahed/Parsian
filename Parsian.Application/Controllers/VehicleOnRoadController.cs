using Microsoft.AspNetCore.Mvc;
using Parsian.QueryService.Modules;

namespace Parsian.Application.Controllers;

[ApiController]
[Route("Vehicle")]
public class VehicleOnRoadController : ControllerBase
{
    private readonly IVehicleQueryService _vehicleQueryService;

    public VehicleOnRoadController(IVehicleQueryService vehicleQueryService)
    {
        _vehicleQueryService = vehicleQueryService;
    }

    [HttpGet]
    [Route("/{vehicleId:guid}/position")]
    public async Task<IActionResult> GetPosition(Guid vehicleId)
    {
        return Ok(await _vehicleQueryService.GetCurrentPosition(vehicleId));
    }

    [HttpGet]
    [Route("/{vehicleId:guid}/positions")]
    public async Task<IActionResult> GetPositions(Guid vehicleId, DateTime start, DateTime end)
    {
        return Ok(await _vehicleQueryService.GetPositions(vehicleId, start, end));
    }
}