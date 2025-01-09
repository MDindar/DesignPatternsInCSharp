# Adapter Design Pattern 

![alt](/assets/Adapter.jpg)
## Definition : 

Convert the interface of a class into another interface that clients expect.
The adapter pattern lets classes work together that couldn't otherwise because of incompatible interface

In simple words , it make 2 interfaces compatible with one another

## Participants

1. Adaptee: Is a class that client want to consume , but it has a different interface (structure) that we are familiar with 
2. Adapter: A class that implement the Target interface and and it implementation invoke Adaptee. this class used by client
3. Target: Is an interface that client use it and Adapter implement it

## When to use : 

Legacy Code Integration : When you need to integrate a legacy system or a third party library with an existing system that expect a specific interface

## Implementation : 
```cs
Shape shape1 = new Rectangle();
shape1.Draw();

Shape shape2 = new TextShape();
shape2.Draw();

// ThidPartyTextView? textView = new ThidPartyTextView();
// textView.AdvancedDraw();

Shape shape3 = new TextViewAdapter(new ThidPartyTextView());
shape3.Draw();



interface Shape
{
    public void Draw();
}

class Rectangle : Shape
{
    public void Draw()
    {
        Console.WriteLine("Drawing Rectangle");
    }
}
class TextShape : Shape
{
    public void Draw()
    {
        // very hard to impelement
    }
}


class TextViewAdapter(ThidPartyTextView textView) : Shape
{
    public void Draw()
    {
        textView.AdvancedDraw();
    }
}

class ThidPartyTextView
{
    public void AdvancedDraw()
    {
        Console.WriteLine("Drawing advanced text by ThidPartyTextView");
    }
}
```