using Application.Shared.Dtos;
using Domain.Repositories.Sensors;
using MediatR;

namespace Application.UseCases.Locations.Commands.RemoveSensorById;

public class RemoveSensorByIdHandler : IRequestHandler<RemoveSensorByIdRequest, ResponseDto>
{
    private readonly ISensorRepository _sensorRepository;

    public RemoveSensorByIdHandler(ISensorRepository sensorRepository)
    {
        _sensorRepository = sensorRepository;
    }

    public async Task<ResponseDto> Handle(RemoveSensorByIdRequest request, CancellationToken cancellationToken)
    {
        var entity =  await _sensorRepository.GetByIdAsync(request.Id)
            ?? throw new ApplicationException($"Sensor ({request.Id}) não foi encontrado!");

        await _sensorRepository.RemoveAsync(entity);

        return new()
        {
            IsSuccessfully = true
        };
    }
}