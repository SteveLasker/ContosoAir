using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoAir.Site
{
    public class AppSettings
    {
        public Connectionstrings ConnectionStrings { get; set; }
        public NotificationHubSettings NotificationHub { get; set; }
    }

    public class Connectionstrings
    {
        public string DefaultConnection { get; set; }
    }

    public class NotificationHubSettings
    {
        public string Name { get; set; }
        public string Secret { get; set; }

    }

    public class Logging
    {
        public bool IncludeScopes { get; set; }
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
        public string System { get; set; }
        public string Microsoft { get; set; }
    }
}
