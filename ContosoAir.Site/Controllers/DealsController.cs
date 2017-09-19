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
    public class DealsController : Controller
    {
        Db _db;

        public DealsController(Db db)
        {
            _db = db;
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var deal = _db.Deals.FirstOrDefault(d => d.Id == id);

            if (deal == null)
            {
                return NotFound();
            }

            return Ok(deal);
        }

        [HttpGet]
        public ActionResult Get()
        {
            var deals = _db.Deals.ToList();
            return Ok(deals);
        }
    }
}
