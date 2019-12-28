using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyManagerService.Connections.AMQP
{
    public class ConnectAMQPBroker
    {
        public ConnectAMQPBroker()
        {
            //read broker connection configuration
            configuration.id = "hey this is an id";
            configuration.password = "and this is pw";
        }

        private Configuration configuration { get; }

        //configuration struct
        public class Configuration
        {
            public string id = null;
            public string password = null;
        }
    }
}
