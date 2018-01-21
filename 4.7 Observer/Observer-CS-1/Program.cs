using System;
using System.Collections.Generic;

/// <summary>
/// This is a BAD example of how the class User is tightly coupled with other Users
/// Although it fulfills its objective, have suscribers and notify them this is not
/// an observer pattern because two things.
///  - User is also an subject and observer.
///  - The user only can suscribe other user classes.
/// </summary>
namespace Observer_CS_1
{
    class Program
    {
        static void Main(string[] args)
        {
            User MuhammadAli = new User("Muhammad Ali");
            User MarceloTinelli = new User("Marcelo Tinelli");
            User MuhammadFanA = new User("MuhammadFanA");
            User MuhammadFanB = new User("MuhammadFanB");
            User TinelliFanA = new User("FanA");
            User TinelliFanB = new User("FanB");
            User TinelliFanC = new User("FanC");

            MuhammadAli.Suscribe(MarceloTinelli);
            MuhammadAli.Suscribe(MuhammadFanA);
            MuhammadAli.Suscribe(MuhammadFanB);
            MarceloTinelli.Suscribe(TinelliFanA);
            MarceloTinelli.Suscribe(TinelliFanB);
            MarceloTinelli.Suscribe(TinelliFanC);

            MuhammadAli.NotificateUsers("Hey Fans, My last fight will be tomorrow");
            MarceloTinelli.NotificateUsers("Videomatch will return the next year");
        }
    }
    interface ISuscriber
    {
        void AddNotification(string Notification);
    }
    interface IPublisher
    {
        void Suscribe(User follower);
        void Unsuscribe(User follower);
        void NotificateUsers(string Message);
    }

    class User : IPublisher, ISuscriber
    {
        string Username { get; set; }
        List<User> Suscribers = new List<User>();

        public User(string Username) => this.Username = Username;
        public void AddNotification(string Notification) => Console.WriteLine(Notification);
        public void NotificateUsers(string Message)
        {
            foreach(var user in Suscribers)
                user.AddNotification($"-Notification from user {Username}: \n {Message}");
        }
        public void Suscribe(User follower) => Suscribers.Add(follower);
        public void Unsuscribe(User follower) => Suscribers.Remove(follower);
    }
}
