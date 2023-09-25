using Application.Shared.Dtos;
using Application.UseCases.Events.Dtos;
using MediatR;

namespace Application.UseCases.Events.Queries.Get;

public sealed record GetEventRequest : IRequest<ResponseDto<IEnumerable<EventHistoryDto>>>
{
    public string RFTag { get; init; } = string.Empty;
    public int LocationId { get; init; }
    public int PageSize { get; init; } = 25;
    public int PageNumber { get; init; } = 1;
}
