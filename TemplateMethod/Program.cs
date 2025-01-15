
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
