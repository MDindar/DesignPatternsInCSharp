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


