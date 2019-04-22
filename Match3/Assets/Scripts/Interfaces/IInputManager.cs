using System;
using Match3Project.Enums;
using Match3Project.Interfaces.Observer;

namespace Match3Project.Interfaces
{
    public interface IInputManager
    {
        INotifier Notifier { get; set; }
        void AddSubscriber(ISubscriber subscriber);
        void RemoveSubscriber(ISubscriber subscriber);
        void Notify(EventTypes eventType, Object messageData);
    }
}
