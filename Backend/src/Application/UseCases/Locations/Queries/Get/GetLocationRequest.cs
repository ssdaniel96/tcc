using Application.Shared.Dtos;
using Application.UseCases.Locations.Dtos;
using MediatR;

namespace Application.UseCases.Locations.Queries.Get;

public sealed record GetLocationRequest : IRequest<ResponseDto<IEnumerable<LocationDto>>>
{
}
