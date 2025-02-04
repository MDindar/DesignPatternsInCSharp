## Basic Implementation : 
```cs
FlyweightClient client = new FlyweightClient();
client.AddFlyweight("A",1);
client.AddFlyweight("A",2);
client.AddFlyweight("B",1);
client.AddFlyweight("C",3);
client.AddFlyweight("C",4);

client.ExecuteAllOperation();



class FlyweightClient
{
    private FlyweightFactory factory = new FlyweightFactory();
    private List<(IFlyweight, int)> flyweights = new List<(IFlyweight, int)>();
    public void AddFlyweight(string intrinsicState, int extrinsicState)
    {
        IFlyweight flyweight = factory.GetFlyweight(intrinsicState);
        //flyweight.Operation(extrinsicState);
        flyweights.Add((flyweight,extrinsicState));
    }

    public void ExecuteAllOperation()
    {
        foreach (var (flyweight, extrinsicState) in flyweights)
        {
            flyweight.Operation(extrinsicState);
        }
    }
}

class ConcreteFlyweight(string intrinsicState):IFlyweight
{
    private readonly string _intrinsicState = intrinsicState;


    public void Operation(int extrinsicState)
    {
        Console.WriteLine($"ConcreteFlyweight  IntrinsicState : {_intrinsicState} , ExtrinsicState : {extrinsicState}");
    }
}

interface IFlyweight
{
    void Operation(int extrinsicState);
}

class FlyweightFactory
{
    private readonly Dictionary<string,IFlyweight> _flyweights =[];


    public IFlyweight GetFlyweight(string key)
    {
        if(!_flyweights.ContainsKey(key))
        {
            _flyweights[key] = new ConcreteFlyweight(key);
        }
        return _flyweights[key];
    }
}
```

## Game forest example : 
```cs
Forest forest = new Forest();

forest.AddTree("Pine", "light Greeen", 10, 10, 100);
forest.AddTree("Pine", "light Greeen", 20, 30, 50);
forest.AddTree("Pine", "Dark Greeen", 50, 50, 80);

forest.RenderAllTrees();

class Forest
{
    private TreeFactory factory = new TreeFactory();
    private List<(ITree, int x, int y, int height)> trees = new List<(ITree, int x, int y, int height)>();
    public void AddTree(string name, string color, int x, int y, int height)
    {
        ITree tree = factory.GetTree(name, color);
        //flyweight.Operation(extrinsicState);
        trees.Add((tree, x, y, height));
    }

    public void RenderAllTrees()
    {
        foreach (var (flyweight, x, y, height) in trees)
        {
            flyweight.Render(x, y, height);
        }
    }
}

class Tree(string name, string color) : ITree
{
    private readonly string _name = name;
    private readonly string _color = color;

    public void Render(int x, int y, int height)
    {
        Console.WriteLine($"Rending {_name} Tree at {x},{y} with height {height} with color :{_color}");
    }
}

interface ITree
{
    void Render(int x, int y, int height);
}

class TreeFactory
{
    private readonly Dictionary<(string, string), ITree> _trees = [];


    public ITree GetTree(string name, string color)
    {
        var key = (name, color);
        if (!_trees.ContainsKey(key))
        {
            _trees[key] = new Tree(name, color);
            Console.WriteLine($"creating new  {color} {name} tree");
        }
        else
        {
            Console.WriteLine($"reusing existing  {color} {name } tree");
        }
        return _trees[key];
    }
}
```