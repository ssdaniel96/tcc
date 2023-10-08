using Application.Shared.Dtos;
using Application.UseCases.Events.Dtos;
using AutoMapper;
using Domain.Repositories.Dtos;
using Domain.Repositories.Events;
using MediatR;

namespace Application.UseCases.Events.Queries.Get;

public sealed class GetEventHandler : IRequestHandler<GetEventRequest, ResponseDto<PageResponse<EventHistoryDto>>>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;

    public GetEventHandler(IEventRepository eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }

    public async Task<ResponseDto<PageResponse<EventHistoryDto>>> Handle(GetEventRequest request,
        CancellationToken cancellationToken)
    {
        var entities = await _eventRepository.GetAsync(
            request.PageRequest,
            request.EquipmentId,
            request.VectorId,
            request.AddressId,
            request.BuildingId,
            request.LocationId,
            request.SensorId);

        var pagedResult = _mapper.Map<PageResponse<EventHistoryDto>>(entities);

        return new(pagedResult);
    }
}