using Application.Shared.Dtos;
using Application.UseCases.Events.Dtos;
using Domain.Repositories.Dtos;
using MediatR;

namespace Application.UseCases.Events.Queries.Get;

public sealed record GetEventRequest : IRequest<ResponseDto<PageResponse<EventHistoryDto>>>
{
    // public PageRequest PageRequest { get; init; } = new(1, 25);
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 100;
    public int SensorId { get; init; }
    public int LocationId { get; init; }
    public int BuildingId { get; init; }
    public int AddressId { get; init; }
    public int VectorId { get; init; }
    public int EquipmentId { get; init; }
    public DateTime StartDatetime { get; init; } = new DateTime(2023, 1, 1);
    public DateTime EndDatetime { get; init; } = DateTime.Now;
}