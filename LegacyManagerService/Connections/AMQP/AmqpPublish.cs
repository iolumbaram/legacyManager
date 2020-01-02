using LegacyManagerService.Connections.AMQP.Abstractions;
using RabbitMQ.Client;
using System;
using System.IO;
using System.Text;

namespace LegacyManagerService.Connections.AMQP
{
    public class AmqpPublish : IAmqpPublish
    {
        public void Publish()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            try
            {
                u
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

        private string ReadFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader("test.txt"))
                {
                    String line = sr.ReadToEnd();
                    Console.WriteLine(line);
                    return line;
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
