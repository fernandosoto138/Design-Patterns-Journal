using System.Collections.Generic;

namespace Strategy_CS_2
{
    abstract class MessagesService
    {
        protected List<INotificationService> NotificationServices {get; private set;} = new List<INotificationService>();
        
        public virtual void NotifyUser(User user, string msg)
        {
            foreach(INotificationService srv in NotificationServices)
            {
                srv.SendNotification(user, msg);
            }
        }
    }
}
