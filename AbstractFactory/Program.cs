

IThemeFactory factory = new LightFactory();
var theme = new ThemeRenderer(factory);
theme.Render();



class ThemeRenderer
{
    private readonly IButton _button;
    private readonly ICheckBox _checkBox;
    public ThemeRenderer(IThemeFactory factory)
    {
        _button =factory.CreateButton();
        _checkBox= factory.CreateCheckBox();
    }
    public void Render()
    {
        _button.Render();
        _checkBox.Render();
    }
}


interface IThemeFactory
{
    IButton CreateButton();
    ICheckBox CreateCheckBox();
}

class LightFactory : IThemeFactory
{
    public IButton CreateButton()
    {
        return new LightButton();
    }

    public ICheckBox CreateCheckBox()
    {
        return new LightCheckBox();
    }
}
class DarkFactory : IThemeFactory
{
    public IButton CreateButton()
    {
        return new DarkButton();
    }

    public ICheckBox CreateCheckBox()
    {
        return new DarkCheckBox();
    }
}

interface IButton
{
    void Render();
}
class LightButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rending Light Button");
    }
}

class DarkButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rending Dark Button");
    }
}

interface ICheckBox
{
    void Render();
}
class LightCheckBox : ICheckBox
{
    public void Render()
    {
        Console.WriteLine("Rending Light CheckBox");
    }
}

class DarkCheckBox : ICheckBox
{
    public void Render()
    {
        Console.WriteLine("Rending Dark CheckBox");
    }
}
