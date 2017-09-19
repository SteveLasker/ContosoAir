using ContosoAir.Data;
using ContosoAir.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ContosoAir.Site.Controllers
{
    [Route("api/[controller]")]
    public class FlightsController : Controller
    {
        Db _db;

        public FlightsController(Db db)
        {
            _db = db;
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var flight = _db.Fligths
                .Include(f=> f.Segments)
                .FirstOrDefault(f => f.Id == id);

            if (flight == null)
            {
                return NotFound();
            }

            return Ok(flight);
        }

        [HttpGet]
        public ActionResult Get()
        {
            var flights = _db.Fligths
                .Include(f=> f.Segments)
                .ToList();
            return Ok(flights);
        }
    }
}
