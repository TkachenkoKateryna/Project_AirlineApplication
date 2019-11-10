using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirlineApplication.Core.ViewModels;
using AirlineApplication.Core.Models;
using AirlineApplication.Core.Services;
using AirlineApplication.Core;
using AirlineApplication.Core.DTOs;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AirlineApplication.Persistence.Services
{
    public class NotificationService : INotificationService
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public NotificationService(IUnitOfWork db)
        {
            _unitOfWork = db;
        }

        public IEnumerable<Notification> GetAllNotifications()
        {
            return _unitOfWork.Notifications.GetAllNotifications();
        }


        public void Create(Notification notification)
        {
            _unitOfWork.Notifications.Create(notification);
            _unitOfWork.Complete();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}