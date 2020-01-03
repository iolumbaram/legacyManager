using LegacyManager.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Messaging.AMQP;
using System.Text;
using RabbitMQ.Client;

namespace LegacyManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LegacyUI());

            //var host = new Startup();
            //host.Configure();


            var AMQPConnecInstance = new Messaging.AMQP.ConnectAMQPBroker.Instance("guest","guest","localhost");
            //Messaging.AMQP.ConnectAMQPBroker.Instance.AMQPInstance;
            //Console.WriteLine(Messaging.AMQP.ConnectAMQPBroker.Instance.TestInstance);


            //if (Messaging.AMQP.ConnectAMQPBroker.Instance.AMQPInstance != null)
            //{
            //    System.Diagnostics.Debug.Print("using the created AMQP Instance");
            //    //var channel = Messaging.AMQP.ConnectAMQPBroker.Instance.AMQPInstance;
            //    Messaging.AMQP.ConnectAMQPBroker.Instance.AMQPInstance.QueueDeclare(queue: "helloX", durable: true, exclusive: false, autoDelete: false, arguments: null);
            //    string message = "Hello World!";
            //    var body = Encoding.UTF8.GetBytes(message);

            //    Messaging.AMQP.ConnectAMQPBroker.Instance.AMQPInstance.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);
            //    Console.WriteLine(" [x] Sent {0}", message);
            //}

            //var AMQPPublisher = new Messaging.AMQP.CreatePublisher.Publisher();
            //AMQPPublisher.CreateQueue("MOM", "simulation");
            Console.ReadLine();
        }
    }
}
