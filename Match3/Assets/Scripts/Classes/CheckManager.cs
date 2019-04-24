using System.Collections.Generic;
using Match3Project.Classes.StaticClasses;
using Match3Project.Enums;
using Match3Project.Interfaces;
using Match3Project.Interfaces.Cells;
using UnityEngine;

namespace Match3Project.Classes
{
    public class CheckManager : ICheckManager
    {
        private IBoard _board;
        private IList<ICell> CheckLine(AxisTypes axisType, ICell cell)
        {
            if (Helper.CellIsEmpty(cell))
            {
                return null;
            }

            IList<ICell> sideCells = new List<ICell>();

            int x = cell.TargetX;
            int y = cell.TargetY;

            int boardLimit;
            int axis;

            ICell sideCell = null;

            if (axisType == AxisTypes.Horizontal)
            {
                boardLimit = _board.Width;
                axis = x;
            }
            else
            {
                boardLimit = _board.Height;
                axis = y;
            }

            if (axis > 0 && axis < boardLimit)
            {
                for (int i = axis - 1; i >= 0; i--)
                {
                    sideCell = (axisType == AxisTypes.Horizontal)
                        ? _board.Cells[i, y]
                        : _board.Cells[x, i];

                    if (Helper.CellIsEmpty(sideCell))
                    {
                        break;
                    }

                    if (sideCell.CurrentGameObject.CompareTag(StringsAndConst.TAG_POWER))
                    {
                        GameObject powerGameObject = sideCell.CurrentGameObject.transform.GetChild(0).gameObject;
                        
                        if (Helper.CompareColors(cell.CurrentGameObject, powerGameObject))
                        {
                            sideCells.Add(sideCell);
                        }
                        else
                        {
                            break;
                        }
                    }
                    
                    if (sideCell.CurrentGameObject.CompareTag(cell.CurrentGameObject.tag))
                    {
                        sideCells.Add(sideCell);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (axis >= 0 && axis < boardLimit)
            {
                for (int i = axis + 1; i < boardLimit; i++)
                {
                    sideCell = (axisType == AxisTypes.Horizontal)
                        ? _board.Cells[i, y]
                        : _board.Cells[x, i];

                    if (Helper.CellIsEmpty(sideCell))
                    {
                        break;
                    }

                    if (sideCell.CurrentGameObject.CompareTag(StringsAndConst.TAG_POWER))
                    {
                        GameObject powerGameObject = sideCell.CurrentGameObject.transform.GetChild(0).gameObject;
                        
                        if (Helper.CompareColors(cell.CurrentGameObject, powerGameObject))
                        { 
                            sideCells.Add(sideCell);
                        }
                        else
                        {
                            break;
                        }
                    }
                    
                    if (sideCell.CurrentGameObject.CompareTag(cell.CurrentGameObject.tag))
                    {
                        sideCells.Add(sideCell);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return sideCells;
        }

        public IList<ICell> CheckCell(ICell cell, out AxisTypes majorAxis)
        {
            IList<ICell> allCellList = new List<ICell>();

            IList<ICell> horizontalCellsList = CheckLine(AxisTypes.Horizontal, cell);
            IList<ICell> verticalCellsList = CheckLine(AxisTypes.Vertical, cell);

            if (horizontalCellsList.Count > 1)
            {
                foreach (var horCell in horizontalCellsList)
                {
                    allCellList.Add(horCell);
                }
            }

            if (verticalCellsList.Count > 1)
            {
                foreach (var vertCell in verticalCellsList)
                {
                    allCellList.Add(vertCell);
                }
            }

            if (allCellList.Count > 0)
            {
                allCellList.Add(cell);
            }

            if (horizontalCellsList.Count > verticalCellsList.Count)
            {
                majorAxis = AxisTypes.Horizontal;
            }
            else if (horizontalCellsList.Count < verticalCellsList.Count)
            {
                majorAxis = AxisTypes.Vertical;
            }
            else
            {
                majorAxis = AxisTypes.Undefined;
            }

            foreach (var oneCell in allCellList)
            {
                if (oneCell.CellState != CellStates.Lock)
                {
                    oneCell.CellState = CellStates.Check;
                }
            }

            return allCellList;
        }

        public bool HaveMatch(ICell cell)
        {
            IList<ICell> horizontalCellsList = CheckLine(AxisTypes.Horizontal, cell);
            IList<ICell> verticalCellsList = CheckLine(AxisTypes.Vertical, cell);

            if (horizontalCellsList.Count > 1 || verticalCellsList.Count > 1)
            {
                return true;
            }

            return false;
        }

        public IList<ICell> PowerCheck(PowerUpTypes powerUpType, Vector2 position)
        {
            IList<ICell> checkedCells = new List<ICell>();

            int posX = (int) position.x;
            int posY = (int) position.y;

            switch (powerUpType)
            {
                case PowerUpTypes.Gravity:
                    //checkedCells.Add(_board.Cells[posX, posY]);
                    break;

                default:
                    checkedCells.Add(_board.Cells[posX, posY]);
                    break;
            }

            return checkedCells;
        }

        public IBoard Board
        {
            get { return _board; }
            set { _board = value; }
        }

    }
}
