using System.Collections.Generic;
using Match3Project.Enums;
using Match3Project.Interfaces.Cells;
using UnityEngine;

namespace Match3Project.Interfaces
{
    public interface ICheckManager
    {
        IBoard Board { get; set; }

        bool SimpleCheck(ICell cell);
        bool HaveMatch(ICell cell);
        IList<ICell> CheckCell(ICell cell, out AxisTypes majorAxis);
        IList<ICell> PowerCheck(PowerUpTypes powerUpType, Vector2 position);

    }
}
