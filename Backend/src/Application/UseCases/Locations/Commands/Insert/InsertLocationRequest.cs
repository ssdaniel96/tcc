using Application.Shared.Dtos;
using Application.UseCases.Locations.Dtos;
using MediatR;

namespace Application.UseCases.Locations.Commands.Insert;

public record InsertLocationRequest : IRequest<ResponseDto<LocationDto>>
{
    public string? Description { get; init; }
    public string? Level { get; init; }
    public BuildingDto? Building { get; init; }

    public InsertLocationRequest()
    {
        
    }

    public InsertLocationRequest(string? description, string? level, BuildingDto? building)
    {
        Description = description;
        Level = level;
        Building = building;
    }
}