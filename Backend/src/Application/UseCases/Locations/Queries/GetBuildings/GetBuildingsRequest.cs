﻿using Application.Shared.Dtos;
using Application.UseCases.Locations.Dtos;
using MediatR;

namespace Application.UseCases.Locations.Queries.GetBuildings;

public record GetBuildingsRequest : IRequest<ResponseDto<IEnumerable<BuildingDto>>>
{
    public int AddressId { get; init; }
    
}