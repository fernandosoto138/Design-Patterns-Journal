using System;

namespace Bridge_CS_1
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
