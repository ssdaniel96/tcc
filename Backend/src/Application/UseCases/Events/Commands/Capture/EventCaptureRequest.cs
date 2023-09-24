using Application.Shared.Dtos;
using Domain.Enums;
using MediatR;

namespace Application.UseCases.Events.Commands.Capture
{
    public sealed record EventCaptureRequest : IRequest<ResponseDto>
    {
        public string RfTag { get; init; } = string.Empty;
        public Vector Vector { get; init; }
        public int LocationId { get; init; }
    }
}
