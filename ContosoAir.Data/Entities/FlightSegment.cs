using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoAir.Data.Entities
{
    public class FlightSegment
    {
        public int Id { get; set; }
        public int Flight { get; set; }
        public string FromCode { get; set; }
        public string FromCity { get; set; }
        public string ToCode { get; set; }
        public string ToCity { get; set; }
        public DateTime DepartTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}
