using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Net;

namespace DotNet2018.Api.Infrastructure.HttpErrors
{
    public class DefaultHttpErrorFactory : IHttpErrorFactory
    {
        private readonly IHostingEnvironment env;
        private readonly IDictionary<Type, Func<Exception, HttpError>> factory;

        public DefaultHttpErrorFactory(IHostingEnvironment env)
        {
            this.env = env;

            factory = new Dictionary<Type, Func<Exception, HttpError>>
            {
                { typeof(Exception), InternalServerError }
            };
        }

        public HttpError CreateFrom(Exception exception)
        {
            if (factory.TryGetValue(exception.GetType(), out Func<Exception, HttpError> func))
            {
                return func(exception);
            }

            return factory[typeof(Exception)](exception);
        }

        private HttpError InternalServerError(Exception exception)
        {
            return HttpError.Create(
                env,
                status: HttpStatusCode.InternalServerError,
                code: string.Empty,
                userMessage: new[] { "Internal Server Error" },
                developerMessage: $"{exception.Message}\r\n{exception.StackTrace}");
        }
    }
}
