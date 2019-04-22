using Match3Project.Interfaces;
using Match3Project.Interfaces.Cells;
using UnityEngine;

namespace Match3Project.Classes
{
    public class Board : IBoard
    {
        private int _width;
        private int _height;
        private ICell[,] _cells;
        
        private ISpawnManager _spawnManager;

        public Board(int width, int height, ISpawnManager spawnManager)
        {
            _width = width;
            _height = height;
            _cells = new ICell[_width, _height];

            _spawnManager = spawnManager;
            
            Initial();
        }

        private void Initial()
        {
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    if (_cells[i, j] == null)
                    {
                        Vector2 tempPos = new Vector2(i, j);

                        _cells[i, j] = _spawnManager.SpawnNormalCell(tempPos);
                    }
                }
            }
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public ICell[,] Cells
        {
            get { return _cells; }
            set { _cells = value; }
        }

    }
}
