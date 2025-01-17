using Command.BasicUndoRedo;

class Invoker
{
    private List<ICommand> _commands = [];
    private Stack<ICommand> _undoCommands = [];
    private Stack<ICommand> _redoCommands = [];

    public void SetCommand(ICommand command)
    {
        _commands.Add(command);
    }

    public void ExecuteCommands()
    {
        foreach (var command in _commands)
        {
            command.Execute();
            _undoCommands.Push(command);
        }
        _commands.Clear();
    }

    public void ExecuteUndo()
    {
        if (_undoCommands.Count > 0)
        {
            var cmd = _undoCommands.Pop();
            cmd.Undo();
            _redoCommands.Push(cmd);
        }
        else
        {
            Console.WriteLine("No more command to undo");
        }
    }

    public void ExecuteRedo()
    {
        if (_redoCommands.Count > 0)
        {
            _redoCommands.Pop().Execute();
        }
    }
}
