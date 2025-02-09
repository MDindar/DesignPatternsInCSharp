

var circle = new Circle(10,new VectorRenderer());
circle.Draw();

var square = new Square(20, new RasterRenderer());
square.Draw();

var rectangle = new Rectangle(10,20, new FractalRenderer());
rectangle.Draw();
interface IRenderer
{
    string Render();
}

class VectorRenderer : IRenderer
{
    public string Render() => "vector logic to render as vector";
}
class RasterRenderer : IRenderer
{
    public string Render() => "raster logic to render as raster";
}
class FractalRenderer : IRenderer
{
     public string Render() => "fractal logic to render as fractal";
}

abstract class Shape(IRenderer renderer)
{
    protected readonly IRenderer _renderer = renderer;

    public abstract void Draw();
}

class Circle(float radious,IRenderer renderer) : Shape(renderer)
{
    private readonly float _radious = radious;

    public override void Draw() => Console.WriteLine($"Drawing Circle with radious {_radious} by {_renderer.Render()}");
}

class Square(float sideLength,IRenderer renderer) : Shape(renderer)
{
    private readonly float _sideLength = sideLength;

    public override void Draw() => Console.WriteLine($"Drawing Square with radious {_sideLength} by {_renderer.Render()}");
}

class Rectangle(float width, float height, IRenderer renderer) : Shape(renderer)
{
    private readonly float _width = width;
    private readonly float _height = height;
    public override void Draw() => Console.WriteLine($"Drawing ractangle with with {_width} and hight {_height}  by {_renderer.Render()}");
}



