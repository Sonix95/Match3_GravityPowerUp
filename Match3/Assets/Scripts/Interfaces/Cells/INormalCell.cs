using Match3Project.Interfaces.Observer;

namespace Match3Project.Interfaces.Cells
{
    public interface INormalCell : ICell, IUpdatable
    {
        INotifier Notifier { get; set; }
    }
}
