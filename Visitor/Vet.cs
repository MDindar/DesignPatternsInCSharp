// See https://aka.ms/new-console-template for more information
class Vet(string name) : IVisitor
{
    public string Name { get; } = name;

    public void Visit(Lion animal)
    {
        Thread.Sleep(new Random().Next(10, 100));
        Console.WriteLine($"{Name} examining {animal.Name}");
    }

    public void Visit(Elephant animal)
    {
        Thread.Sleep(new Random().Next(10, 100));
        Console.WriteLine($"{Name} examining {animal.Name}");
    }

    public void Visit(Parrot animal)
    {
        Thread.Sleep(new Random().Next(10, 100));
        Console.WriteLine($"{Name} examining {animal.Name}");
    }
}
