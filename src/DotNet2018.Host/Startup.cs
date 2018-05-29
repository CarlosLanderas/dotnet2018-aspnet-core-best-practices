using DotNet2018.Api;
using DotNet2018.Api.Infrastructure.HttpErrors;
using DotNet2018.Application.Ports;
using DotNet2018.Application.Services;
using DotNet2018.Infrastructure;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace DotNet2018.Host
{
    public class Startup
    {        
        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.ConfigureServices(services)
                .AddCustomServices()
                .AddOpenApi();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Configuration.Configure(
                app, 
                host => host
                    .UseIf(env.IsDevelopment(), appBuilder => appBuilder.UseDeveloperExceptionPage())
                    .UseSwagger()
                    .UseSwaggerUI(setup =>
                    {
                        setup.SwaggerEndpoint("/swagger/v1/swagger.json", "DotNet 2018");
                    })
            );
        }
    }
}