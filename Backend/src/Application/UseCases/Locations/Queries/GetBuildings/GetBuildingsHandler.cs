using Application.Shared.Dtos;
using Application.UseCases.Locations.Dtos;
using AutoMapper;
using Domain.Repositories.Locations;
using MediatR;

namespace Application.UseCases.Locations.Queries.GetBuildings;

public class GetBuildingsHandler : IRequestHandler<GetBuildingsRequest, ResponseDto<IEnumerable<BuildingDto>>>
{
    private readonly IMapper _mapper;
    private readonly IBuildingRepository _buildingRepository;

    public GetBuildingsHandler(IMapper mapper, IBuildingRepository buildingRepository)
    {
        _mapper = mapper;
        _buildingRepository = buildingRepository;
    }

    public async Task<ResponseDto<IEnumerable<BuildingDto>>> Handle(GetBuildingsRequest request, CancellationToken cancellationToken)
    {
        var entities = await _buildingRepository.GetAsync(request.AddressId);

        var dtos = _mapper.Map<IEnumerable<BuildingDto>>(entities);

        return new(dtos);

    }
}