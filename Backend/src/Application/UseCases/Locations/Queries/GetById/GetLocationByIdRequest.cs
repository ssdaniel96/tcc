using Application.UseCases.Locations.Dtos;
using MediatR;

namespace Application.UseCases.Locations.Queries.GetById;

public record GetLocationByIdRequest : IRequest<LocationDto?>
{
    public int Id { get; set; }

    public GetLocationByIdRequest()
    {
        
    }
    
    public GetLocationByIdRequest(int id)
    {
        Id = id;
    }
}