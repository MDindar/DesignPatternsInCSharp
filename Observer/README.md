# Observer Design Pattern 

## Definition 

Define an one-to-many dependency between objects so that when one object changes state, all its dependents are notfified and updated automatially

## Use-cases 
When a change to on object requires changing others, and you don't know in advance how many objects need to be changed

When an object should be able to notify other objects without making assumption about who those objects are

When objects that ovserve others are not necessarily don't live for the total amount of time the applicaion run


## Drawbacks : 

1. Make sure to Detach when you are done
2. Make sure do not update state while getting data from the subject (Cascade of update)
3. performance ( make batch update)


![Uml Diagram](https://raw.githubusercontent.com/MDindar/DesignPatterns/refs/heads/main/Observer/assets/image.png)
## Implementation

```cs
ConcreteSubject subject = new ConcreteSubject();

subject.Attach(new ConcreteObserver(subject));
subject.Attach(new ConcreteObserver(subject));
subject.Attach(new ConcreteObserver(subject));
subject.Attach(new ConcreteObserver(subject));
subject.Attach(new ConcreteObserver(subject));
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

    public string GetState() => state;

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
            observer.Update();
        }
    }
}

interface IObserver
{
    void Update();
}

class ConcreteObserver(ConcreteSubject subject) : IObserver
{
    private ConcreteSubject _subject = subject;

    public void Update()
    {
        var result = _subject.GetState();
        Console.WriteLine($"observer reacted to new value : {result}");
    }
}

```