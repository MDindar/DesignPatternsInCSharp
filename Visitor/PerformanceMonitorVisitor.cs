// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

class PerformanceMonitorVisitor(IVisitor internalVisitor) : IVisitor
{
    private readonly IVisitor _internalVisitor = internalVisitor;
    private readonly Dictionary<string, List<long>> _times = new();
    private void Measure(Action action, string animalType)
    {
        var stopWatch = Stopwatch.StartNew();
        action();
        stopWatch.Stop();

        if (!_times.ContainsKey(animalType))
        {
            _times[animalType] = new List<long>();
        }
        _times[animalType].Add(stopWatch.ElapsedMilliseconds);
    }

    public void Visit(Lion animal)
    {
        Measure(() => _internalVisitor.Visit(animal), "Lions");
    }

    public void Visit(Elephant animal)
    {
        Measure(() => _internalVisitor.Visit(animal), "Elephants");
    }

    public void Visit(Parrot animal)
    {
        Measure(() => _internalVisitor.Visit(animal), "Parrots");
    }

    public void PrintPerformance()
    {
        foreach (var item in _times)
        {
            Console.WriteLine($"{item.Key} took {item.Value.Sum()}");
        }
    }
}
