using System;
using Match3Project.Enums;

namespace Match3Project.Interfaces.Observer
{
    public interface ISubscriber
    {
        void OnEvent(EventTypes eventType, Object messageData);
    }
}
