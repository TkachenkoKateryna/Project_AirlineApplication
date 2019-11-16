using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using AirlineApplication.Core;
using AirlineApplication.Core.Services;
using AirlineApplication.Core.Models;
using AutoMapper;
using Microsoft.AspNet.Identity;
using AirlineApplication.Core.DTOs;

namespace AirlineApplication.Controllers.Api
{
    public class NotificationsController : ApiController
    {
        private readonly INotificationService _notifService;

        public NotificationsController(INotificationService notifService)
        {
            _notifService = notifService;
        }

        [HttpGet]
        public IEnumerable<NotificationDto> GetNotifications()
        {
            List<Notification> notifications = new List<Notification>();

            if (User.IsInRole("Admin"))
            {
                 notifications = _notifService.GetAllNotifications()
                    .Where(n => n.IsCompleted == false)
                     .ToList();
            }
            if (User.IsInRole("Dispatcher"))
            {
                 notifications = _notifService.GetAllNotifications()
                    .Where(n => n.IsCompleted == true &&
                     n.IsResolved == false )
                    .ToList();
            }

            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
        }

        [HttpPost]
        public IHttpActionResult NoMembers(NotificationDto notification)
        {
           _notifService.Create(Mapper.Map<NotificationDto, Notification>(notification));

            return Ok();
        }
    }
}
