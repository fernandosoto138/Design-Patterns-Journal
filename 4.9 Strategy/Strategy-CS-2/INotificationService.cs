namespace Bridge_CS_1
{
    interface INotificationService
    {
        bool SendNotification(User user, string message);
    }
}
