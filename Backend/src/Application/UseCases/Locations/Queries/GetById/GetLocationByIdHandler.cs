using Application.Shared.Dtos;
using Application.UseCases.Locations.Dtos;
using AutoMapper;
using Domain.Repositories.Locations;
using MediatR;

namespace Application.UseCases.Locations.Queries.GetById;

public class GetLocationByIdHandler : IRequestHandler<GetLocationByIdRequest, ResponseDto<LocationDto?>>
{
    private readonly IMapper _mapper;
    private readonly ILocationRepository _locationRepository;

    public GetLocationByIdHandler(ILocationRepository locationRepository, IMapper mapper)
    {
        _locationRepository = locationRepository;
        _mapper = mapper;
    }

    public async Task<ResponseDto<LocationDto?>> Handle(GetLocationByIdRequest request, CancellationToken cancellationToken)
    {
        var entity = await _locationRepository.GetByIdAsync(request.Id);

        var dto = _mapper.Map<LocationDto?>(entity);

        return new(dto);
    }
}