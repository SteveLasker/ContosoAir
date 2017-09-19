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
    public class SeatsController : Controller
    {
        Db _db;

        public SeatsController(Db db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var seat = new Seat
            {
                Options = new SeatOptions
                {
                    Available = 0,
                    Unavailable = 1,
                    Preferred = 2,
                    Contosoair = 3
                },
                Rows = new int[][]
                {
                    new int[]{ 1, 0, 0, 1, 3, 1},
                    new int[]{ 1, 1, 1, 0, 1, 1},
                    new int[]{ 1, 1, 1, 1, 1, 2},
                    new int[]{ 1, 1, 1, 1, 1, 1},
                    new int[]{ 1, 1, 0, 1, 1, 1},
                    new int[]{ 1, 0, 0, 1, 1, 1},
                    new int[]{ 1, 1, 1, 0, 0, 1},
                    new int[]{ 1, 0, 1, 1, 0, 1},
                    new int[]{ 1, 0, 1, 1, 1, 1}
                }
            };
            return Ok(seat);
        }
    }
}
