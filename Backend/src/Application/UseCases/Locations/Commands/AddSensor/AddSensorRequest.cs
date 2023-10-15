using Application.Shared.Dtos;
using Application.UseCases.Locations.Dtos;
using MediatR;

namespace Application.UseCases.Locations.Commands.AddSensor;

public record AddSensorRequest : IRequest<ResponseDto<SensorDto>>
{

    public int Id { get; init; }
    public string Description { get; init; } = string.Empty;
    public int LocationId { get; init; }
}