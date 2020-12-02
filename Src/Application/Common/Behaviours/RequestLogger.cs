using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using FinRust.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace FinRust.Application.Common.Behaviours
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        private readonly ICurrentUserService _currentUserService;

        public RequestLogger(ILogger<TRequest> logger, ICurrentUserService currentUserService)
        {
            _logger = logger;
            _currentUserService = currentUserService;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;

            _logger.LogInformation("FinRust Request: {Name} {@UserId} {@Request}", 
                name, _currentUserService.UserId, request);

            return Task.CompletedTask;
        }
    }
}
