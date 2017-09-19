using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoAir.Data.Entities
{
    public class AlternativeFlight
    {
        public int Id { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public int Stops { get; set; }
        public string Image { get; set; }
    }
}
