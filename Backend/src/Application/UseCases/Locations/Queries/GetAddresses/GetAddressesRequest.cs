using Application.Shared.Dtos;
using Application.UseCases.Locations.Dtos;
using MediatR;

namespace Application.UseCases.Locations.Queries.GetAddresses;

public record GetAddressesRequest : IRequest<ResponseDto<IEnumerable<AddressDto>>>
{
    public string? Filter { get; init; }
}