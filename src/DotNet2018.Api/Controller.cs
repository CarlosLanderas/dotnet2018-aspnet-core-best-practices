using DotNet2018.Api.Features.AddSpeaker;
using DotNet2018.Api.Infrastructure.HttpErrors;
using DotNet2018.Application.Ports;
using DotNet2018.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;

namespace DotNet2018.Api
{
    [Route("api/dotnet")]
    public class Controller : ControllerBase
    {
        private readonly ISpeakerService _speakerService;

        public Controller(ISpeakerService speakerService)
        {
            _speakerService = speakerService;
        }

        [HttpGet("speakers")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(IEnumerable<Speaker>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(HttpError))]
        public IActionResult GetSpeakers()
        {
            return Ok(_speakerService.GetSpeakers());
        }

        [HttpPost("speaker")]
        [SwaggerResponse(StatusCodes.Status200OK, typeof(IEnumerable<Speaker>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(HttpError))]
        public IActionResult AddSpeaker([FromBody] AddSpeakerModel speaker)
        {
            _speakerService.AddSpeaker(speaker.Name, speaker.Description);
            return CreatedAtAction(nameof(GetSpeakers), null);
        }

        [HttpGet("/fail")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, typeof(HttpError))]
        public IActionResult Fail()
        {
            throw new Exception("Error thrown on purpose");
        }

        [HttpGet("/")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Swagger()
        {
            return Redirect("/swagger");
        }
    }
}
