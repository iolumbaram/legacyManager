using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.HTTP.Controllers.Models
{
    //public class ConnectionList
    //{
    //    public string test;
    //}

    public class ConnectionList
    {
        public string name { get; set; }
        public string description { get; set; }
        public object[] tags { get; set; }
        public Metadata metadata { get; set; }
        public bool tracing { get; set; }
        public Cluster_State cluster_state { get; set; }
    }

    public class Metadata
    {
        public string description { get; set; }
        public object[] tags { get; set; }
    }

    public class Cluster_State
    {
        public string rabbitPDD1 { get; set; }
    }


}
