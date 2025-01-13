
# Strategy Design Pattern

## Definition : 

### GoF Definition : 
Define a family of algorithms, encapsulate each one, and make them interchangeable. Strategy lets the algorithm vary independently from client that use it.

### Another Defnition : 

Putting interchangeable logic behind an interface

It will let an algorithm or logic (The Strategy) used by clients to achive something vary independently from the clients that use it.

![Uml Diagram](https://raw.githubusercontent.com/MDindar/DesignPatterns/refs/heads/main/Strategy/assets/Strategy.png)
## Simple Implementation : 
```cs

Context c1 = new Context( new Sterategy1());
c1.ExcecuteSterategy();

Context c2 = new Context( new Sterategy2());
c2.ExcecuteSterategy();


new Sterategy1().Execute();

class Context
{
    private ISterategy _strategy;

    public Context(ISterategy strategy)
    {
        _strategy = strategy;
    }

    public void ExcecuteSterategy()
    {
        _strategy.Execute();
    }
}


interface ISterategy
{
    void Execute();
}
class Sterategy1 : ISterategy
{
    public void Execute()
    {
        Console.WriteLine("Sterategy1 is executing ...");
    }
}
class Sterategy2 : ISterategy
{
    public void Execute()
    {
        Console.WriteLine("Sterategy2 is executing ...");
    }
}
```



## Exporting A Report
```cs

var order = new Order(){Id=10};

order.Export("csv");
order.Export("pdf");


class Order
{
    public int Id { get; set; }

    public void Export(string format)
    {
        IExportStrategy exportStrategy = StrategyFactory.GetStrategy(format);
        exportStrategy.Export(this);
    }
}

class StrategyFactory
{
    public static IExportStrategy GetStrategy(string format)
    {
        switch (format)
        {
            case "csv": return new CsvExportStrategy();
            case "pdf": return new PdfExportStrategy();
            default: throw new ArgumentException("invalid strategy type");
        }
    }
}

interface IExportStrategy
{
    void Export(Order order);
}


class CsvExportStrategy : IExportStrategy
{
    public void Export(Order order)
    {
        Console.WriteLine($" Exporting order id {order.Id} to csv");
    }
}
class PdfExportStrategy : IExportStrategy
{
    public void Export(Order order)
    {
        Console.WriteLine($" Exporting order id {order.Id} to pdf");
    }
}

```