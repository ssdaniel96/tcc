using Application.Shared.Dtos;
using Application.UseCases.Events.Commands.Capture;
using Application.UseCases.Events.Dtos;
using Application.UseCases.Events.Queries.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventsController : ControllerBase
{

    private readonly IMediator _mediator;

    public EventsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Salvar a captura de um evento
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<ResponseDto>> Capture([FromBody] EventCaptureRequest request)
    {
        var response = await _mediator.Send(request);

        return Ok(response);
    }


    /// <summary>
    /// Recuperar lista de eventos com filtro
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<ResponseDto<IEnumerable<EventDto>>>> Get([FromQuery] GetEventRequest request)
    {
        var dtos = await _mediator.Send(request);

        return Ok(dtos);
    }
}
