using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirlineApplication.Core.Models;

namespace AirlineApplication.Core.ViewModels
{
    public class NotificationViewModel
    {
        public int NotificationId { get; set; }

        public NotificationType Type { get; set; }

        public string Description { get; set; }

        public DateTime DateTime { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsResolved { get; set; }

        public UserViewModel User { get; set; }
    }
}