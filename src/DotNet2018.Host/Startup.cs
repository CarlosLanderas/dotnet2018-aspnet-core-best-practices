﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet2018.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet2018.Host
{
    public class Startup
    {        
        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.ConfigureServices(services)
                .AddOpenApi();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Configuration.Configure(app, host =>
                host.UseOpenApi()
            );
        }
    }
}