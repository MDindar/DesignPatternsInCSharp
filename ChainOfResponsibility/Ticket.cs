// See https://aka.ms/new-console-template for more information


// var ticket1 = new Ticket("ticket1",SupportLevel.Low);
// var ticket2 = new Ticket("ticket1",SupportLevel.Medium);
record Ticket(string Description, SupportLevel SupportLevel);
