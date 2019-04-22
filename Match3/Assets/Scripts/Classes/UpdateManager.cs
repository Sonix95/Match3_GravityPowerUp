using System.Collections.Generic;
using Match3Project.Interfaces;
using UnityEngine;

namespace Match3Project.Classes
{
    public class UpdateManager : MonoBehaviour, IUpdateManager
    {
        private IList<IUpdatable> _updatableList;
        private bool isUpdate;

        private void Awake()
        {
            _updatableList = new List<IUpdatable>();
            isUpdate = false;
        }

        private void Update()
        {
            if (isUpdate)
            {
                foreach (var updatable in _updatableList)
                {
                    if (updatable.canUpdate)
                    {
                        updatable.DoUpdate();
                    }
                }
            }
        }

        public void AddUpdatable(IUpdatable updatable)
        {
            if (updatable != null)
            {
                if (_updatableList.Contains(updatable) == false)
                {
                    _updatableList.Add(updatable);
                }
            }
        }

        public void RemoveUpdatable(IUpdatable updatable)
        {
            if (updatable != null)
            {
                if (_updatableList.Contains(updatable))
                {
                    _updatableList.Remove(updatable);
                }
            }
        }

        public bool IsUpdate
        {
            get { return isUpdate; }
            set { isUpdate = value; }
        }

    }
}
