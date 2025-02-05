// See https://aka.ms/new-console-template for more information
class Trainer(string name) : IVisitor
{
    public string Name { get; } = name;

    public void Visit(Lion animal)
    {
        Console.WriteLine($"{Name} train {animal.Name}");
    }

    public void Visit(Elephant animal)
    {
        Console.WriteLine($"{Name} train {animal.Name}");
    }

    public void Visit(Parrot animal)
    {
        Console.WriteLine($"{Name} train {animal.Name}");
    }
}
