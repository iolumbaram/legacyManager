using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyManagerService.Connections.AMQP.Abstractions
{
    interface IEventBus
    {
        void Publish();

        void Subscribe();

        void Unsubscribe<T, TH>();
    }
}
