using DotNet2018.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalTests
{
    public class TestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.ConfigureServices(services);
        }

        public void Configure(IApplicationBuilder app)
        {
            Configuration.Configure(app, host =>
            {
                return host;
            });
        }
    }
}

