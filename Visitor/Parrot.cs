// See https://aka.ms/new-console-template for more information






class Parrot(string name) : IAnimal
{
    public string Name { get; } = name;
    public void Accept(IVisitor visitor) => visitor.Visit(this);

}
