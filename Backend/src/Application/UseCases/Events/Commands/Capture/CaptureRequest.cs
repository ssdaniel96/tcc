using Domain.Enums;
using MediatR;

namespace Application.UseCases.Events.Commands.Capture
{
    public sealed class CaptureRequest : IRequest
    {
        public string RFTag { get; init; } = string.Empty;
        public MovimentTypeEnum MovimentType { get; init; }
    }
}
