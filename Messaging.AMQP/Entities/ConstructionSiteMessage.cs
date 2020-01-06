using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.AMQP.Entities
{
    public class ConstructionSiteMessage
    {
        public class ConstructionSite
        {
            public float noise1 { get; set; }
            public float noise2 { get; set; }
            public float noise3 { get; set; }
            public float pm2_5 { get; set; }
            public float pm10 { get; set; }
            public string location { get; set; }
            public float lat { get; set; }
            public float lon { get; set; }
            public long timestamp { get; set; }
        }

    }
}
