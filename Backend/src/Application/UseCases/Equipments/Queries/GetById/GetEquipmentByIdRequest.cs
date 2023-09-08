using Application.UseCases.Equipments.Dtos;
using MediatR;

namespace Application.UseCases.Equipments.Queries.GetById;

public record GetEquipmentByIdRequest : IRequest<EquipmentDto?>
{
    public int Id { get; set; }

    public GetEquipmentByIdRequest(int id)
    {
        Id = id;
    }

    public GetEquipmentByIdRequest()
    {
        
    }
}