using System.Text.Json;
using Dumpify;

var emp1 = new Employee
{
    Name = "Majid",
    Age = 22,
    Skills = ["OOP", "Design Pattern"]
};

var emp2 = emp1.Clone();

var emp3 = emp1.DeepCopy();
emp2.Age = 20;
emp2.Name = "Mohsen";
emp2.Skills[1] = "Excel";
emp2.Dump("Emp2 after changes");
emp1.Dump("Emp1 after chaning emp2");


interface IPrototype<T>
{
    T Clone();
}

static class Utility
{
    public static T DeepCopy<T>(this T obj)
    {
        var json = JsonSerializer.Serialize(obj);
        return JsonSerializer.Deserialize<T>(json);
    }
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