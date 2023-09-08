using Application.UseCases.Equipments.Dtos;
using AutoMapper;
using Domain.Entities.Equipments;
using Domain.Repositories.Equipments;
using MediatR;

namespace Application.UseCases.Equipments.Commands.Insert;

public class InsertEquipmentHandler : IRequestHandler<InsertEquipmentRequest, EquipmentDto>
{
    private readonly IEquipmentRepository _equipmentRepository;
    private readonly IMapper _mapper;

    public InsertEquipmentHandler(IEquipmentRepository equipmentRepository, IMapper mapper)
    {
        _equipmentRepository = equipmentRepository;
        _mapper = mapper;
    }

    public async Task<EquipmentDto> Handle(InsertEquipmentRequest request, CancellationToken cancellationToken)
    {
        var entity = new Equipment(request.RfTag, request.Description);
        entity = await _equipmentRepository.InsertAsync(entity);
        return _mapper.Map<EquipmentDto>(entity);
    }
}