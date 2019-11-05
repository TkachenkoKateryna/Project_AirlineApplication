using System;
using System.Collections.Generic;

namespace AirlineApplication.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }

        public int UserId { get; set; }

        public NotificationType Type { get; set; }

        public string Description { get; set; }

        public DateTime DateTime { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsResolved { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}