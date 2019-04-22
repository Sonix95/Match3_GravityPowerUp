using Match3Project.Interfaces.Observer;

namespace Match3Project.Interfaces
{
    public interface ILogicManager : ISubscriber
    {
        IBoard Board { get; set; }
        ICheckManager CheckManager { get; set; }
        ISpawnManager SpawnManager { get; set; }
        int SpawnYPos { get; set; }

        void FindMatches();
    }
}
