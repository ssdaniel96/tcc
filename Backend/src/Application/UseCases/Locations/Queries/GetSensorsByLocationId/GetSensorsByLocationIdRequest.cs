using Application.Shared.Dtos;
using Application.UseCases.Locations.Dtos;
using MediatR;

namespace Application.UseCases.Locations.Queries.GetSensorsByLocationId;

public record GetSensorsByLocationIdRequest : IRequest<ResponseDto<IEnumerable<SensorDto>>>
{
    public int LocationId { get; set; }

    public GetSensorsByLocationIdRequest()
    {
        
    }

    public GetSensorsByLocationIdRequest(int locationId)
    {
        LocationId = locationId;
    }
}