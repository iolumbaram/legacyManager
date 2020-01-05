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
            
            IModel AMQPInstance = null;
            ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
            IConnection conn = factory.CreateConnection();
            using (var channel = conn.CreateModel())
            {
                AMQPInstance = channel;
                System.Diagnostics.Debug.Print("AMQP Instance Created");
                var AMQPPublisher = new Messaging.AMQP.CreatePublisher.Publisher();
                //AMQPPublisher.CreateQueue(AMQPInstance, "MOM", "simulation");

                string message = "Hello World!";
                AMQPPublisher.CreateQueue(AMQPInstance, "", "hello").Populate(message);
            }

            Application.Run(new LegacyUI());

            Console.ReadLine();
        }
    }
}
