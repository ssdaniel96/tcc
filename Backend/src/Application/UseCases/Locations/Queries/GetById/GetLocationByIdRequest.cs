using Application.Shared.Dtos;
using Application.UseCases.Locations.Dtos;
using MediatR;

namespace Application.UseCases.Locations.Queries.GetById;

public record GetLocationByIdRequest : IRequest<ResponseDto<LocationDto?>>
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