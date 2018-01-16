namespace Bridge_CS_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string ticketResponse = "Hi John, you can fix that issue buying one of your star products for 1000 usd, or you can die";
            string alertMessage = "Hey john, your suscription to life ends in 30 days";
            User JohnDoe = new User{Id = 36393 , Email = "AngryJohnDoe@ulala.com"};
            var responseToTicket = new SupportTicketResponse();
            var alertSuscriptions = new SuscriptionAlert();
            responseToTicket.NotifyUser(JohnDoe, ticketResponse);
            alertSuscriptions.NotifyUser(JohnDoe, alertMessage);
        }
    }
}
