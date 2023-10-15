using Application.Shared.Dtos;
using Application.UseCases.Locations.Dtos;
using Domain.Repositories.Dtos;
using MediatR;

namespace Application.UseCases.Locations.Queries.Get;

public sealed record GetLocationRequest : IRequest<ResponseDto<PageResponse<LocationDto>>>
{
    public int BuildingId { get; init; } = 0;
    public string? Filter { get; init; } 
    public PageRequest PageRequest { get; init; } = new();
}
