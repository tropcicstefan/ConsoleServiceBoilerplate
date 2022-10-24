using Microsoft.Extensions.Logging;

namespace ConsoleServiceBoilerplate
{
    internal class Runner
    {
        private readonly ILogger _logger;

        public Runner(ILogger<Runner> logger)
        {
            _logger = logger;
        }

        internal async Task RunAsync()
        {
            while (true)
            {
                try
                {
                    _logger.LogInformation("Running as fast as I can then taking a break for 5 seconds");

                    Task.Delay(5000).Wait();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unhandled exception occurred");
                }
            }
        }
    }
}
