namespace Command.BasicUndoRedo;

class Reciever
{
    public void Action(int param)
    {
        Console.WriteLine($"Reciver logic {param} inserted in db");
    }

    public void UndoAction(int param)
    {
        Console.WriteLine($"Reciver logic {param} removed from db");
    }
}