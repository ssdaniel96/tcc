using Application.Shared.Dtos;
using Application.UseCases.Locations.Dtos;
using MediatR;

namespace Application.UseCases.Locations.Commands.AddSensor;

public record AddSensorRequest : IRequest<ResponseDto<SensorDto>>
{
    public string Description { get; set; } = string.Empty;
    public int LocationId { get; set; }
}