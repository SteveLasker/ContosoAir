using ContosoAir.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoAir.Data
{
    public class Db : DbContext
    {
        public Db(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Airport> Airports { get; set; }
        public DbSet<Alternative> Alternatives { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Flight> Fligths { get; set; }
    }
}
