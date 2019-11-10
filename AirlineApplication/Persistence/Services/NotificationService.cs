using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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

        public IEnumerable<NotificationViewModel> GetAllCompletedNotifications()
        {
            return _unitOfWork.Notifications.GetAllNotifications()
               .Where(n => n.IsCompleted == true && n.IsResolved == false)
               .Select(Mapper.Map<Notification, NotificationViewModel>);
        }

        public void Create(Notification notification)
        {
            _unitOfWork.Notifications.CreateNotification(notification);
            _unitOfWork.Complete();
        }

        public void UpdateToIsCompleted(int id)
        {
            var notification = _unitOfWork.Notifications.GetNotification(id);
            notification.IsCompleted = true;
            _unitOfWork.Complete();
        }

        public void UpdateToIsResolved(int id)
        {
            var notification = _unitOfWork.Notifications.GetNotification(id);
            notification.IsResolved = true;
            _unitOfWork.Complete();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}