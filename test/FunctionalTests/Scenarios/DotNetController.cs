using DotNet2018.Application.Responses;
using FluentAssertions;
using FunctionalTests.Fixtures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FunctionalTests.Scenarios
{
    public class dotnet_api_should : IClassFixture<HostFixture>
    {
        private HostFixture Given { get; }
        
        public dotnet_api_should(HostFixture hostFixture)
        {
            Given = hostFixture;
        }

        [Fact]
        public async Task return_the_list_of_speakers()
        {
            var server = Given.Server;
            var response = await server.CreateRequest("api/dotnet/speakers").GetAsync();            

            response.EnsureSuccessStatusCode();

            var speakers = JsonConvert.DeserializeObject<IEnumerable<Speaker>>
                                (await response.Content.ReadAsStringAsync());

            speakers.Count().Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task add_a_speaker_to_the_list()
        {
            var server = Given.Server;
            var speakerName = "Raanan Weber";
            var speakerDescription = "BabylonJS Core Team Member and Houzplan CTO";
            var speaker = Speaker.Create(speakerName, speakerDescription);

            var response = await server.CreateClient()
                            .PostAsync("api/dotnet/speaker",
                                        new StringContent(JsonConvert.SerializeObject(speaker), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            response = await server.CreateRequest("/api/dotnet/speakers").GetAsync();
            response.EnsureSuccessStatusCode();

            var speakers = JsonConvert.DeserializeObject<IEnumerable<Speaker>>
                                (await response.Content.ReadAsStringAsync());

            speakers.Should().Contain(s => s.Name == speaker.Name);
            speakers.Should().Contain(s => s.Description == speaker.Description);
        }

        [Fact]
        public async Task add_a_speaker_should_validate_request_payload()
        {
            var server = Given.Server;
            var speakerName = "An";
            var speakerDescription = "Desc";
            var speaker = Speaker.Create(speakerName, speakerDescription);

            var response = await server.CreateClient()
                            .PostAsync("api/dotnet/speaker",
                                        new StringContent(JsonConvert.SerializeObject(speaker), Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        }

    }
}
