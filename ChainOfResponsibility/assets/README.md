# Definition : 

The Chain of Responsibility design pattern avoids coupling the sender of a request to its receiver by giving more than one object a chance to handle the request. This pattern chains the receiving objects and passes the request along the chain until an object handles it. 

![Uml Diagram](https://raw.githubusercontent.com/MDindar/DesignPatterns/refs/heads/main/ChainOfResponsibility/assets/image.png)
# Benefits : 

Reduced coupling between client and reciever
Flexibility : we can change and modify chain in runtime
	we can add link , remove link 
Single responsiblity of each handler
Simple to extend more handler

# Draw backs : 
Performance (if chain is long)
No quarantee the chain handle the request
Tequire more rebust error handling 
Increased compllexity especially while debuging and dynamic chain

## Most basic implementation : 

```cs
var handler1 = new ConcreteHandler1();
var handler2 = new ConcreteHandler2();
var handler3 = new ConcreteHandler3();

handler1.SetSuccessor(handler2);
handler2.SetSuccessor(handler3);

handler1.Handle("C");

abstract class Handler
{
    protected Handler? _successor;
    public abstract void Handle(string request);

    public void SetSuccessor(Handler successor)
    {
        _successor = successor;
    }
}

class ConcreteHandler1 : Handler
{
    public override void Handle(string request)
    {
        if (request == "A")
        {
            Console.WriteLine("Handling request by ConcreteHandler1");
            return;
        }
        if (_successor == null)
        {
            return;
        }
        else
        {
            _successor.Handle(request);
        }
    }
}
class ConcreteHandler2 : Handler
{
    public override void Handle(string request)
    {
        if (request == "B")
        {
            Console.WriteLine("Handling request by ConcreteHandler2");
            return;
        }
        else if (_successor != null)
        {
            _successor.Handle(request);
        }
    }
}

class ConcreteHandler3 : Handler
{
    public override void Handle(string request)
    {
        if (request == "C")
        {
            Console.WriteLine("Handling request by ConcreteHandler3");
        }
        else
            _successor?.Handle(request);
    }
}
```