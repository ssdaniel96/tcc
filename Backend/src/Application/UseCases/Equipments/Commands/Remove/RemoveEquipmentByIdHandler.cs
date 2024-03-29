﻿using Application.Shared.Dtos;
using Application.UseCases.Equipments.Dtos;
using AutoMapper;
using Domain.Repositories.Equipments;
using MediatR;

namespace Application.UseCases.Equipments.Commands.Remove;

public class RemoveEquipmentByIdHandler : IRequestHandler<RemoveEquipmentByIdRequest, ResponseDto>
{
    private readonly IEquipmentRepository _equipmentRepository;


    public RemoveEquipmentByIdHandler(IEquipmentRepository equipmentRepository)
    {
        _equipmentRepository = equipmentRepository;
    }

    public async Task<ResponseDto> Handle(RemoveEquipmentByIdRequest request, CancellationToken cancellationToken)
    {
        var entity = await _equipmentRepository.GetByIdAsync(request.Id);

        if (entity == null)
            throw new ArgumentNullException($"{entity.GetType().Name} cant be null");

        await _equipmentRepository.RemoveAsync(entity);

        return new()
        {
            IsSuccessfully = true
        };
    }
}