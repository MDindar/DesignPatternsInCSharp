// See https://aka.ms/new-console-template for more information




interface IAnimal
{
    public string Name { get; }

    public void Accept(IVisitor visitor);
}
