using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoAir.Data.Entities
{
    public class Seat
    {
        public SeatOptions Options { get; set; }
        public IEnumerable<IEnumerable<int>> Rows { get; set; }
    }
}
