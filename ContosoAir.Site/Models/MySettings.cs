using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoAir.Site.Models
{
    public class MySettings
    {
        public bool Production { get; set; }
        public AdalSettings Adal { get; set; }
    }
}
