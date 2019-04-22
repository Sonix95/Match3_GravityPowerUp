using System;
using System.Collections.Generic;
using Match3Project.Enums;
using Match3Project.Interfaces.Observer;

namespace Match3Project.Classes.Observer
{
    public class Notifier : INotifier
    {
        private readonly IList<ISubscriber> _subscribersList;

        public Notifier()
        {
            _subscribersList = new List<ISubscriber>();
        }

        public void AddSubscriber(ISubscriber subscriber)
        {
            if (_subscribersList != null && _subscribersList.Contains(subscriber) == false)
            {
                _subscribersList.Add(subscriber);
            }
        }

        public void RemoveSubscriber(ISubscriber subscriber)
        {
            if (_subscribersList != null && _subscribersList.Contains(subscriber))
            {
                _subscribersList.Remove(subscriber);
            }
        }

        public void Notify(EventTypes eventTypeEnum, Object messageData)
        {
            foreach (var subscriber in _subscribersList)
            {
                subscriber.OnEvent(eventTypeEnum, messageData);
            }
        }

    }
}
