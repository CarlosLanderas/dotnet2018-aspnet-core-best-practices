using Microsoft.AspNetCore.Hosting;
using System.Net;

namespace DotNet2018.Api.Infrastructure.HttpErrors
{
    public class HttpError
    {
        public int Status { get; set; }
        public string Code { get; set; }
        public string [] UserMessage { get; set; }
        public string DeveloperMessage { get; set; }
        public string [] ValidationErrors { get; set; }

        public static HttpError CreateHttpValidationError(
            HttpStatusCode status,
            string[] userMessage,
            string[] validationErrors)
        {
            var httpError = CreateDefaultHttpError(status, userMessage);

            httpError.ValidationErrors = validationErrors;

            return httpError;
        }

        public static HttpError Create(
            IHostingEnvironment environment,
            HttpStatusCode status,
            string code,
            string [] userMessage,
            string developerMessage)
        {
            var httpError = CreateDefaultHttpError(status, userMessage);

            httpError.Code = code;

            if (environment.IsDevelopment())
            {
                httpError.DeveloperMessage = developerMessage;
            }

            return httpError;
        }

        private static HttpError CreateDefaultHttpError(
            HttpStatusCode status,
            string [] userMessage)
        {
            var httpError = new HttpError
            {
                Status = (int)status,
                UserMessage = userMessage
            };

            return httpError;
        }
    }
}
