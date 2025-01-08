

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