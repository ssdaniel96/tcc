using Application.Shared.Dtos;
using Application.UseCases.Equipments.Commands.Insert;
using Application.UseCases.Equipments.Commands.Remove;
using Application.UseCases.Equipments.Dtos;
using Application.UseCases.Equipments.Queries.Get;
using Application.UseCases.Equipments.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EquipmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public EquipmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseDto<IEnumerable<EquipmentDto>>>> Get([FromQuery] GetEquipmentRequest request)
    {
        var dtos = await _mediator.Send(request);

        return Ok(dtos);
    }

    [HttpGet("{id:int}", Name = "GetEquipmentById")]
    public async Task<ActionResult<ResponseDto<EquipmentDto>>> GetById([FromRoute] int id)
    {
        var request = new GetEquipmentByIdRequest(id);
        var response = await _mediator.Send(request);
        
        
        return Ok(response);
        

    }
    
    [HttpPost]
    public async Task<ActionResult<ResponseDto<EquipmentDto>>> Insert([FromBody] InsertEquipmentRequest request)
    {
        var response = await _mediator.Send(request);

        return CreatedAtRoute("GetEquipmentById", new { id = response.Data!.Id }, response);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ResponseDto>> Remove([FromRoute] int id)
    {
        var request = new RemoveEquipmentByIdRequest(id);
        var response = await _mediator.Send(request);

        return Ok(response);

    }

}
