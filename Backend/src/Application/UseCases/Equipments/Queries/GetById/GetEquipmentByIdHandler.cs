using Application.UseCases.Equipments.Dtos;
using AutoMapper;
using Domain.Repositories.Equipments;
using MediatR;

namespace Application.UseCases.Equipments.Queries.GetById;

public class GetEquipmentByIdHandler : IRequestHandler<GetEquipmentByIdRequest, EquipmentDto?>
{
    private readonly IMapper _mapper;
    private readonly IEquipmentRepository _equipmentRepository;

    public GetEquipmentByIdHandler(IMapper mapper, IEquipmentRepository equipmentRepository)
    {
        _mapper = mapper;
        _equipmentRepository = equipmentRepository;
    }

    public async Task<EquipmentDto?> Handle(GetEquipmentByIdRequest request, CancellationToken cancellationToken)
    {
        var entity = await _equipmentRepository.GetByIdAsync(request.Id);

        return _mapper.Map<EquipmentDto?>(entity);
    }
}