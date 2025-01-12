ConcreteSubject subject = new ConcreteSubject();

subject.Attach(new ConcreteObserver());
subject.Attach(new ConcreteObserver());
subject.Attach(new ConcreteObserver());
subject.Attach(new ConcreteObserver());
subject.Attach(new ConcreteObserver());
subject.Notify();
subject.UpdateState("value 1");
subject.UpdateState("Value 2");



interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

class ConcreteSubject : ISubject
{
    private readonly List<IObserver> _observers = new ();
    private string state="";

    public void UpdateState(string newValue)
    {
        state = newValue;
        Notify();
    }



    public void Attach(IObserver observer)
    {
         _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(state);
        }
    }
}

interface IObserver
{
    void Update(string data);
}

class ConcreteObserver : IObserver
{
    public void Update(string data)
    {
        Console.WriteLine($"observer reacted to new value : {data}");
    }
}