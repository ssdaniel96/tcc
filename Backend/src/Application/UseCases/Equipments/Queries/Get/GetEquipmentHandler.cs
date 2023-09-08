using Application.UseCases.Equipments.Dtos;
using AutoMapper;
using Domain.Repositories.Equipments;
using MediatR;

namespace Application.UseCases.Equipments.Queries.Get;

public sealed class GetEquipmentHandler : IRequestHandler<GetEquipmentRequest, IEnumerable<EquipmentDto>>
{
    private readonly IEquipmentRepository _equipmentRepository;
    private readonly IMapper _mapper;

    public GetEquipmentHandler(IEquipmentRepository equipmentRepository, IMapper mapper)
    {
        _equipmentRepository = equipmentRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EquipmentDto>> Handle(GetEquipmentRequest request, CancellationToken cancellationToken)
    {
        var entities = await _equipmentRepository.GetAsync();

        var dtos = _mapper.Map<IEnumerable<EquipmentDto>>(entities);

        return dtos;
    }
}
