using System;
using Match3Project.Enums;

namespace Match3Project.Interfaces.Observer
{
    public interface INotifier
    {
        void AddSubscriber(ISubscriber subscriber);
        void RemoveSubscriber(ISubscriber subscriber);
        void Notify(EventTypes eventType, Object messageData);
    }
}
