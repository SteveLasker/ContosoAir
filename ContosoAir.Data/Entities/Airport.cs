using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoAir.Data.Entities
{
    public class Airport
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
