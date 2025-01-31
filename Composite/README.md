## Implementation : 
```cs
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// var root = new Directory("Root");
// root.Add(new File("File1"));

// var dir1 = new Directory("Folder 1");
// dir1.Add(new File("file2"));
// dir1.Add(new File("file3"));
// root.Add(dir1);

// var dir2 = new Directory("Folder 2");
// dir2.Add(new File("File4"));

// var dir3 = new Directory("Folder 3");
// dir3.Add(new File("File5"));
// dir3.Add(new File("File6"));
// dir2.Add(dir3);
// root.Add(dir2);
// root.Display(0);

var root = new CompoisteBuilder("Root")
        .AddFile("File1")
        .AddDirectory("Folder1",
            b=>b.AddFile("File2").AddFile("File3"))
        .AddDirectory("Folder2",
            b=>b.AddFile("File4")
                .AddDirectory("Folder3",
                    b=>b.AddFile("File5").AddFile("File6")))
        .Build();
root.Display(0);

class CompoisteBuilder
{
    private readonly Directory _root;
    public CompoisteBuilder(string rootName)
    {
        _root = new Directory(rootName);
    }

    public CompoisteBuilder AddFile(string name)
    {
        _root.Add( new File(name));
        return this;
    }

    public CompoisteBuilder AddDirectory(string name, Action<CompoisteBuilder> builder)
    {
        var subCompositeBuilder = new CompoisteBuilder(name);
        builder(subCompositeBuilder);
        _root.Add(subCompositeBuilder.Build());
        return this;
    }
    public Directory Build()
    {
        return _root;
    }
}
interface ExplorerComponent
{
   int Display(int indent);
}
class File(string name) : ExplorerComponent
{
    private readonly int _size = new Random().Next(1, 9) * 10;

    public string Name { get; } = name;

    public  int Display(int indent)
    {
        Console.WriteLine(new string(' ', indent) + Name + " size : " + _size);
        return _size;
    }


}

class Directory(string name) : ExplorerComponent
{
    private readonly List<ExplorerComponent> _children = [];

    public string Name { get; } = name;

    public  void Add(ExplorerComponent c)
    {
        _children.Add(c);
    }

    public  ExplorerComponent? GetChild(int index)
    {
        if (index < 0 || index > _children.Count - 1) return null;
        return _children[index];
    }

    public  int Display(int indent)
    {

        Console.WriteLine(new string(' ', indent) + Name);
        int size = 0;
        foreach (var child in _children)
        {
            size += child.Display(indent + 3);
        }
        Console.WriteLine(new string(' ', indent) + Name + " size : " + size);
        return size;
    }

    public  void Remove(ExplorerComponent c)
    {
        _children.Remove(c);
    }
}
```