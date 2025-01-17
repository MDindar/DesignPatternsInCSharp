namespace Command.BasicUndoRedo;

interface ICommand
{
    void Execute();
    void Undo();
}