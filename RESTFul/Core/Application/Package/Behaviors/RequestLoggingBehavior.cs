using Core.Application.Package.Wrappers;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Core.Application.Package.Behaviors
{
    public class RequestLoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> where TResponse : ResultBase
    {
        private readonly ILogger<RequestLoggingBehavior<TRequest, TResponse>> _logger;

        public RequestLoggingBehavior(ILogger<RequestLoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            string requestName = typeof(TRequest).Name;

            _logger.LogInformation("Processing request {RequestName}", requestName);

            TResponse result = await next();

            if (result.Succeeded)
            {
                _logger.LogInformation("Completed request {RequestName}", requestName);
            }
            else
            {
                _logger.LogError("Completed request {RequestName} whit next message {Message}", requestName, result.Message);
            }

            return result;
        }
    }
}
