using Application.Shared.Dtos;
using Application.UseCases.Equipments.Dtos;
using AutoMapper;
using Domain.Repositories.Equipments;
using MediatR;

namespace Application.UseCases.Equipments.Queries.Get;

public sealed class GetEquipmentHandler : IRequestHandler<GetEquipmentRequest, ResponseDto<IEnumerable<EquipmentDto>>>
{
    private readonly IEquipmentRepository _equipmentRepository;
    private readonly IMapper _mapper;

    public GetEquipmentHandler(IEquipmentRepository equipmentRepository, IMapper mapper)
    {
        _equipmentRepository = equipmentRepository;
        _mapper = mapper;
    }

    public async Task<ResponseDto<IEnumerable<EquipmentDto>>> Handle(GetEquipmentRequest request, CancellationToken cancellationToken)
    {
        var entities = await _equipmentRepository.GetAsync();

        var dtos = _mapper.Map<IEnumerable<EquipmentDto>>(entities);

        return new(dtos);
    }
}
