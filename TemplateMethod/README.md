# Proxy Design Pattern

![Uml Diagram](https://raw.githubusercontent.com/MDindar/DesignPatterns/refs/heads/main/TemplateMethod/assets/image.png)

### Definition :

The Template Method Design Pattern is a behavioral design pattern that defines the skeleton of an algorithm in a base class, allowing subclasses to override specific steps of the algorithm without changing its structure.

# Basic Implementation :

```cs
BaseClass instance1 = new Concret1();
instance1.TemplateMethod();

BaseClass instance2 = new Concret2();
instance2.TemplateMethod();

abstract class BaseClass
{
    public void TemplateMethod()
    {
        Step1();
        Step2();
        Step3();
    }

    protected virtual void Step3()
    {
        Console.WriteLine("Step3 : simple default process in base class");
    }

    protected abstract void Step2();

    private void Step1()
    {
        Console.WriteLine("Step1 : Some common process in base class");
    }
}

class Concret1 : BaseClass
{
    protected override void Step2()
    {
        Console.WriteLine("Step2 : Some specific process in Concret1");
    }

    protected override void Step3()
    {
        Console.WriteLine("Step3 : some advanced process in Concrete1");
    }
}
class Concret2 : BaseClass
{
    protected override void Step2()
    {
        Console.WriteLine("Step2 : Some specific process in Concret2");
    }
}
```

## FileExporter example :

```cs
var plainText = "Some plain text need to export";

DocumentExporter instance1 = new PdfExporter(plainText);
instance1.TemplateMethod();
Console.WriteLine(" ");
DocumentExporter instance2 = new WordExporter(plainText);
instance2.TemplateMethod();

abstract class DocumentExporter
{
    protected string _plainText;
    protected string _processedText=string.Empty;

    protected DocumentExporter(string plainText)
    {
        _plainText = plainText;
    }

    public void TemplateMethod()
    {
        AddContentType();
        CustomizeExport();
        FinalizeExport();
    }

    private void FinalizeExport()
    {
        Console.WriteLine(_processedText);
    }

    protected virtual void CustomizeExport()
    {

    }

    protected abstract void AddContentType();
}

class PdfExporter : DocumentExporter
{
    public PdfExporter(string plainText) : base(plainText)
    {
    }

    protected override void AddContentType()
    {
        _processedText= "Content-Type: application/pdf \n"+_plainText;
    }

    protected override void CustomizeExport()
    {
        _processedText+="\n Adding some pdf footer";
    }
}
class WordExporter : DocumentExporter
{
    public WordExporter(string plainText) : base(plainText)
    {
    }

    protected override void AddContentType()
    {
        _processedText= "Content-Type: application/msword \n"+_plainText;
    }
}
```
