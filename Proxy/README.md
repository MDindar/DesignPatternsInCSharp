# Proxy Design Pattern

### GoF Definition :

Provide a surrogate or place holder for another object to control access it

If A want B, Instead of directly invoking B , it call C and C decide(control) wether call B or itself return a result

# Similar Pattern :

## Adapter

in contrast to Proxy, Adapter do not add behavior , Just make the conponenet compatible

## Decorator

Similar, But in Decorator A doesn't know it working with B or C , Because they have a common interface,But in Proxy it knows working with B (Proxy Object)

## Facade

Similar, Just a wrapper for invoking complex system, porpuse : Simplify access or provide a uniform interface to a subsystem

# Proxy Types (based on their responsibilities) :

## 1.Remote Proxy :

Provide a local representation for a remote object ( add serialization , deserialization , retry logic)

## 2.Virtual Proxy :

A place holder for expensive objects ( Lazy Loading)

## 3.Protection/Authentication Proxy :

used for Access Control (control the access to the original object)

## 4.Smart Reference :

Used in unmanaged languages like C and C++, for reference counting , memory management and thread-safety

## 5.Caching

Store the result of expensive object

![Uml Diagram](https://raw.githubusercontent.com/MDindar/DesignPatterns/refs/heads/main/Proxy/assets/image.png)
# Basic Implementation :

```cs
Subject subject = new SubjectProxy(isAuthentication:false);
subject.Operation();

Subject subject2 = new SubjectProxy(isAuthentication:true);
subject2.Operation();
subject2.Operation();



class RealSubject : Subject
{
    public void Operation()
    {
        Console.WriteLine("RealSubject : Doing some big task .....................................");
    }
}

class SubjectProxy : Subject
{
    private RealSubject _realSubject = null!;
    private bool isAuthentication;

    public SubjectProxy(bool isAuthentication)
    {
        this.isAuthentication = isAuthentication;
    }

    public void Operation()
    {
        Console.WriteLine("proxy : start operation");

        if(!isAuthentication)
        {
            Console.WriteLine("proxy : It's not authentication , terminate ");
            return;
        }

        if (_realSubject is null)
        {
            Console.WriteLine("proxy : Doing some small task ...........");
            _realSubject = new RealSubject();
            return ;
        }
        _realSubject.Operation();
    }
}

interface Subject
{
    void Operation();
}
```