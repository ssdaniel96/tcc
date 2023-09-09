using Application.Shared.Dtos;
using Application.UseCases.Locations.Dtos;
using AutoMapper;
using Domain.Entities.Locations;
using Domain.Repositories.Locations;
using MediatR;

namespace Application.UseCases.Locations.Commands.Insert;

public class InsertLocationHandler : IRequestHandler<InsertLocationRequest, ResponseDto<LocationDto>>
{
    private readonly IBuildingRepository _buildingRepository;
    private readonly IAddressRepository _addressRepository;
    private readonly ILocationRepository _locationRepository;
    private readonly IMapper _mapper;

    public InsertLocationHandler(IBuildingRepository buildingRepository, IAddressRepository addressRepository,
        ILocationRepository locationRepository, IMapper mapper)
    {
        _buildingRepository = buildingRepository;
        _addressRepository = addressRepository;
        _locationRepository = locationRepository;
        _mapper = mapper;
    }

    public async Task<ResponseDto<LocationDto>> Handle(InsertLocationRequest request, CancellationToken cancellationToken)
    {
        var address = await GetOrCreateAddress(request.Building.Address);
        var building = await GetOrCreateBuilding(request.Building, address);

        var entity = new Location(request.Description, request.Level, building);
        entity = await _locationRepository.InsertAsync(entity);

        var dto = _mapper.Map<LocationDto>(entity);

        return new(dto);
    }

    private async Task<Building> GetOrCreateBuilding(BuildingDto buildingDto, Address address)
    {
        if (buildingDto.Id == 0)
        {
            var entity = new Building(address, buildingDto.Description);
            return await _buildingRepository.InsertAsync(entity);
        }

        return await _buildingRepository.GetByIdAsync(buildingDto.Id)
               ?? throw new ArgumentNullException($"Invalid building Id {buildingDto.Id}");
    }

    private async Task<Address> GetOrCreateAddress(AddressDto addressDto)
    {
        if (addressDto.Id == 0)
        {
            var entity = new Address(addressDto.ZipCode, addressDto.Number, addressDto.Complement, addressDto.Observation);
            return await _addressRepository.InsertAsync(entity);
        }

        return await _addressRepository.GetByIdAsync(addressDto.Id)
               ?? throw new ArgumentNullException($"Invalid address Id {addressDto.Id}");
    }
}