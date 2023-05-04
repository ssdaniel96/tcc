using Application.Dtos;
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
    /// <returns></returns>
    [HttpPost]
    public ActionResult Capture()
    {
        return Ok();
    }


    /// <summary>
    /// Recuperar toda lista de eventos
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EventDto>>> Get(GetEventRequest request)
    {
        var dtos = await _mediator.Send(request);

        return Ok(dtos);
    }
}
