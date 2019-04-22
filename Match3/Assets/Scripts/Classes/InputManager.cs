using System.Collections.Generic;
using Match3Project.Enums;
using Match3Project.Interfaces;
using Match3Project.Interfaces.Observer;
using UnityEngine;
using Object = System.Object;

namespace Match3Project.Classes
{
    public class InputManager : IInputManager, IUpdatable
    {
        private bool _canUpdate;
        private INotifier _notifier;

        private IList<ISubscriber> _subscribes;

        public InputManager(INotifier notifier)
        {
            _notifier = notifier;
            _subscribes = new List<ISubscriber>();
            _canUpdate = true;
        }

        public void DoUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Object dataMessage = new Object();
                dataMessage = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Notify(EventTypes.LMB_Down, dataMessage);
                return;
            }

            if (Input.GetMouseButtonUp(0))
            {
                Object dataMessage = new Object();
                dataMessage = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Notify(EventTypes.LMB_Up, dataMessage);
                return;
            }
        }

        public void AddSubscriber(ISubscriber subscriber)
        {
            if (subscriber != null && !_subscribes.Contains(subscriber))
            {
                _notifier.AddSubscriber(subscriber);
            }
        }

        public void RemoveSubscriber(ISubscriber subscriber)
        {
            if (subscriber != null && _subscribes.Contains(subscriber))
            {
                _notifier.RemoveSubscriber(subscriber);
            }
        }

        public void Notify(EventTypes eventType, Object messageData)
        {
            _notifier.Notify(eventType, messageData);
        }

        public bool canUpdate
        {
            get { return _canUpdate; }
            set { _canUpdate = value; }
        }

        public INotifier Notifier
        {
            get { return _notifier; }
            set { _notifier = value; }
        }

    }
}
