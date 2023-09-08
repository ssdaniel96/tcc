using Application.UseCases.Locations.Commands.Insert;
using Application.UseCases.Locations.Dtos;
using Application.UseCases.Locations.Queries.Get;
using Application.UseCases.Locations.Queries.GetById;
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

    [HttpGet("{id:int}", Name = "GetLocationById")]
    public async Task<ActionResult<LocationDto>> GetById([FromRoute] int id)
    {
        var request = new GetLocationByIdRequest(id);
        var response = await _mediator.Send(request);

        if (response == null)
            return NotFound();
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<LocationDto>> Insert([FromBody] InsertLocationRequest request)
    {
        var response = await _mediator.Send(request);

        return CreatedAtRoute("GetLocationById", new { id = response.Id }, response);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        var request = new GetLocationByIdRequest(id);
        await _mediator.Send(request);

        return NoContent();
    }
}
