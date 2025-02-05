// See https://aka.ms/new-console-template for more information
class ReporterVisitor : IVisitor
{
    int lionCount, elephantCount, parrotCount = 0;
    public void Visit(Lion animal)
    {
        lionCount++;
    }

    public void Visit(Elephant animal)
    {
        elephantCount++;
    }

    public void Visit(Parrot animal)
    {
        parrotCount++;
    }
    public void DisplayReport()
    {
        Console.WriteLine($"Lions {lionCount}");
        Console.WriteLine($"Elephants {elephantCount}");
        Console.WriteLine($"Parrots {parrotCount}");

    }
}
