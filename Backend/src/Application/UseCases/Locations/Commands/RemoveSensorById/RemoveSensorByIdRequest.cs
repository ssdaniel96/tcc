using Application.Shared.Dtos;
using MediatR;

namespace Application.UseCases.Locations.Commands.RemoveSensorById;

public record RemoveSensorByIdRequest : IRequest<ResponseDto>
{
    public int Id { get; init; }

    public RemoveSensorByIdRequest()
    {
        
    }

    public RemoveSensorByIdRequest(int id)
    {
        Id = id;
    }
}