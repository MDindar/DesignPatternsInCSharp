
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
