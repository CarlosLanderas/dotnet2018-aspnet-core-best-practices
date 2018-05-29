using DotNet2018.Application.Ports;
using DotNet2018.Application.Services;
using DotNet2018.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FunctionalTests.Fixtures
{
    public class HostFixture 
    {
        public TestServer Server { get; }
        
        public HostFixture()
        {
            Server = new TestServer(
                new WebHostBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<ISpeakerService, SpeakersService>();
                    services.TryAddSingleton<INotificationQueue, NoNotificationQueue>();
                })
                .UseStartup<TestStartup>()                              
            );
        }
    }
}
