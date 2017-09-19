using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoAir.Data.Entities
{
    public class Flight
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Duration { get; set; }
        public string FromCode { get; set; }
        public string ToCode { get; set; }
        public int Distance { get; set; }
        public List<FlightSegment> Segments { get; set; }
    }
}
