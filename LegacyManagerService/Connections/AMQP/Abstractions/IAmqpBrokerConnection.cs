using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyManagerService.Connections.AMQP.Abstractions
{
    interface IAmqpBrokerConnection
    {
        void Connect();
        void Disconnect();
        void ResetConnection();

        bool IsConnected { get; }
        bool TryConnect();

        IModel CreateModel();
    }
}
