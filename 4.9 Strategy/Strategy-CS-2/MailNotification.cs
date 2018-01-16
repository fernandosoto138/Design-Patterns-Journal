using System;

namespace Strategy_CS_2
{
    class MailNotification : INotificationService
    {
        public bool SendNotification(User user, string message)
        {
            Console.WriteLine($"Sending Notification Mail to: {user.Email} \n {message}");
            return true;
        }
    }
}
