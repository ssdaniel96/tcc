using Application.Dtos;
using MediatR;

namespace Application.UseCases.Locations.Queries.Get;

public sealed record GetLocationRequest : IRequest<IEnumerable<LocationDto>>
{
}
