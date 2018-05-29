using DotNet2018.Application.Ports;
using System.Collections.Generic;

namespace DotNet2018.Infrastructure
{
    public class NotificationQueue : INotificationQueue
    {
        private Queue<string> _notificationsQueue = new Queue<string>();
        public void Publish(string message)
        {
            _notificationsQueue.Enqueue(message);
        }
        public string Read()
        {
            return _notificationsQueue.Dequeue();
        }

        public bool HasMessages
        {
            get
            {
                return _notificationsQueue.Count > 0;
            }
        }
    }
}
