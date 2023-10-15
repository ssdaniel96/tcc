using Application.Shared.Dtos;
using Application.UseCases.Locations.Dtos;
using AutoMapper;
using Domain.Entities.Sensors;
using Domain.Repositories.Locations;
using Domain.Repositories.Sensors;
using MediatR;

namespace Application.UseCases.Locations.Commands.AddSensor;

public class AddSensorHandler : IRequestHandler<AddSensorRequest, ResponseDto<SensorDto>>
{
    private readonly IMapper _mapper;
    private readonly ISensorRepository _sensorRepository;
    private readonly ILocationRepository _locationRepository;

    public AddSensorHandler(ISensorRepository sensorRepository, IMapper mapper, ILocationRepository locationRepository)
    {
        _sensorRepository = sensorRepository;
        _mapper = mapper;
        _locationRepository = locationRepository;
    }

    public async Task<ResponseDto<SensorDto>> Handle(AddSensorRequest request, CancellationToken cancellationToken)
    {
        var location = await _locationRepository.GetByIdAsync(request.LocationId)
            ?? throw new ApplicationException($"A localização fornecida ({request.LocationId}) não existe!");

        var entity = new Sensor(request.Id, request.Description, location);

        entity = await _sensorRepository.InsertAsync(entity);

        var dto = _mapper.Map<SensorDto>(entity);

        return new(dto);
    }
}