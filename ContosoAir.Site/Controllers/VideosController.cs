using ContosoAir.Data;
using ContosoAir.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoAir.Site.Controllers
{
    [Route("api/[controller]")]
    public class VideosController : Controller
    {

        [HttpGet]
        public ActionResult Get()
        {
            var videos = new
            {
                Formats = new
                {
                    Desktop = "(format=mpd-time-csf)",
                    Mobile = "(format=m3u8-aapl)"
                },
                Links = new {
                    Barcelona = "https://contosoairmediacfa.streaming.mediaservices.windows.net/97ac0e05-2518-4fe8-ac18-c2a9d3a79211/barcelona-with-audio_1920x1080_6000.ism/manifest"
                }
            };
            return Ok(videos);
        }
    }
}
