using DotNet2018.Application.Ports;

namespace DotNet2018.Infrastructure
{
    public class NoNotificationQueue : INotificationQueue
    {
        public bool HasMessages => false;
        public void Publish(string message) { }
        public string Read() => string.Empty;
    }
}
