using DotNet2018.Api.Infrastructure.HttpErrors;
using DotNet2018.Application.Ports;
using DotNet2018.Application.Services;
using DotNet2018.Infrastructure;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services
                .AddSingleton<IHttpErrorFactory, DefaultHttpErrorFactory>()
                .AddSingleton<ISpeakerService, SpeakersService>()
                .AddSingleton<INotificationQueue, NotificationQueue>();

            return services;
        }

        public static IServiceCollection AddOpenApi(this IServiceCollection services)
        {
            services.AddSwaggerGen(setup =>
            {
                setup.DescribeAllParametersInCamelCase();
                setup.DescribeStringEnumsInCamelCase();
                setup.SwaggerDoc("v1", new Info
                {
                    Title = "Dotnet 2018 Api",
                    Version = "v1"
                });
            });

            return services;
        }
    }
}
