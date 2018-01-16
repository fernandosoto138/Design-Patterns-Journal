namespace Bridge_CS_1
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
