using Application.Shared.Dtos;
using Domain.Entities.Events;
using Domain.Repositories.Equipments;
using Domain.Repositories.Events;
using Domain.Repositories.Locations;
using Domain.Repositories.Sensors;
using MediatR;

namespace Application.UseCases.Events.Commands.Capture;

public sealed class EventCaptureHandler : IRequestHandler<EventCaptureRequest, ResponseDto>
{
    private readonly IEventRepository _eventRepository;
    private readonly IEquipmentRepository _equipmentRepository;
    private readonly ISensorRepository _sensorRepository;
    public EventCaptureHandler(
        IEventRepository eventRepository,
        IEquipmentRepository equipmentRepository,
        ILocationRepository locationRepository, 
        ISensorRepository sensorRepository)
    {
        _eventRepository = eventRepository;
        _equipmentRepository = equipmentRepository;
        _sensorRepository = sensorRepository;
    }

    public async Task<ResponseDto> Handle(EventCaptureRequest request, CancellationToken cancellationToken)
    {
        var equipment = await _equipmentRepository.GetByRFTagAsync(request.RfTag) ??
            throw new ApplicationException($"Equipamento [{request.RfTag}] não encontrado");

        var sensor = await _sensorRepository.GetByIdAsync(request.SensorId) ??
            throw new ApplicationException($"Sensor [{request.SensorId}] não encontrado");;
        
        var entity = new Event(sensor, equipment, request.Vector);

        await _eventRepository.InsertAsync(entity);

        return new()
        {
            IsSuccessfully = true
        };
    }
}
