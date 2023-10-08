using Application.Shared.Dtos;
using Application.UseCases.Events.Dtos;
using Domain.Repositories.Dtos;
using MediatR;

namespace Application.UseCases.Events.Queries.Get;

public sealed record GetEventRequest : IRequest<ResponseDto<PageResponse<EventHistoryDto>>>
{
    public PageRequest PageRequest { get; init; } = new(1, 25);
    public string RfTag { get; init; } = string.Empty;
    public int LocationId { get; init; }
}
