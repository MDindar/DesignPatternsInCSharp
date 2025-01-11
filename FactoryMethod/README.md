# Factory Method Design Pattern

**GoF Definition**: 

Define an interface for creating an object, but let subclasses decide which class to instantiate.
Factory method lets a class defer instantiation to subclasses

**Another Definition** :

Factory Method is a Pattern that provides an interface for creating objects in a superclass, but allows subclasses to alter the type of objects that will be created.

## Parties :

1. Creator/Factory(abstract)
2. ConcreteCreators
3. Product (interface/abstract)
4. ConcreteProducts

## Notification Example:

1. NotificaitonFactory
2. SmsNotificaitonCreator,EmailNotificaitonCreator
3. INotificaiton
4. SmsNotificaiton,EmailNotificaiton

![Uml Diagram](https://raw.githubusercontent.com/MDindar/DesignPatterns/refs/heads/main/FactoryMethod/assets/FactoryMethod.png)
## Simple Factory Implementation:

```cs
var factory = new SimpleFactory();
var productA = factory.CreateProduct("A");
var productB = factory.CreateProduct("B");


class SimpleFactory
{
    public  IProduct CreateProduct(string type)
    {
       switch(type)      
       {
        case "A" : return new ProductA();
        case "B" : return new ProductB();
        default : throw new ArgumentException("Invalid product type");
       }
    }
}

interface IProduct;
class ProductA: IProduct;
class ProductB :IProduct;
```
## Factory Method Implementation
```cs

Creator creator1 = new CreatorA();
IProduct productA = creator1.CreateProduct();

Creator creator2 = new CreatorA();
IProduct productB = creator2.CreateProduct();


abstract class Creator
{
    public abstract IProduct CreateProduct();
}

class CreatorA : Creator
{
    public override IProduct CreateProduct()
    {
        return new ProductA();
    }
}
class CreatorB : Creator
{
    public override IProduct CreateProduct()
    {
        return new ProductB();
    }
}

interface IProduct;
class ProductA: IProduct;
class ProductB :IProduct;
```
![Uml Diagram](https://raw.githubusercontent.com/MDindar/DesignPatterns/refs/heads/main/FactoryMethod/assets/image.png)
## Factory Method "Notification Example"
```cs


NotificationFactory smsFactory = new SmsNotificationCreator();
smsFactory.Notify("some sms message");


NotificationFactory emailFactory = new EmailNotificationCreator();
emailFactory.Notify("Some Email message");



abstract class NotificationFactory
{
    public abstract INotification CreateNotification();

    public void Notify(string message)
    {
        INotification notification = CreateNotification();
        notification.Send(message);
        notification.Log(message);
    }
}

class SmsNotificationCreator : NotificationFactory
{
    public override INotification CreateNotification()
    {
        return new SmsNotification();
    }
}

class EmailNotificationCreator : NotificationFactory
{
    public override INotification CreateNotification()
    {
        return new EmailNotification();
    }
}
interface INotification
{
    void Send(string message);
    void Log(string message);
}
class SmsNotification : INotification
{
    public void Log(string message)
    {
        Console.WriteLine("sms logging ...");
    }

    public void Send(string message)
    {
        Console.WriteLine($"Sending {message} via Sms provider");
    }
}
class EmailNotification : INotification
{
    public void Log(string message)
    {
        Console.WriteLine("Email logging");
    }

    public void Send(string message)
    {
        Console.WriteLine($"Sending {message} via Email Provider");
    }
}
```