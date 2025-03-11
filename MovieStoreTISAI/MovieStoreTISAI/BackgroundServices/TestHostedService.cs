
namespace MovieStoreTISAI.BackgroundServices
{
    public class TestHostedService : IHostedService
    {
        private readonly ILogger<TestHostedService> _logger;

        public TestHostedService(ILogger<TestHostedService> logger)
        {
            _logger = logger;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            
                _logger.LogInformation($"Host Ready");
            Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    _logger.LogWarning($"Do work... {DateTime.Now}");

                    await Task.Delay(1000, cancellationToken);
                }
            }, cancellationToken);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            
                _logger.LogInformation($"Host Stopped");
            return Task.CompletedTask;
        }
    }
}
