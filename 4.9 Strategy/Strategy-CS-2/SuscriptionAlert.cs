namespace Bridge_CS_1
{
    class SuscriptionAlert : MessagesService
    {
        public SuscriptionAlert()
        {
            NotificationServices.Add(new MailNotification());
        }
    }
}
