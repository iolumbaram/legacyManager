using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messaging.AMQP.CreatePublisher
{
    public class Publisher : IPublisher
    {
        private string Exchange;
        private string Queue;
        private string RoutingKey;
        private IModel channel = null;

        //private Publisher obj = new Publisher();

        public Publisher CreateQueue(IModel AMQPInstance, string exchange, string queue)
        {
            Exchange = exchange;
            Queue = queue;
            RoutingKey = queue;
            channel = AMQPInstance;

            if (channel != null)
            {
                channel.QueueDeclare(queue: queue, durable: false, exclusive: false, autoDelete: false, arguments: null);
                return this;
            }
            else
            {
                Console.WriteLine("[error] Publish Creation Failed! Conneciton to Broker Not Ready");
                return null;
            }
        }

        public void Populate(string JSONStringData)
        {
            try
            {
                string message = JSONStringData;
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: Exchange, routingKey: RoutingKey, basicProperties: null, body: body);
                Console.WriteLine("[x] Sent {0}", message);
            }
            catch
            {
                Console.WriteLine("[error] Sent failed");
            }
        }
    }
}