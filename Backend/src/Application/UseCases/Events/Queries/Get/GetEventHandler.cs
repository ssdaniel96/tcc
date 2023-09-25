using Application.Shared.Dtos;
using Application.UseCases.Events.Dtos;
using AutoMapper;
using Domain.Repositories.Events;
using MediatR;

namespace Application.UseCases.Events.Queries.Get;

public sealed class GetEventHandler : IRequestHandler<GetEventRequest, ResponseDto<IEnumerable<EventHistoryDto>>>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;

    public GetEventHandler(IEventRepository eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }

    public async Task<ResponseDto<IEnumerable<EventHistoryDto>>> Handle(GetEventRequest request, CancellationToken cancellationToken)
    {
        var entities = await _eventRepository.GetAsync(
            request.RFTag,
            request.LocationId,
            request.PageNumber,
            request.PageSize);

        var dtos = _mapper.Map<IEnumerable<EventHistoryDto>>(entities);

        return new(dtos);
        }
}
