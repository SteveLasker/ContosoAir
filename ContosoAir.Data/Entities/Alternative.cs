using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoAir.Data.Entities
{
    public class Alternative
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string BoardingPass { get; set; }
        public string Map { get; set; }
        public string Coupon { get; set; }
        public List<AlternativeFlight> Flights { get; set; }
    }    
}
