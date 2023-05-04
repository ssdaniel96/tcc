using MediatR;

namespace Application.UseCases.Events.Commands.Capture
{
    internal class CaptureHandler : IRequestHandler<CaptureRequest>
    {
        public Task Handle(CaptureRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
