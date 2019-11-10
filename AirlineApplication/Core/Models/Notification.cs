using System;
using System.Collections.Generic;

namespace AirlineApplication.Core.Models
{
    public class Notification
    {
        public int NotificationId { get; private set; }

        public string UserId { get;  set; }

        public NotificationType Type { get;  set; }

        public string Description { get;  set; }

        public DateTime DateTime { get;  set; }

        public bool IsCompleted { get; set; }

        public bool IsResolved { get; set; }

        public ApplicationUser User { get;  set; }
    }
}