using Match3Project.Enums;
using UnityEngine;

namespace Match3Project.Interfaces.Cells
{
    public interface ICell
    {
        int TargetX { get; set; }
        int TargetY { get; set; }
        CellStates CellState { get; set; }
        GameObject CurrentGameObject { get; set; }

        void Move();
        void DoAfterMatch();
    }
}
