using System.Collections;

Console.WriteLine("Hello, World!");
var collection = new CustomCollection<int>(3);
collection.AddItem(1);
collection.AddItem(2);
collection.AddItem(3);

var iterator = collection.GetEnumerator();
while(iterator.MoveNext())
{
    Console.WriteLine(iterator.Current);
}
//iterator.Reset();
foreach (var item in collection)
{
    Console.WriteLine(item);
}



class CustomCollection<T> : IEnumerable<T>
{
    private readonly T[] _items;
    private int _index;
    public CustomCollection(int size)
    {
        _items= new T[size];
        _index=-1;
    }

    public void AddItem(T value) => _items[++_index] = value;

    public IEnumerator<T> GetEnumerator()
    {
        //return new CustomIterator<T>(this);
        for (int i = 0; i < _items.Length; i++)
        {
            yield return _items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
       return GetEnumerator();
    }

    public T this[int index]=>_items[index];
    public int Length=>_items.Length;
}

// class CustomIterator<T> : IEnumerator<T>
// {
//     private readonly CustomCollection<T> _collection;
//     private int _currentIndex;

//     public CustomIterator(CustomCollection<T> collection)
//     {
//         _collection = collection;
//         _currentIndex= -1;
//     }

//     public T Current => _collection[_currentIndex];

//     object IEnumerator.Current => Current!;

//     public void Dispose()
//     {
       
//     }

//     public bool MoveNext()
//     {
//         if(_currentIndex<_collection.Length-1)
//         {
//             _currentIndex++;
//             return true;
//         }
//         return false;
//     }

//     public void Reset()=> _currentIndex=-1;

// }
