using DotNet2018.Application.Responses;
using System.Collections.Generic;

namespace DotNet2018.Application.Ports
{
    public interface ISpeakerService
    {
        IEnumerable<Speaker> GetSpeakers();
        void AddSpeaker(string name, string description);
    }
}
