class RoutineInvoker
{
    private readonly List<ICommand> _commands = [];

    public void SetCommand(ICommand command)
    {
        _commands.Add(command);
    }
    public void ExecuteCommands()
    {
        foreach (var cmd in _commands)
        {
            cmd.Execute();
        }
    }

    public void UndoCommands()
    {
        foreach (var cmd in Enumerable.Reverse(_commands))
        {
            cmd.Undo();
        }
    }
}
