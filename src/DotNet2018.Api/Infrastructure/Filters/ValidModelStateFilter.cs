using DotNet2018.Api.Infrastructure.HttpErrors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Net;

namespace DotNet2018.Api.Infrastructure.Filters
{
    internal class ValidModelStateFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
            {
                return;
            }

            var validationErrors = context.ModelState
                .Keys
                .SelectMany(k => context.ModelState[k].Errors)
                .Select(e => e.ErrorMessage)
                .ToArray();

            var error = HttpError.CreateHttpValidationError(
                status: HttpStatusCode.BadRequest,
                userMessage: new[] { "There are validation errors" },
                validationErrors: validationErrors);

            context.Result = new BadRequestObjectResult(error);
        }
    }
}
