﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using AirlineApplication.Core.Repositories;
using AirlineApplication.Core.Models;

namespace AirlineApplication.Persistence.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _context;

        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Notification> GetAllNotifications()
        {
            return _context.Notifications.Include(n => n.User).ToList();
        }

        public void Create(Notification notification)
        {
            _context.Notifications.Add(notification);
        }

    }
}