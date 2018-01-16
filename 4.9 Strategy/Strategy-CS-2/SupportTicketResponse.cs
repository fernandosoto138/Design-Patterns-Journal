namespace Strategy_CS_2
{
    class SupportTicketResponse : MessagesService
    {
        public SupportTicketResponse()
        {
            NotificationServices.Add(new MailNotification());
            NotificationServices.Add(new InAppMessageSender());
        }
    }
}
