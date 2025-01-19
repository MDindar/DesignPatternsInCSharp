// See https://aka.ms/new-console-template for more information


// var ticket1 = new Ticket("ticket1",SupportLevel.Low);
// var ticket2 = new Ticket("ticket1",SupportLevel.Medium);
class HighLevelHandler : SupportHandler
{
    protected override bool CanHandle(Ticket ticket)
    {
        return ticket.SupportLevel == SupportLevel.High;
    }

    protected override void ProcessTicket(Ticket ticket)
    {
        Console.WriteLine($"Handling ticket {ticket.Description} by HighLevelHandler");
    }
}
