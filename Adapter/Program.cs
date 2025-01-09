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