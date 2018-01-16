using System;

namespace Strategy_CS_2
{
    class InAppMessageSender : INotificationService
    {
        public bool SendNotification(User user, string message)
        {
            Console.WriteLine($"Sending Notification to: {user.Id} \n {message}");
            return true;
        }
    }
}
