// See https://aka.ms/new-console-template for more information


// var ticket1 = new Ticket("ticket1",SupportLevel.Low);
// var ticket2 = new Ticket("ticket1",SupportLevel.Medium);
abstract class SupportHandler
{
    protected SupportHandler? _successor;
    public void Handle(Ticket ticket)
    {
        Console.WriteLine($"Handler : {this.GetType().Name}");
        if (CanHandle(ticket))
        {
            ProcessTicket(ticket);
        }
        else if (_successor != null)
        {
            _successor.Handle(ticket);
        }
        else
            Console.WriteLine($"No handler found for {this.GetType().Name}");
    }

    public void SetSuccessor(SupportHandler successor)
    {
        _successor = successor;
    }

    protected abstract bool CanHandle(Ticket ticket);
    protected abstract void ProcessTicket(Ticket ticket);
}
