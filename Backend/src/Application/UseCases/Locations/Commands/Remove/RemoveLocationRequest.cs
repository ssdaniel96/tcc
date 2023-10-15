using Application.Shared.Dtos;
using MediatR;

namespace Application.UseCases.Locations.Commands.Remove;

public record RemoveLocationRequest : IRequest<ResponseDto>
{
    public int Id { get; init; }

    public RemoveLocationRequest()
    {
        
    }

    public RemoveLocationRequest(int id)
    {
        Id = id;
    }
}