using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirlineApplication.Core.Services;
using AirlineApplication.Core.Models;
using AutoMapper;
using Microsoft.AspNet.Identity;
using AirlineApplication.Core.ViewModels;

namespace AirlineApplication.Controllers
{
    [Authorize(Roles ="Admin, Dispatcher")]
    public class NotificationsController : Controller
    {
        private readonly INotificationService _notifService;

        public NotificationsController(INotificationService notifService)
        {
            _notifService = notifService;
        }

        public ActionResult ShowNotifications()
        {
            List<NotificationViewModel> notifications = new List<NotificationViewModel>();

            if (User.IsInRole("Admin"))
            {
                notifications = _notifService.GetAllNotifications()
                     .Where(n => n.IsCompleted == false)
                     .Select(Mapper.Map<Notification, NotificationViewModel>)
                     .ToList();
            }
            if (User.IsInRole("Dispatcher"))
            {
                notifications = _notifService.GetAllCompletedNotifications().ToList();
            }
;

            return View("ShowNotifications", notifications);
        }

        public ActionResult Complete(int id)
        {
            _notifService.UpdateToIsCompleted(id);
            return RedirectToAction("ShowNotifications","Notifications");
        }

        public ActionResult Resolve(int id)
        {
            _notifService.UpdateToIsResolved(id);
            return RedirectToAction("ShowNotifications", "Notifications");
        }
    }
}