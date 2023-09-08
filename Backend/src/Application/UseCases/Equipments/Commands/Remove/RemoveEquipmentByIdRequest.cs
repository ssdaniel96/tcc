using MediatR;

namespace Application.UseCases.Equipments.Commands.Remove;

public record RemoveEquipmentByIdRequest : IRequest
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