// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var handler1 = new LowLevelHandler();
var handler2 = new MediumLevelHandler();
var handler3 = new HighLevelHandler();
// var ticket1 = new Ticket("ticket1",SupportLevel.Low);
// var ticket2 = new Ticket("ticket1",SupportLevel.Medium);
var ticket3 = new Ticket("ticket3", SupportLevel.High);

var configurer = new HandlerConfigurer( [handler1,handler3,handler2]);
configurer.StartProcessing(ticket3);

class HandlerConfigurer
{
    private readonly List<SupportHandler> _handlers;

   public HandlerConfigurer(List<SupportHandler> handlers)
    {
        _handlers = handlers;
        for (int i = 0; i < _handlers.Count - 1; i++)
        {
            _handlers[i].SetSuccessor(_handlers[i + 1]);
        }
    }

    public void StartProcessing(Ticket ticket)
    {
        if (_handlers.Count > 0)
            _handlers[0].Handle(ticket);
    }
}



