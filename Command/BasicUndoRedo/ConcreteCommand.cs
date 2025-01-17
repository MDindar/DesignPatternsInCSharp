namespace Command.BasicUndoRedo;

class ConcreteCommand(Reciever reciever, int param) : ICommand
{
    private readonly Reciever reciever = reciever;
    private readonly int param = param;

    public void Execute()
    {
        reciever.Action(param);
    }

    public void Undo()
    {
        reciever.UndoAction(param);
    }
}