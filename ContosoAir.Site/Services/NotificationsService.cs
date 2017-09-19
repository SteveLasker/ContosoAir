//using Microsoft.Azure.NotificationHubs;
//using Microsoft.Extensions.Options;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ContosoAir.Site.Services
//{
//    public class NotificationsService
//    {
//        NotificationHubClient _hub;

//        public NotificationsService(IOptions<NotificationHubSettings> hubSettings)
//        {
//            var settings = hubSettings.Value;
//            _hub = NotificationHubClient.CreateClientFromConnectionString(settings.Secret, settings.Name);
//        }

//        public async Task SendToAndroid(NotificationType type, string message)
//        {
//            await _hub.SendGcmNativeNotificationAsync(@"{
//                    data: {
//                        message: " + message + @",
//                        type: " + type + @"
//                   }
//                }");
//        }

//        public async Task SendToIos(NotificationType type, string message)
//        {
//            await _hub.SendAppleNativeNotificationAsync(@"{
//                    apps: {
//                        alert: " + message + @",                        
//                    },
//                    type: " + type + @"
//                }");
//        }

//        public async Task SendToWindows(NotificationType type, string message)
//        {
//            await _hub.SendWindowsNativeNotificationAsync(@"<toast launch='${" + type + "'><visual><binding template=\"ToastGeneric\"><text>${" + message +  "}</text></binding></visual></toast>");
//        }
//    }
//}
