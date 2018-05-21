
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DotNet2018.Api
{
    public class Configuration
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            return services.AddMvcCore()
                    .AddJsonFormatters()
                    .AddApiExplorer()
                    .Services;
        }

        public static IApplicationBuilder Configure
            (IApplicationBuilder app,
            Func<IApplicationBuilder, IApplicationBuilder> configureHost) =>
            configureHost(app).UseMvc(routes =>
                routes.MapRoute("swagger", "{controller=Basket}/{action=Swagger}"));
                              
    }
}
