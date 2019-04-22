using Match3Project.Interfaces;
using Match3Project.Interfaces.Cells;
using Match3Project.Interfaces.Observer;
using UnityEngine;

namespace Match3Project.Classes
{
    public class ObjectSetter : IObjectSetter
    {
        private IUpdateManager _updateManager;
        private INotifier _notifier;

        public ObjectSetter(IUpdateManager updateManager, INotifier notifier)
        {
            _updateManager = updateManager;
            _notifier = notifier;
        }

        public void SetGameObject(GameObject go, Vector3 position)
        {
            go.name = go.tag;
            go.transform.position = position;
        }

        public void SetNormalCell(INormalCell normalCell, GameObject go)
        {
            normalCell.CurrentGameObject = go;
            normalCell.Notifier = _notifier;
            _updateManager.AddUpdatable(normalCell);
        }

    }
}
