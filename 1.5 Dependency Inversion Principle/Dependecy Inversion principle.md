# Dependency Inversion Principle

> A. High-level modules should not depend on low-level modules. Both should depend on abstractions.
> B. Abstractions should not depend on details. Details should depend on abstractions.

## Why this is important ?

For understand this, you need the concept of coupling :

- Tight coupling is when a group of classes are highly dependent on one another.

Then, when a class A depends on a class B, any change of B class can break the A class. And also, if you want to use multiple resources, for example A depends on B or C classes, you need to modify the code of A class, this means what the class A does not complies with OCP. 

But if your class A depends on an abstraction, like a base class, an interface or a async call (like delegates c#), any class what has implemented that resource, will be complatible with A. 

But talking about the second statement that says "Abstractions should not depend on details. Details should depend on abstractions." it's more complex to understand but is a rule to create good abstractions.

In other words, don't do things like this : 

```C#
interface INotification
{
    void SendSMSNotification();
    void SendEmailNotification();
}
```

In this horrible example we are creating an interface with details inside it. What if there are a third light? You will need to modify the interface and all of the classes that implement that!!

Let's see some examples:

You are creating a software what process a lot of information about weather, and you want to notify in some way when the process is terminated. Then you create something like this:

```C#
class MailService
{
    public bool Send(...)
    {
        //Send mail logic... if it's all ok retur true
        return true;
    }
}
class WeatherPredictions
{
    private MailService _mail;

    public WeatherPredictions()
    {
        _mail = new MailService();
    }

    public void PredictTornado(...)
    {
        //All the computation 
        var notif = _mail.Send( /*Info With Tornado Possibilities*/ );
        if(notif == false)
            throw new Exception("Problem with NotificationService");
    }
}
```

You test the code and it's fine and you are happy for what you do. But your boss comes with news and the mail notification is insufficient, it needs to send mail and SMS information. And for achieve this, you need to change a lot of lines of code of Weather class for doing that, and that's not good. 

Because the High-Level module (Weather) is depending on a Low-Level module (MailService) instead of an abstraction. 

In this case we can create an interface for achieve the DIP.

```C#
interface INotificationService
    {
        bool Send(string txt); 
    }

    class MailService : INotificationService
    {
        public bool Send(string txt)
        {
            //Send mail logic... if it's all ok return true
            System.Console.WriteLine($"Sending Mail with: {txt}");
            return true;
        }
    }

    class SMSServivce : INotificationService 
    {
        public bool Send(string txt)
        {
            //Send SMS logic... if it's all ok return true
            System.Console.WriteLine($"Sending SMS with: {txt}");
            return true;
        } 
    }

    class WeatherPredictions
    {
        private List<INotificationService> _NotificationServices;

        public WeatherPredictions(List<INotificationService> NotificationServices)
        {
            _NotificationServices = NotificationServices;
        }

        public void PredictTornado()
        {
            //All the computation 
            foreach(var NotificationService in _NotificationServices)
            {
                var notif = NotificationService.Send("No tornado possibilities");
                if(notif == false)
                    throw new Exception("Problem with NotificationService");
            }
        }
    }
```

This code achieves DIP because the Weather class are not depending on a class, it's depending on an abstraction called INotificationService. 
