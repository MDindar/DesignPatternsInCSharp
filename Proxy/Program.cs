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

