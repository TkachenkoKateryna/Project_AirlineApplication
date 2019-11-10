using System.Collections.Generic;
using AirlineApplication.Core.Models;

namespace AirlineApplication.Core.Repositories
{
    public interface INotificationRepository
    {
        IEnumerable<Notification> GetAllNotifications();

        void CreateNotification(Notification notification);

        Notification GetNotification(int id);
    }
}
