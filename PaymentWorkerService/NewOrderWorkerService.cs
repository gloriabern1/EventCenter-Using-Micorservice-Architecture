using Microsoft.Azure.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Rebus.Activation;
using Rebus.Config;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentWorkerService
{
    public class NewOrderWorkerService : BackgroundService
    {
        private readonly IConfiguration config;

        public NewOrderWorkerService(IConfiguration config)
        {
            this.config = config;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var storageAccount = CloudStorageAccount.Parse(config["AzureQueues:ConnectionString"]);

            using var activator = new BuiltinHandlerActivator();
            activator.Register(() => new NewOrderHandler());
            Configure.With(activator).Transport(t => t.UseAzureStorageQueues(
                storageAccount, config["AzureQueues:QueueName"])).Start();

            await Task.Delay(Timeout.InfiniteTimeSpan, stoppingToken);
        }
    }
}
