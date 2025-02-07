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
