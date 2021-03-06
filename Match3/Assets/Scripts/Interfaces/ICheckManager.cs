using System.Collections.Generic;
using Match3Project.Enums;
using Match3Project.Interfaces.Cells;
using UnityEngine;

namespace Match3Project.Interfaces
{
    public interface ICheckManager
    {
        IBoard Board { get; set; }

        bool HaveMatch(ICell cell);
        IList<ICell> CheckCell(ICell cell);
        IList<ICell> PowerCheck(PowerUpTypes powerUpType, Vector2 position);

    }
}
