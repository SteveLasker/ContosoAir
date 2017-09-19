using ContosoAir.Site.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoAir.Site.Models
{
    public class NotificationRequest
    {
        private readonly static Dictionary<NotificationType, string> _messages = new Dictionary<NotificationType, string>
            {
                { NotificationType.None, "" },
                { NotificationType.CheckInAvailable, "Check-in available!" },
                { NotificationType.DelayedFlight, "The flight has been delayed" },
                { NotificationType.GiveFeedback, "Give feedback" }
            };

        public NotificationType Type { get; set; }

        public string GetMessage()
        {
            return _messages[Type];
        }
    }
}
