using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyManagerService.Connections.AMQP
{
    public class ConnectAMQPBroker
    {
        //public ConnectAMQPBroker()
        //{
        //    //read broker connection configuration
        //    configuration.id = "hey this is an id";
        //    configuration.password = "and this is pw";
        //}

        //private Configuration configuration { get; }

        ////configuration struct
        //public class Configuration
        //{
        //    public string id = null;
        //    public string password = null;
        //}

        public void Send()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            try
            {
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "simulation", durable: true, exclusive: false, autoDelete: false, arguments: null);
                    string message = "Hello World!";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "MOM", routingKey: "simulation", basicProperties: null, body: body);
                    Console.WriteLine(" [x] Sent {0}", message);
                }
            }
            catch
            {
                Console.WriteLine("CONNECTION ERROR!");
            }
            
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
