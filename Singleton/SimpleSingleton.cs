
/// <summary>
/// Thread-safe , Lazy
/// </summary>
sealed class SimpleSingleton
{
    public static SimpleSingleton Instance { get; } = new SimpleSingleton();
    private SimpleSingleton()
    {
        Console.WriteLine("Constructor called");
    }
}