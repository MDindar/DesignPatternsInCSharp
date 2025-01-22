// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Player player = new();
PlayerMementoManager manager = new(player);

player.SetState("Player1", 100, new Power(101, 102));
manager.Backup(player.TakeSnapshot());

player.SetState("Player1", 200, new Power(201, 202));
manager.Backup(player.TakeSnapshot());

player.SetState("Player1", 300, new Power(301, 302));
manager.Backup(player.TakeSnapshot());

player.SetState("Player1", 400, new Power(401, 402));
manager.Backup(player.TakeSnapshot());

manager.Undo();
manager.Undo();
manager.Redo();



class Power
{
    public Power(int speed, int jump)
    {
        Speed = speed;
        Jump = jump;
    }

    public int Speed { get; }
    public int Jump { get; }


    public override string ToString()
    {
        return $"Power with speed : {Speed}, Jump : {Jump}";
    }
}
class Player
{
    private string _title = string.Empty;
    private int _score;
    private Power _power = default!;

    public void SetState(string title, int score, Power power)
    {
        _power = power;
        _score = score;
        _title = title;
        Console.WriteLine($"Player : setting state for {title}, score : {score}, Power : {power}");
    }

    public (string, int, Power) GetSate()
    {
        return (_title, _score, _power);
    }


    public Memento TakeSnapshot()
    {
        return new Memento(_title, _score, _power);
    }

    public void Restore(Memento memento)
    {
        (_title, _score, _power) = memento.GetState();
        Console.WriteLine($"Player : Restored state to {_title}, score : {_score}, Power : {_power}");
    }
}
class Memento(string title, int score, Power power)
{
    private readonly string _title = title;
    private readonly int _score = score;
    private readonly Power _power = power;

    public (string, int, Power) GetState()
    {
        return (_title, _score, _power);
    }
}
class PlayerMementoManager(Player player)
{
    private readonly Stack<Memento> _undoStack = [];
    private readonly Stack<Memento> _redoStack = [];
    private readonly Player _player = player;

    public void Backup(Memento memento)
    {
        _undoStack.Push(memento);
        _redoStack.Clear();
    }

    public void Undo()
    {
        if(_undoStack.Count==0) return ;
        _redoStack.Push(_undoStack.Pop());
         _player.Restore( _undoStack.Peek());
    }

    public void Redo()
    {
        if(_redoStack.Count==0) return ;
        var m = _redoStack.Pop();
        _undoStack.Push(m);
        _player.Restore(m);
    }
}