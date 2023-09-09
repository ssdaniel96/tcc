using Application.Shared.Dtos;
using MediatR;

namespace Application.UseCases.Equipments.Commands.Remove;

public record RemoveEquipmentByIdRequest : IRequest<ResponseDto>
{
    public int Id { get; set; }

    public RemoveEquipmentByIdRequest()
    {
        
    }

    public RemoveEquipmentByIdRequest(int id)
    {
        Id = id;
    }
}