namespace Strategy_CS_2
{
    class SuscriptionAlert : MessagesService
    {
        public SuscriptionAlert()
        {
            NotificationServices.Add(new MailNotification());
        }
    }
}
