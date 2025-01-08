
/// <summary>
/// Thread-safe, Lazy
/// </summary>
sealed class LazyTypeSingleton
{
    private static readonly Lazy<LazyTypeSingleton> _instance =
             new Lazy<LazyTypeSingleton>(() => new LazyTypeSingleton());
    public static LazyTypeSingleton Instance => _instance.Value;
    private LazyTypeSingleton()
    {
        Console.WriteLine("Constructor called");
    }
}