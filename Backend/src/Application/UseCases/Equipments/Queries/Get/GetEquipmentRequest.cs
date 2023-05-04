using Application.Dtos;
using MediatR;

namespace Application.UseCases.Equipments.Queries.Get;

public sealed record GetEquipmentRequest : IRequest<IEnumerable<EquipmentDto>>
{
}
