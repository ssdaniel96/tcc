using Application.Shared.Dtos;
using Application.UseCases.Equipments.Dtos;
using MediatR;

namespace Application.UseCases.Equipments.Queries.Get;

public sealed record GetEquipmentRequest : IRequest<ResponseDto<IEnumerable<EquipmentDto>>>
{
}
