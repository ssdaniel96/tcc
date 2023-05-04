using Domain.Enums;
using MediatR;

namespace Application.UseCases.Events.Commands.Capture
{
    public sealed record EventCaptureRequest : IRequest
    {
        public string RFTag { get; init; } = string.Empty;
        public MovimentTypeEnum MovimentType { get; init; }
        public int LocationId { get; init; }
    }
}
