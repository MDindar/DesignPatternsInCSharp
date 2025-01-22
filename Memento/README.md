


# Most Basic Implementation : 

```cs
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Originator originator=new();
CareTaker careTaker=new();

originator.SetState("State1");
careTaker.AddMemento(originator.CreateMemento());

originator.SetState("State2");
careTaker.AddMemento(originator.CreateMemento());

originator.SetState("State3");
careTaker.AddMemento(originator.CreateMemento());

originator.SetState("State4");
careTaker.AddMemento(originator.CreateMemento());

originator.Restore(careTaker.GetMemento(1));


class Originator
{
    private string _state=string.Empty;

    public void SetState(string state)
    {
        Console.WriteLine($"Originator : setting state to {state}");
        _state = state;
    }

    public string GetSate()
    {
        return _state;
    }

    
    public Memento CreateMemento()
    {
        return new Memento(_state);
    }

    public void Restore(Memento memento)
    {
        _state= memento.GetState();
        Console.WriteLine($"Originator : Restored state to {_state}");
    }
}
class Memento(string state)
{
    private readonly string _state = state;

    public string GetState()
    {
        return _state;
    }
}
class CareTaker
{
    private readonly List<Memento> _mementos=[];

    public void AddMemento(Memento memento)
    {
        _mementos.Add(memento);
    }

    public Memento GetMemento(int index)
    {
        if(index>=0 && index<_mementos.Count)
            return _mementos[index];
        else throw new ArgumentOutOfRangeException(nameof(index),"Invalid Memento Index");
    }
}
```