using Application.Dtos;
using AutoMapper;
using Domain.Repositories.Events;
using MediatR;

namespace Application.UseCases.Events.Queries.Get
{
    public sealed class GetEventHandler : IRequestHandler<GetEventRequest, IEnumerable<EventDto>>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public GetEventHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventDto>> Handle(GetEventRequest request, CancellationToken cancellationToken)
        {
            var entities = await _eventRepository.GetAsync(
                request.RFTag,
                request.LocationId,
                request.PageNumber,
                request.PageSize);

            var dtos = _mapper.Map<IEnumerable<EventDto>>(entities);

            return dtos;
        }
    }
}
