## Try 1

```cs
// Try #1
var tester = new Tester();
var developer = new Developer();
developer.SetTester(tester);
developer.SendMessage("Code is ready to test");

tester.SetDeveloper(developer);
tester.SendMessage("I found a bug");

class Developer
{
    private  Tester? _tester ;

    public void SetTester(Tester tester)
    {
        _tester = tester;
    }
    public void ReceiveMessage(string message)
    {
        Console.WriteLine($"Developer received {message}");
    }
    public void SendMessage( string message)
    {
        _tester?.ReceiveMessage(message);
    }

}
class Tester
{
    private  Developer? _developer;

    public void SetDeveloper(Developer developer)
    {
        _developer = developer;
    }
    public void ReceiveMessage(string message)
    {
        Console.WriteLine($"Tester received {message}");
    }

    public void SendMessage(string message)
    {
        _developer?.ReceiveMessage(message);
    }
}
```

## Try #2

```cs
var tester = new Tester();
var developer = new Developer();
var manager = new Manager();

developer.SetCollegue(tester);
developer.SendMessage("Code is ready to test");

tester.SetCollegue(developer);
tester.SendMessage("I found a bug");

tester.SetCollegue(manager);
tester.SendMessage("I found a lot of bugs");



abstract class Colleague
{
    private Colleague? _colleague;
    public virtual void SetCollegue(Colleague colleague)
    {
        _colleague = colleague;
    }
    public virtual void SendMessage(string message)
    {
        _colleague?.ReceiveMessage(message);
    }
    public abstract void ReceiveMessage(string message);
}
class Developer : Colleague
{
    public override void ReceiveMessage(string message)
    {
        Console.WriteLine($"Developer received {message}");
    }
}
class Tester : Colleague
{
    public override void ReceiveMessage(string message)
    {
        Console.WriteLine($"Tester received {message}");
    }
}

class Manager : Colleague
{
    public override void ReceiveMessage(string message)
    {
        Console.WriteLine($"Manager received {message}");
    }
}
```

## Try #3

```cs
var mediator = new TeamMediator();
var tester = new Tester(mediator);
var developer = new Developer(mediator);
var manager = new Manager(mediator);

mediator.Register(tester);
mediator.Register(developer);
mediator.Register(manager);

developer.SendMessage("Code is ready to test");
tester.SendMessage("I found a bug");

interface IMediator
{
    void Notify(string message , Colleague sender);
    void Register(Colleague colleague);
}
class TeamMediator : IMediator
{
    public readonly List<Colleague> _colleagues=[];
    public void Notify(string message, Colleague sender)
    {
        foreach (var item in _colleagues)
        {
            if(item!=sender)
            {
                item.ReceiveMessage(message);
            }
        }
    }

    public void Register(Colleague colleague)
    {
        _colleagues.Add(colleague);
    }
}

abstract class Colleague
{
    private readonly IMediator _mediator;

    public Colleague (IMediator mediator)
    {
        _mediator = mediator;
    }

    public virtual void SendMessage(string message)
    {
        _mediator.Notify(message, this);
    }
    public abstract void ReceiveMessage(string message);
}
class Developer(IMediator mediator) : Colleague(mediator)
{
    public override void ReceiveMessage(string message)
    {
        Console.WriteLine($"Developer received {message}");
    }
}
class Tester(IMediator mediator) : Colleague(mediator)
{
    public override void ReceiveMessage(string message)
    {
        Console.WriteLine($"Tester received {message}");
    }
}

class Manager(IMediator mediator) : Colleague(mediator)
{
    public override void ReceiveMessage(string message)
    {
        Console.WriteLine($"Manager received {message}");
    }
}
```

## Try #4

```cs
var mediator = new TeamMediator();
var tester = new Tester(mediator);
var developer1 = new Developer(mediator);
var developer2 = new Developer(mediator);
var manager = new Manager(mediator);

mediator.Register(tester,developer1,manager,developer2);


developer1.SendMessage("Code is ready to test");
tester.SendMessage("I found a bug");
manager.SendMessage<Developer>("How long does it take to fix?");

interface IMediator
{
    void Notify(string message , Colleague sender);
    void Notify<T>(string message , Colleague sender) where T : Colleague;
    void Register(Colleague colleague);
    void Register(params Colleague[] colleagues);
}
class TeamMediator : IMediator
{
    private readonly List<Colleague> _colleagues=[];
    public void Notify(string message, Colleague sender)
    {
        foreach (var item in _colleagues)
        {
            if(item!=sender)
            {
                item.ReceiveMessage(message);
            }
        }
    }
     public void Notify<T>(string message, Colleague sender) where T : Colleague
    {
        foreach (var item in _colleagues.OfType<T>())
        {
            if(item!=sender)
            {
                item.ReceiveMessage(message);
            }
        }
    }

    public void Register(Colleague colleague)
    {
        _colleagues.Add(colleague);
    }

    public void Register(params Colleague[] colleagues)
    {
        foreach (var item in colleagues)
        {
            _colleagues.Add(item);
        }
    }
}

abstract class Colleague
{
    private readonly IMediator _mediator;

    public Colleague (IMediator mediator)
    {
        _mediator = mediator;
    }

    public virtual void SendMessage(string message)
    {
        _mediator.Notify(message, this);
    }
    public void  SendMessage<T>(string message) where T : Colleague
    {
        _mediator.Notify<T>(message, this);
    }
    public abstract void ReceiveMessage(string message);
}
class Developer(IMediator mediator) : Colleague(mediator)
{
    public override void ReceiveMessage(string message)
    {
        Console.WriteLine($"Developer received {message}");
    }
}
class Tester(IMediator mediator) : Colleague(mediator)
{
    public override void ReceiveMessage(string message)
    {
        Console.WriteLine($"Tester received {message}");
    }
}

class Manager(IMediator mediator) : Colleague(mediator)
{
    public override void ReceiveMessage(string message)
    {
        Console.WriteLine($"Manager received {message}");
    }


}
```

## Try #5

```cs
var mediator = new TeamMediator();
var tester = new Tester("tester1");
var developer1 = new Developer("devloper1");
var developer2 = new Developer("developer2");
var manager1 = new Manager("manager1");

mediator.Register(tester, developer1, manager1, developer2);

developer1.SendMessage("Code is ready to test");
tester.SendMessage("I found a bug");
manager1.SendMessage<Developer>("How long does it take to fix?");

interface IMediator
{
    void Notify(string message, Colleague sender);
    void Notify<T>(string message, Colleague sender) where T : Colleague;
    void Register(Colleague colleague);
    void Register(params Colleague[] colleagues);
}
class TeamMediator : IMediator
{
    private readonly List<Colleague> _colleagues = [];
    public void Notify(string message, Colleague sender)
    {
        foreach (var item in _colleagues)
        {
            if (item != sender)
            {
                Console.WriteLine($"[TRACE] : {sender.Name} to {item.Name}");
                item.ReceiveMessage(message);
            }
        }
    }
    public void Notify<T>(string message, Colleague sender) where T : Colleague
    {
        foreach (var item in _colleagues.OfType<T>())
        {
            if (item != sender)
            {
                Console.WriteLine($"[TRACE] : {sender.Name} to {item.Name}");
                item.ReceiveMessage(message);
            }
        }
    }

    public void Register(Colleague colleague)
    {
        colleague.SetMediator(this);
        _colleagues.Add(colleague);
    }

    public void Register(params Colleague[] colleagues)
    {
        foreach (var item in colleagues)
        {
            item.SetMediator(this);
            _colleagues.Add(item);
        }
    }
}

abstract class Colleague(string name)
{
    private IMediator? _mediator;

    public string Name { get; } = name;

    public void SetMediator(IMediator mediator)
    {
        _mediator = mediator;
    }

    public virtual void SendMessage(string message)
    {
        _mediator?.Notify(message, this);
    }
    public void SendMessage<T>(string message) where T : Colleague
    {
        _mediator?.Notify<T>(message, this);
    }
    public abstract void ReceiveMessage(string message);
}
class Developer(string name) : Colleague(name)
{
    public override void ReceiveMessage(string message)
    {
        Console.WriteLine($"{Name} received {message}");
    }
}
class Tester(string name) : Colleague(name)
{
    public override void ReceiveMessage(string message)
    {
        Console.WriteLine($"{Name} received {message}");
    }
}

class Manager(string name) : Colleague(name)
{
    public override void ReceiveMessage(string message)
    {
        Console.WriteLine($"{Name} received {message}");
    }
}
```
