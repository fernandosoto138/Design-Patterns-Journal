using System.Collections.Generic;

namespace Bridge_CS_1
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
