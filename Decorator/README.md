# Decorator Design Pattern

[![Decorator](https://img.youtube.com/vi/Z9x5BFfj3ek&list=PLhD5YGv8gWSyYlm9oNto3xxZ5yYk12K1b&index=1&pp=gAQBiAQB/0.jpg)](https://www.youtube.com/watch?v=Z9x5BFfj3ek&list=PLhD5YGv8gWSyYlm9oNto3xxZ5yYk12K1b&index=1&pp=gAQBiAQB)

# Definition  
Attach aditional responsibility to an object *dynamically*, Decorators provide flexible alternative to extending for functionality

## By Another words : 
Decorator is a structural pattern that allows adding new behaviors to objects dynamically by placing them inside special wrapper objects, called decorators.

## UML 

![Uml Diagram](https://raw.githubusercontent.com/MDindar/DesignPatterns/refs/heads/main/Decorator/assets/Decorator.png)


### Coffee UML 
![Uml Diagram](https://raw.githubusercontent.com/MDindar/DesignPatterns/refs/heads/main/Decorator/assets/Example.png)


## Implementation for a coffee
```cs
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
```