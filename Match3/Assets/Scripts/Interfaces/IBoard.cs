using Match3Project.Interfaces.Cells;

namespace Match3Project.Interfaces
{
    public interface IBoard
    {
        int Width { get; set; }
        int Height { get; set; }
        ICell[,] Cells { get; set; }
    }
}
