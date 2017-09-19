using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoAir.Data.Entities
{
    public class Deal
    {
        public int Id { get; set; }
        public string FromName { get; set; }
        public string FromCode { get; set; }
        public string ToName { get; set; }
        public string ToCode { get; set; }
        public int Price { get; set; }
        public DateTime? DepartTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public string Hours { get; set; }
        public int? Stops { get; set; }
        public DateTime? Since { get; set; }
    }
}
