using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackGroundTask.Demo
{
    public class BackGroundPrinter : IHostedService, IDisposable
    {
        private readonly ILogger<BackGroundPrinter> logger;
        private int number = 0;
        private Timer timer;

        public BackGroundPrinter(ILogger<BackGroundPrinter> logger)
        {
            this.logger = logger;
        }

        public void Dispose()
        {
            timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(o =>
            {
                Interlocked.Increment(ref number);
                logger.LogInformation("Printing from worker");
            },
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Printing worker Stopping");
            return Task.CompletedTask;
        }
    }
}
