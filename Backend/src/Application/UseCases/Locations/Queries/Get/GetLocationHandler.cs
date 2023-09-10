using Application.Shared.Dtos;
using Application.UseCases.Locations.Dtos;
using AutoMapper;
using Domain.Repositories.Dtos;
using Domain.Repositories.Locations;
using MediatR;

namespace Application.UseCases.Locations.Queries.Get;

public sealed class GetLocationHandler : IRequestHandler<GetLocationRequest, ResponseDto<PageResponse<LocationDto>>>
{
    private readonly ILocationRepository _locationRepository;
    private readonly IMapper _mapper;

    public GetLocationHandler(ILocationRepository locationRepository, IMapper mapper)
    {
        _locationRepository = locationRepository;
        _mapper = mapper;
    }

    public async Task<ResponseDto<PageResponse<LocationDto>>> Handle(GetLocationRequest request, CancellationToken cancellationToken)
    {
        var response = await _locationRepository.GetAsync(request.PageRequest);

        var responseDtos = _mapper.Map<PageResponse<LocationDto>>(response);
        
        return new(responseDtos);
    }
}
