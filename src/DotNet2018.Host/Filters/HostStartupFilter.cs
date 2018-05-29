using DotNet2018.Host.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;

namespace DotNet2018.Host.Filters
{
    public class HostStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {            
            return builder =>
            {
                builder.UseMiddleware<ErrorHandlerMiddleware>();
                next(builder);
            };
        }
    }
}
