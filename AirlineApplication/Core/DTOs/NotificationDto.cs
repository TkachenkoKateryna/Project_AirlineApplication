using AirlineApplication.Core.Models;
using System;

namespace AirlineApplication.Core.DTOs
{
    public class NotificationDto
    {
        public string UserId { get;  set; }

        public NotificationType Type { get;  set; }

        public string Description { get;  set; }

        public DateTime DateTime { get;  set; }

        public bool IsCompleted { get; set; }

        public bool IsResolved { get; set; }

        public UserDto User { get;  set; }
    }
}