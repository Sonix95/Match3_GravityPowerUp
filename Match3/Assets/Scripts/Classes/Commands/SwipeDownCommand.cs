using Match3Project.Enums;
using Match3Project.Interfaces.Cells;
using Match3Project.Interfaces.Command;

namespace Match3Project.Classes.Commands
{
    public class SwipeDownCommand : ICommand
    {
        private readonly ICell _cell;

        public SwipeDownCommand(ICell cell)
        {
            _cell = cell;
        }
        
        public void Execute()
        {
            _cell.TargetY -= 1;
            _cell.CellState = CellStates.Swipe;
            _cell.Move();
        }

        public void Undo()
        {
            _cell.TargetY += 1;
            _cell.CellState = CellStates.Back;
            _cell.Move();
        }
        
    }
}
