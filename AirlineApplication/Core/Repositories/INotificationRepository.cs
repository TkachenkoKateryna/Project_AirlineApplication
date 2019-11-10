using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineApplication.Core.Models;

namespace AirlineApplication.Core.Repositories
{
    public interface INotificationRepository
    {
        IEnumerable<Notification> GetAllNotifications();
        void Create(Notification notification);
    }
}
