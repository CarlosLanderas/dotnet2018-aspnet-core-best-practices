using DotNet2018.Application.Ports;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNet2018.BackgroundServices
{
    public class SpeakerAddedTeamsNotificationService : IHostedService
    {
        private const string WebHookUrl = @"https://outlook.office.com/webhook/8a4fb213-ee6d-442b-ae78-5a6c79b3066b@5c384fed-84cc-44a6-b34a-b060bf102a6e/IncomingWebhook/722c56ad14c24fe89d49c78d20e5b772/5ad2f81a-f8cb-4f56-9ddb-42168fae3755";
        private readonly INotificationQueue _notificationQueue;

        public SpeakerAddedTeamsNotificationService(INotificationQueue notificationQueue)
        {
            _notificationQueue = notificationQueue ?? throw new ArgumentNullException(nameof(notificationQueue));
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            return ExecuteAsync(cancellationToken);            
        }

        private async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                using(var httpClient = new HttpClient())
                {
                    while (_notificationQueue.HasMessages)
                    {
                        var message = new
                        {
                            @type = "MessageCard",
                            @title = "New speaker Added",
                            @text = _notificationQueue.Read()
                        };

                        await httpClient.PostAsync(WebHookUrl, new StringContent(JsonConvert.SerializeObject(message),
                              Encoding.UTF8, "application/json"));
                    }                    
                }
                await Task.Delay(10000);
            }
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
