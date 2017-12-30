using System;
using System.Collections.Generic;

namespace DIP_CS_1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<INotificationService> NotificationList = new List<INotificationService>();
            NotificationList.Add(new MailService());
            NotificationList.Add(new SMSServivce());
            WeatherPredictions TornadoPredictor = new WeatherPredictions(NotificationList);
            TornadoPredictor.PredictTornado();
        }
    }

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
}
