using Application.Shared.Dtos;
using Application.UseCases.Locations.Dtos;
using AutoMapper;
using Domain.Repositories.Dtos;
using Domain.Repositories.Sensors;
using MediatR;

namespace Application.UseCases.Locations.Queries.GetSensorsByLocationId;

public class GetSensorsByLocationIdHandler : IRequestHandler<GetSensorsByLocationIdRequest, ResponseDto<PageResponse<SensorDto>>>
{
    private readonly IMapper _mapper;
    private readonly ISensorRepository _sensorRepository;

    public GetSensorsByLocationIdHandler(IMapper mapper, ISensorRepository sensorRepository)
    {
        _mapper = mapper;
        _sensorRepository = sensorRepository;
    }

    public async Task<ResponseDto<PageResponse<SensorDto>>> Handle(GetSensorsByLocationIdRequest request, CancellationToken cancellationToken)
    {
        var entities = await _sensorRepository.GetAsync(request.LocationId, request.PageRequest);

        var response = _mapper.Map<PageResponse<SensorDto>>(entities);

        return new(response);
    }
}