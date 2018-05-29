
namespace DotNet2018.Application.Ports
{
    public interface INotificationQueue
    {
        void Publish(string message);
        string Read();
        bool HasMessages { get; }
    }
}
