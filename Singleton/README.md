# Singleton Design Pattern in C#
[![Singleton](https://img.youtube.com/vi/https://www.youtube.com/watch?v=qXJRVktxCtA&list=PLhD5YGv8gWSyYlm9oNto3xxZ5yYk12K1b&index=5&pp=gAQBiAQB/0.jpg)](https://www.youtube.com/watch?v=https://www.youtube.com/watch?v=qXJRVktxCtA&list=PLhD5YGv8gWSyYlm9oNto3xxZ5yYk12K1b&index=5&pp=gAQBiAQB)

### Definition :

Singleton is a class that only allows a single instance of itself to be created.


### Use-cases :

In scenarios where in the entire application we need to have only a single instance of a class. For example :

Business Identifier Generator, Configuration Management, Logging, Database connection pooling, Caching and ...


### General Steps :

1. A single private parameterless constructor
2. A public static property (or method) for getting to the single created instance
3. A private static field which holds a reference to the single created instance
4. Beter to make the class sealed

### Consideration Requirements :

2. Being Thread-safe
1. Lazy initialization

### Solutions :

1. Simple Singleton
```cs

/// <summary>
/// Thread-safe , Not Lazy
/// </summary>
sealed class SimpleSingleton
{
    public static SimpleSingleton Instance { get; } = new SimpleSingleton();
    private SimpleSingleton()
    {
        Console.WriteLine("Constructor called");
    }
}
```
2. Using `Lazy<T>`
```cs

/// <summary>
/// Thread-safe, Lazy
/// </summary>
sealed class LazyTypeSingleton
{
    private static Lazy<LazyTypeSingleton> _instance = new Lazy<LazyTypeSingleton>(() => new LazyTypeSingleton());
    public static LazyTypeSingleton Instance => _instance.Value;
    private LazyTypeSingleton()
    {
        Console.WriteLine("Constructor called");
    }
}
```
3. using `Static` constructor
```cs

/// <summary>
/// Therad-safe, Lazy
/// </summary>
sealed class StaticConstructorSingleton
{
    public static string SomeProperty { get; set; }
    public static StaticConstructorSingleton Instance => Nested.Instance;
    private StaticConstructorSingleton()
    {
        Console.WriteLine("Constructor called");
    }


    private class Nested
    {
        internal static StaticConstructorSingleton Instance = new StaticConstructorSingleton();

        static Nested()
        {

        }
    }
}
```
4. Using `Lock` (NOT RECOMMENDED)
```cs

/// <summary>
/// Thread-safe , Lazy
/// Not Recommended
/// </summary>
sealed class NotOptimal
{
    private static NotOptimal _instance = null!;
    private static object _instanceLock = new object();
    public static NotOptimal Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_instanceLock)
                {
                    Console.WriteLine("locked");
                    if (_instance == null)
                    {
                        _instance = new NotOptimal();
                    }
                }
            }
            return _instance;
        }
    }
    private NotOptimal()
    {
        Console.WriteLine("Constructor called");
    }
}
```
