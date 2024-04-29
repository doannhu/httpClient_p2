using Microsoft.Extensions.Logging;

namespace httpClient_p2.Handlers
{
    public class LoggingHandler: DelegatingHandler
    {
        private readonly ILogger<LoggingHandler> _logger;
        public LoggingHandler(ILogger<LoggingHandler> logger)
        {
            _logger = logger;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation("**********************Custom SendAsync****From Logger Handler: Right before request");
            var response = await base.SendAsync(request, cancellationToken);
            _logger.LogInformation("**********************Custom SendAsync****From Logger Handler: Response has been received");
            return response;
        }
    }
}
