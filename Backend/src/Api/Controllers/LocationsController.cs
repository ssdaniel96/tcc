using Application.Dtos;
using Application.UseCases.Locations.Queries.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LocationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]

    public async Task<ActionResult<IEnumerable<LocationDto>>> Get([FromQuery] GetLocationRequest request)
    {
        var dtos = await _mediator.Send(request);

        return Ok(dtos);
    }
}
