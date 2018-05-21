using Microsoft.AspNetCore.Mvc;

namespace DotNet2018.Api
{
    [Route("api/dotnet")]
    public class Controller : ControllerBase
    {
        [HttpGet("/")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Swagger()
        {
            return Redirect("/swagger");
        }
    }
}
