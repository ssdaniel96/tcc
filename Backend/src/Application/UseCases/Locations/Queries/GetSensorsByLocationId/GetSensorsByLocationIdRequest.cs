using Application.Shared.Dtos;
using Application.UseCases.Locations.Dtos;
using Domain.Repositories.Dtos;
using MediatR;

namespace Application.UseCases.Locations.Queries.GetSensorsByLocationId;

public record GetSensorsByLocationIdRequest : IRequest<ResponseDto<PageResponse<SensorDto>>>
{
    public int LocationId { get; init; }
    public PageRequest PageRequest { get; init; } = new();
    
    public GetSensorsByLocationIdRequest()
    {    
    }

    public GetSensorsByLocationIdRequest(int locationId, PageRequest pageRequest)
    {
        LocationId = locationId;
        PageRequest = pageRequest;
    }
}