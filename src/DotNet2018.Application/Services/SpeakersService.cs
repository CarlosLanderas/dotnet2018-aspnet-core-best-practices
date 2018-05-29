using DotNet2018.Application.Ports;
using DotNet2018.Application.Responses;
using System.Collections.Generic;

namespace DotNet2018.Application.Services
{
    public class SpeakersService : ISpeakerService
    {

        private readonly INotificationQueue _notificationQueue;

        public SpeakersService(INotificationQueue notificationQueue)
        {
            _notificationQueue = notificationQueue;
        }
        public void AddSpeaker(string name, string description)
        {
            Speakers.Collection.Add(Speaker.Create(name, description));
            _notificationQueue.Publish($"{name} - {description}");
        }

        public IEnumerable<Speaker> GetSpeakers()
        {
            return Speakers.Collection; ;
        }        
    }
}
