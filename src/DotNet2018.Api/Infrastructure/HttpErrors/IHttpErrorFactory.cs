using System;

namespace DotNet2018.Api.Infrastructure.HttpErrors
{
    public interface IHttpErrorFactory
    {
        HttpError CreateFrom(Exception exception);
    }
}
