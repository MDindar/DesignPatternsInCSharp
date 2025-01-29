

## basic implementation : 
```cs
Console.WriteLine("Hello, World");

ConcretePrototype1 type1 = new ConcretePrototype1();
ConcretePrototype1 type2 = type1.Clone();
ConcretePrototype1 type3 = type1.Clone();


interface IPrototype<T>
{
    T Clone();
}



class ConcretePrototype1 : IPrototype<ConcretePrototype1>
{
    public ConcretePrototype1 Clone()
    {
        return new ConcretePrototype1();
    }
}

class ConcretePrototype2 : IPrototype<ConcretePrototype2>
{
    public ConcretePrototype2 Clone()
    {
        return new ConcretePrototype2();
    }
}
```

## Prototype by using MememberWiseClone()
```cs

using Dumpify;

var emp1 = new Employee
{
    Name = "Majid",
    Age = 22,
    Skills = ["OOP", "Design Pattern"]
};

var emp2 = emp1.Clone();
emp1.Dump("Emp1");
emp2.Dump("Emp2");
emp2.Age = 20;
emp2.Name = "Mohsen";
emp2.Skills[1] = "Excel";
emp2.Dump("Emp2 after changes");
emp1.Dump("Emp1 after chaning emp2");


interface IPrototype<T>
{
    T Clone();
}


record Address(string City , string Street, List<string> Phones) ;

class Employee : IPrototype<Employee>
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public List<string> Skills { get; set; } = [];
    public Address? Address { get; set; }

    public Employee Clone()
    {
        var cloned = (Employee)this.MemberwiseClone();
        cloned.Skills = new List<string>(Skills);
        if(Address!=null)
            cloned.Address = this.Address with{Phones= new List<string>(Address.Phones)};
        return cloned;
    }
}
```