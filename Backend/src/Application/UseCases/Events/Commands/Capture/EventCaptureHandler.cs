﻿using Application.Shared.Dtos;
using Domain.Entities.Events;
using Domain.Repositories.Equipments;
using Domain.Repositories.Events;
using Domain.Repositories.Locations;
using MediatR;

namespace Application.UseCases.Events.Commands.Capture;

public sealed class EventCaptureHandler : IRequestHandler<EventCaptureRequest, ResponseDto>
{
    private readonly IEventRepository _eventRepository;
    private readonly IEquipmentRepository _equipmentRepository;
    private readonly ILocationRepository _locationRepository;

    public EventCaptureHandler(
        IEventRepository eventRepository,
        IEquipmentRepository equipmentRepository,
        ILocationRepository locationRepository)
    {
        _eventRepository = eventRepository;
        _equipmentRepository = equipmentRepository;
        _locationRepository = locationRepository;
    }

    public async Task<ResponseDto> Handle(EventCaptureRequest request, CancellationToken cancellationToken)
    {
        var equipment = await _equipmentRepository.GetByRFTagAsync(request.RfTag) ??
            throw new ArgumentException($"Equipamento [{request.RfTag}] não encontrado");

        var location = await _locationRepository.GetByIdAsync(request.LocationId) ??
            throw new ArgumentException($"Location [{request.LocationId}] não encontrado");

        var entity = new Event(location, equipment, request.Vector);

        await _eventRepository.InsertAsync(entity);

        return new()
        {
            IsSuccessfully = true
        };
    }
}
