using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovie.Api.Extensions
{
    public class NotificationContent
    {
        public string Key { get; set; }
        public string Message { get; set; }
    }

    public static class Notification
    {
        public static NotificationContent NotificationContent { get; set; }

        public static void SetNotification(string key, string message)
        {
            NotificationContent = new NotificationContent
            {
                Key = key,
                Message = message
            };
        }

        public static NotificationContent GetNotification()
        {
            return NotificationContent;
        }

        public static void SetEmpty()
        {
            NotificationContent = null;
        }
    }
}
