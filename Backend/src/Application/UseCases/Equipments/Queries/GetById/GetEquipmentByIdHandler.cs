using Application.Shared.Dtos;
using Application.UseCases.Equipments.Dtos;
using AutoMapper;
using Domain.Repositories.Equipments;
using MediatR;

namespace Application.UseCases.Equipments.Queries.GetById;

public class GetEquipmentByIdHandler : IRequestHandler<GetEquipmentByIdRequest, ResponseDto<EquipmentDto?>>
{
    private readonly IMapper _mapper;
    private readonly IEquipmentRepository _equipmentRepository;

    public GetEquipmentByIdHandler(IMapper mapper, IEquipmentRepository equipmentRepository)
    {
        _mapper = mapper;
        _equipmentRepository = equipmentRepository;
    }

    public async Task<ResponseDto<EquipmentDto?>> Handle(GetEquipmentByIdRequest request, CancellationToken cancellationToken)
    {
        var entity = await _equipmentRepository.GetByIdAsync(request.Id);

        var dto = _mapper.Map<EquipmentDto?>(entity);

        return new(dto);
    }
}