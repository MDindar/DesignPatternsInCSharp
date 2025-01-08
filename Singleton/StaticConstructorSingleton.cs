
/// <summary>
/// Therad-safe, Lazy
/// </summary>
sealed class StaticConstructorSingleton
{
    public static  string SomeProperty { get; set; }
    public  static  StaticConstructorSingleton Instance => Nested.Instance;
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