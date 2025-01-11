ICoffee order1 = new SimpleCoffee();
Console.WriteLine($"order1: {order1.GetDescription()}, Price : {order1.Cost()}");

ICoffee order2 = new MilkDecorator(new SugerDecorator(new SimpleCoffee()));
Console.WriteLine($"order2: {order2.GetDescription()}, Price : {order2.Cost()}");


interface ICoffee
{
    double Cost();
    string GetDescription();
}

abstract class Decorator(ICoffee coffee) : ICoffee
{
    protected ICoffee _coffee = coffee;

    public virtual double Cost() => _coffee.Cost();

    public virtual string GetDescription() => _coffee.GetDescription();
}

class MilkDecorator : Decorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee)
    {
    }

    public override double Cost() => base.Cost() + 10;
    public override string GetDescription() => base.GetDescription() + "+ Milk";
}
class SugerDecorator : Decorator
{
    public SugerDecorator(ICoffee coffee) : base(coffee)
    {
    }

    public override double Cost() => base.Cost() + 2;
    public override string GetDescription() => base.GetDescription() + "+ Suger";
}
class CreamDecorator : Decorator
{
    public CreamDecorator(ICoffee coffee) : base(coffee)
    {
    }

    public override double Cost() => base.Cost() + 5;
    public override string GetDescription() => base.GetDescription() + "+ Cream";
}

class SimpleCoffee : ICoffee
{
    public double Cost() => 50;
    public string GetDescription() => "Simple Coffee";
}