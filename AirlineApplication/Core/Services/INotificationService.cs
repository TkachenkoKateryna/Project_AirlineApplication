using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineApplication.Core.Models;
using AirlineApplication.Core.ViewModels;

namespace AirlineApplication.Core.Services
{
    public interface INotificationService : IDisposable
    {
        IEnumerable<Notification> GetAllNotifications();

        IEnumerable<NotificationViewModel> GetAllCompletedNotifications();

        void Create(Notification notification);

        void UpdateToIsCompleted(int id);

        void UpdateToIsResolved(int id);

    }
}
