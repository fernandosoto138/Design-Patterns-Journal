namespace Strategy_CS_2
{
    interface INotificationService
    {
        bool SendNotification(User user, string message);
    }
}
