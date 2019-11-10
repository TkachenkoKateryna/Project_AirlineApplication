using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineApplication.Core.Models;
using AirlineApplication.Core.DTOs;

namespace AirlineApplication.Core.Services
{
    public interface INotificationService : IDisposable
    {
        IEnumerable<Notification> GetAllNotifications();
        void Create(Notification notification);
    }
}
