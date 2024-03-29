﻿using Application.Shared.Dtos;
using Domain.Repositories.Locations;
using MediatR;

namespace Application.UseCases.Locations.Commands.Remove;

public class RemoveLocationHandler : IRequestHandler<RemoveLocationRequest, ResponseDto>
{
    private readonly ILocationRepository _locationRepository;

    public RemoveLocationHandler(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public async Task<ResponseDto> Handle(RemoveLocationRequest request, CancellationToken cancellationToken)
    {
        var entity = await _locationRepository.GetByIdAsync(request.Id)
            ?? throw new ArgumentNullException($"Localizacao com Id {request.Id} não existe");

        await _locationRepository.RemoveAsync(entity);

        return new()
        {
            IsSuccessfully = true
        };
    }
}