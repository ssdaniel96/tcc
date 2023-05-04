using Application.Dtos;
using Application.UseCases.Equipments.Queries.Get;
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
    public async Task<ActionResult<IEnumerable<EquipmentDto>>> Get([FromQuery] GetEquipmentRequest request)
    {
        var dtos = await _mediator.Send(request);

        return Ok(dtos);
    }
}
