using Application.UseCases.Locations.Dtos;
using AutoMapper;
using Domain.Repositories.Locations;
using MediatR;

namespace Application.UseCases.Locations.Queries.Get;

public sealed class GetLocationHandler : IRequestHandler<GetLocationRequest, IEnumerable<LocationDto>>
{
    private readonly ILocationRepository _locationRepository;
    private readonly IMapper _mapper;

    public GetLocationHandler(ILocationRepository locationRepository, IMapper mapper)
    {
        _locationRepository = locationRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LocationDto>> Handle(GetLocationRequest request, CancellationToken cancellationToken)
    {
        var entities = await _locationRepository.GetAsync();

        var dtos = _mapper.Map<IEnumerable<LocationDto>>(entities);

        return dtos;
    }
}
