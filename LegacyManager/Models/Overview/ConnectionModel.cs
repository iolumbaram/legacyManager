using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyManager.Models.Overview
{
    public class ConnectionModel
    {
        public ConnectionStatus C2;
        public ConnectionStatus RabbitMQBroker;
    }

    public class ConnectionStatus
    {
        public bool IsConnected;
        //public bool IsConnected
        //{
        //    get { return lblOverviewURAPubStatus.Text }
        //}
        public string LastCheckTimestamp;
    }
}
