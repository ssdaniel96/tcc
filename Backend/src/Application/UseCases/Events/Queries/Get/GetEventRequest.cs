using Application.UseCases.Events.Dtos;
using MediatR;

namespace Application.UseCases.Events.Queries.Get;

public sealed record GetEventRequest : IRequest<IEnumerable<EventDto>>
{
    public string RFTag { get; init; } = string.Empty;
    public int LocationId { get; init; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}
