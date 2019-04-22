namespace Match3Project.Interfaces
{
    public interface IUpdateManager
    {
        bool IsUpdate { get; set; }
        
        void AddUpdatable(IUpdatable updatable);
        void RemoveUpdatable(IUpdatable updatable);
    }
}
