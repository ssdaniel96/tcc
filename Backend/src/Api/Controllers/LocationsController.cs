using Application.Shared.Dtos;
using Application.UseCases.Locations.Commands.AddSensor;
using Application.UseCases.Locations.Commands.Insert;
using Application.UseCases.Locations.Commands.Remove;
using Application.UseCases.Locations.Commands.RemoveSensorById;
using Application.UseCases.Locations.Dtos;
using Application.UseCases.Locations.Queries.Get;
using Application.UseCases.Locations.Queries.GetAddresses;
using Application.UseCases.Locations.Queries.GetBuildings;
using Application.UseCases.Locations.Queries.GetById;
using Application.UseCases.Locations.Queries.GetSensorsByLocationId;
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
    public async Task<ActionResult<ResponseDto<IEnumerable<LocationDto>>>> Get([FromQuery] GetLocationRequest request)
    {
        var dtos = await _mediator.Send(request);

        return Ok(dtos);
    }

    [HttpGet("{id:int}", Name = "GetLocationById")]
    public async Task<ActionResult<ResponseDto<LocationDto>>> GetById([FromRoute] int id)
    {
        var request = new GetLocationByIdRequest(id);
        var response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<ResponseDto<LocationDto>>> Insert([FromBody] InsertLocationRequest request)
    {
        var response = await _mediator.Send(request);

        return CreatedAtRoute("GetLocationById", new { id = response.Data!.Id }, response);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ResponseDto>> Delete([FromRoute] int id)
    {
        var request = new RemoveLocationRequest(id);
        var response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpGet("addresses")]
    public async Task<ActionResult<ResponseDto<IEnumerable<AddressDto>>>> GetAddresses([FromRoute] GetAddressesRequest request)
    {
        var response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpGet("buildings")]
    public async Task<ActionResult<ResponseDto<IEnumerable<BuildingDto>>>> GetBuildings(
        [FromQuery] GetBuildingsRequest request)
    {
        var response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpGet("sensors/{id}")]
    public async Task<ActionResult<ResponseDto<IEnumerable<SensorDto>>>> GetSensors(int id)
    {
        var request = new GetSensorsByLocationIdRequest(id);

        var response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpDelete("sensors/{sensorId}")]
    public async Task<ActionResult<ResponseDto>> RemoveSensor(int sensorId)
    {
        var request = new RemoveSensorByIdRequest(sensorId);

        var response = await _mediator.Send(request);

        return response;
    }

    [HttpPost("sensors")]
    public async Task<ActionResult<ResponseDto<SensorDto>>> InsertSensor([FromBody] AddSensorRequest request)
    {
        var response = await _mediator.Send(request);

        return Ok(response);
    }
    
}
