// See https://aka.ms/new-console-template for more information


class Zoo
{
    private readonly List<IAnimal> _animals = [];

    public void Add(IAnimal animal)
    {
        _animals.Add(animal);
    }

    public void AcceptVisitor(IVisitor visitor)
    {
        foreach (var animal in _animals)
        {
            animal.Accept(visitor);
        }
    }
}
