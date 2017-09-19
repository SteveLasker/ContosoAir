using ContosoAir.Site.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoAir.Site.Controllers
{
    [Route("api/[controller]")]
    public class SettingsController : Controller
    {
        private readonly MySettings _settings;
        public SettingsController(IOptions<MySettings> settings)
        {
            _settings = settings.Value;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetSettings() => Ok(_settings);
    }
}
