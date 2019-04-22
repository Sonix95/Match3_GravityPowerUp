using Match3Project.Interfaces.Cells;
using UnityEngine;

namespace Match3Project.Interfaces
{
    public interface IObjectSetter
    {
        void SetGameObject(GameObject go, Vector3 position);
        void SetNormalCell(INormalCell normalCell,GameObject go);
    }
}
