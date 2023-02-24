using MediatR;
using Microsoft.AspNetCore.Mvc;
using Parsian.Command;

namespace Parsian.Application.Controllers;

[ApiController]
[Route("[controller]")]
public class VehicleController : ControllerBase
{
    private readonly IMediator _mediator;

    public VehicleController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> Post(RegisterVehicleCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
}