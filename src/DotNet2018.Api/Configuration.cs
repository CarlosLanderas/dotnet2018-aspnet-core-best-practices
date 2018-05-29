using DotNet2018.Api.Features.AddSpeaker;
using DotNet2018.Api.Infrastructure.Filters;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DotNet2018.Api
{
    public class Configuration
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            return services                    
                    .AddMvcCore(config => config.Filters.Add(typeof(ValidModelStateFilter)))
                    .AddJsonFormatters()
                    .AddApiExplorer()
                    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddSpeakerValidator>())
                    .Services;
        }

        public static IApplicationBuilder Configure(
            IApplicationBuilder app,
            Func<IApplicationBuilder, IApplicationBuilder> configureHost) =>
            configureHost(app)
                .UseMvc(routes => routes.MapRoute("swagger", "{controller=DotNet}/{action=Swagger}"));
    }
}
