using ContosoAir.Data;
using ContosoAir.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace ContosoAir.Site.Controllers
{
    [Route("api/[controller]")]
    public class AlternativesController : Controller
    {
        Db _db;
        private static IHttpContextAccessor HttpContextAccessor;

        public AlternativesController(Db db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            HttpContextAccessor = httpContextAccessor;
        }
        private static string GetAbsoluteUri()
        {
            var request = HttpContextAccessor.HttpContext.Request;

            return request.Scheme + "://" + request.Host.Value;
        }

        [HttpGet("{city=paris}")]
        public ActionResult Get(string city)
        {
            var alternative = _db.Alternatives.Include(a => a.Flights).First();

            var folder = city == "paris" ? "default" : city;
            var documentsRootPath = GetAbsoluteUri() + "/assets/documents/" + folder;
            alternative.From = city;
            alternative.BoardingPass = alternative.BoardingPass.Replace("$", documentsRootPath);
            alternative.Map = alternative.Map.Replace("$", documentsRootPath);
            alternative.Coupon = alternative.Coupon.Replace("$", documentsRootPath);

            alternative.Flights.ForEach(flight =>
            {
                flight.Image = flight.Image.Replace("$", documentsRootPath);
            });

            return Ok(alternative);
        }
    }
}
