## Basic Implementation Of Iterator without dotnet IEnumerable
```cs
Console.WriteLine("Hello, World!");
Aggregate collection = new CustomCollection(3);
collection.AddItem("Item1");
collection.AddItem("Item2");
collection.AddItem("Item3");
var iterator = collection.CreateIterator();
while(iterator.MoveNext())
{
    Console.WriteLine(iterator.Current);
}


interface Aggregate
{
    void AddItem(string value);
    Iterator CreateIterator();
}


class CustomCollection : Aggregate
{
    private readonly object[] _items;
    private int _index;
    public CustomCollection(int size)
    {
        _items= new object[size];
        _index=-1;
    }

    public void AddItem(string value) => _items[++_index] = value;

    public Iterator CreateIterator()
    {
        return new CustomIterator(this);
    }

    public Object this[int index]=>_items[index];
    public int Length=>_items.Length;
}
interface Iterator
{
    object Current{get;}

    bool MoveNext();
    void Rest();
}
class CustomIterator : Iterator
{
    private readonly CustomCollection _collection;
    private int _currentIndex;

    public CustomIterator(CustomCollection collection)
    {
        _collection = collection;
        _currentIndex= -1;
    }
    public object Current => _collection[_currentIndex];

    public bool MoveNext()
    {
        if(_currentIndex<_collection.Length-1)
        {
            _currentIndex++;
            return true;
        }
        return false;
    }

    public void Rest()=> _currentIndex=-1;
}
```

## Generic IMplementation by donet IEnumerable : 

```cs
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
iterator.Reset();
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
        return new CustomIterator<T>(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
       return GetEnumerator();
    }

    public T this[int index]=>_items[index];
    public int Length=>_items.Length;
}

class CustomIterator<T> : IEnumerator<T>
{
    private readonly CustomCollection<T> _collection;
    private int _currentIndex;

    public CustomIterator(CustomCollection<T> collection)
    {
        _collection = collection;
        _currentIndex= -1;
    }

    public T Current => _collection[_currentIndex];

    object IEnumerator.Current => Current!;

    public void Dispose()
    {
       
    }

    public bool MoveNext()
    {
        if(_currentIndex<_collection.Length-1)
        {
            _currentIndex++;
            return true;
        }
        return false;
    }

    public void Reset()=> _currentIndex=-1;

}
```