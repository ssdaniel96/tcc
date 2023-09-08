using Application.UseCases.Equipments.Dtos;
using MediatR;

namespace Application.UseCases.Equipments.Commands.Insert;

public record InsertEquipmentRequest : IRequest<EquipmentDto>
{
    public string? RfTag { get; set; }
    public string? Description { get; set; }

    public InsertEquipmentRequest()
    {
    }

    public InsertEquipmentRequest(string description, string? rfTag)
    {
        Description = description;
        RfTag = rfTag;
    }
}