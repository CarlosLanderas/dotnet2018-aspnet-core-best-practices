using DotNet2018.BackgroundServices;
using DotNet2018.Host.Filters;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DotNet2018.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {                    
                    services.AddTransient<IStartupFilter, HostStartupFilter>();
                    services.AddSingleton<IHostedService, SpeakerAddedTeamsNotificationService>();
                }).UseStartup<Startup>();
    }
}
