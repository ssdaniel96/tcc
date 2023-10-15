using Application.Extensions;
using Application.Shared.Dtos;
using Application.UseCases.Locations.Dtos;
using AutoMapper;
using Domain.Repositories.Locations;
using MediatR;

namespace Application.UseCases.Locations.Queries.GetAddresses;

public class GetAddressesHandler : IRequestHandler<GetAddressesRequest, ResponseDto<IEnumerable<AddressDto>>>
{
    private readonly IMapper _mapper;
    private readonly IAddressRepository _addressRepository;

    public GetAddressesHandler(IMapper mapper, IAddressRepository addressRepository)
    {
        _mapper = mapper;
        _addressRepository = addressRepository;
    }

    public async Task<ResponseDto<IEnumerable<AddressDto>>> Handle(GetAddressesRequest request, CancellationToken cancellationToken)
    {
        var entities = await _addressRepository.GetAsync(request.Filter.GetOnlyAlfaNumerics());

        var dtos = _mapper.Map<IEnumerable<AddressDto>>(entities);

        return new(dtos);
    }
}