
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