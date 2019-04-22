using Match3Project.Interfaces.Command;

namespace Match3Project.Classes.Commands
{
    public class MacroCommand : ICommand
    {
        private readonly ICommand[] _commands;

        public MacroCommand(ICommand[] commands)
        {
            _commands = commands;
        }

        public void Execute()
        {
            if (_commands.Length > 0)
            {
                foreach (var command in _commands)
                    command.Execute();
            }
        }

        public void Undo()
        {
            if (_commands.Length > 0)
            {
                foreach (var command in _commands)
                    command.Undo();
            }
        }
        
    }
}
