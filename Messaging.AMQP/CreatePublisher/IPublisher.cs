using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messaging.AMQP.CreatePublisher
{
    public interface IPublisher
    {
        Publisher CreateQueue(string exchange, string queue);
        void Populate(string JSONStringData);
        //destory();
    }
}
