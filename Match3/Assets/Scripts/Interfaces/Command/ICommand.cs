namespace Match3Project.Interfaces.Command
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
