using System.Collections;
using System.Text;
using Match3Project.Classes.StaticClasses;
using Match3Project.Enums;
using Match3Project.Interfaces.Cells;
using Match3Project.Interfaces.Observer;
using UnityEngine;

namespace Match3Project.Classes.Cells
{
    public class NormalCell : INormalCell
    {
        private int _x;
        private int _y;
        private CellStates _cellStates;
        private GameObject _currentGameObject;
        private INotifier _notifier;
        private bool _canUpdate;

        public NormalCell(int x, int y)
        {
            _x = x;
            _y = y;
            _cellStates = CellStates.Wait;
        }

        public void Move()
        {
            _canUpdate = true;
        }

        public void DoUpdate()
        {
            Vector2 tempPos = new Vector2(_x, _y);

            if (_currentGameObject != null)
            {
                if (Mathf.Abs(_x - _currentGameObject.transform.position.x) > StringsAndConst.POSITION_DELTA ||
                    Mathf.Abs(_y - _currentGameObject.transform.position.y) > StringsAndConst.POSITION_DELTA)
                {
                    _currentGameObject.transform.position = Vector2.Lerp(_currentGameObject.transform.position, tempPos,
                        StringsAndConst.CELL_SPEED * Time.deltaTime);
                }
                else
                {
                    _currentGameObject.transform.position = tempPos;
                    _canUpdate = false;

                    switch (CellState)
                    {
                        case CellStates.Swipe:
                            _notifier.Notify(EventTypes.CELL_EndMove, this);
                            break;
                        case CellStates.Back:
                            _notifier.Notify(EventTypes.CELL_EndMoveBack, this);
                            break;
                        case CellStates.Fall:
                            _notifier.Notify(EventTypes.CELL_Fall, this);
                            break;
                    }
                }
            }
        }

        public void DoAfterMatch()
        {
            if (_currentGameObject != null && _currentGameObject.CompareTag(StringsAndConst.TAG_POWER))
            {
                GameObject powerGameObject = _currentGameObject.transform.GetChild(0).transform.gameObject;
                ArrayList typeAndPos = new ArrayList();
                typeAndPos.Add(powerGameObject.tag);
                typeAndPos.Add(_currentGameObject.transform.position);

                _notifier.Notify(EventTypes.POWER_Use, typeAndPos);
            }

            GameObject.Destroy(_currentGameObject);
            _currentGameObject = null;
        }

        public override string ToString()
        {
            StringBuilder message = new StringBuilder(StringsAndConst.NORMAL_CELL + _x.ToString() + "x" + _y.ToString());
            message.Append(", State: " + _cellStates);
            message.Append(", Update?: " + _canUpdate.ToString());
            message.Append(", Current GO: " + (_currentGameObject != null ? _currentGameObject.tag : "missing"));

            return message.ToString();
        }

        public int TargetX
        {
            get { return _x; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                _x = value;
            }
        }

        public int TargetY
        {
            get { return _y; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                _y = value;
            }
        }

        public CellStates CellState
        {
            get { return _cellStates; }
            set { _cellStates = value; }
        }

        public GameObject CurrentGameObject
        {
            get { return _currentGameObject; }
            set { _currentGameObject = value; }
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