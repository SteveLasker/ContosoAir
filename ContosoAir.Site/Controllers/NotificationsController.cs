using Microsoft.AspNetCore.Mvc;
using ContosoAir.Site.Services;

namespace ContosoAir.Site.Controllers
{
    [Route("api/[controller]")]
    public class NotificationsController : Controller
    {
        //private readonly NotificationsService _notificationsService;

        //public NotificationsController(NotificationsService notificationsService)
        //{
        //    _notificationsService = notificationsService;
        //}

        //[HttpPost]
        //public async Task<ActionResult> Post(NotificationRequest notificationRequest)
        //{
        //    await _notificationsService.SendToAndroid(notificationRequest.Type, notificationRequest.GetMessage());
        //    await _notificationsService.SendToIos(notificationRequest.Type, notificationRequest.GetMessage());
        //    await _notificationsService.SendToWindows(notificationRequest.Type, notificationRequest.GetMessage());

        //    return Ok();
        //}
    }
}
