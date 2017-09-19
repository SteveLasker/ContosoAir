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
    public class AirportsController : Controller
    {
        Db _db;

        public AirportsController(Db db)
        {
            _db = db;
        }

        [HttpGet("{code}")]
        public ActionResult Get(string code)
        {
            var airport = _db.Airports.FirstOrDefault(a => a.Code == code);

            if (airport == null)
            {
                return NotFound();
            }

            return Ok(airport);
        }

        [HttpGet]
        public ActionResult Get()
        {
            var airports = _db.Airports.ToList();
            return Ok(airports);
        }
    }
}
