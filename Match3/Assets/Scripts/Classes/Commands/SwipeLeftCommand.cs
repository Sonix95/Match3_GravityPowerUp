using Match3Project.Enums;
using Match3Project.Interfaces.Cells;
using Match3Project.Interfaces.Command;

namespace Match3Project.Classes.Commands
{
    public class SwipeLeftCommand : ICommand
    {
        private readonly ICell _cell;

        public SwipeLeftCommand(ICell cell)
        {
            _cell = cell;
        }

        public void Execute()
        {
            _cell.TargetX -= 1;
            _cell.CellState = CellStates.Swipe;
            _cell.Move();
        }

        public void Undo()
        {
            _cell.TargetX += 1;
            _cell.CellState = CellStates.Back;
            _cell.Move();
        }
        
    }
}
